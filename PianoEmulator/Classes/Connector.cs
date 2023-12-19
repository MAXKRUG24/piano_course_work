using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Data;
using Npgsql;
using PianoEmulator.Models;

namespace PianoEmulator.Classes
{
    public class Connector
    {        
        static object obj = null;

        public static users currentUser { get; set; }

        public static int TypeDB { get; set; }

        static string SQLValue { get; set; }

        public static string NpgsqlConnectionstring { get; set; }

        static BindingFlags BindingFlags => BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Default;

        static Type TableName { get; set; }

        static List<string> Columns
        {
            get
            {
                return TableName.GetProperties(BindingFlags).Select(c => c.Name).ToList();
            }
            set
            {
                Columns.Clear();
                Columns.AddRange(value);
            }
        }

        static object ExecuteQuery(string query, string method)
        {
            NpgsqlConnection connection = null;
            NpgsqlCommand dbCommand = null;

            try
            {
                connection = new NpgsqlConnection(NpgsqlConnectionstring);

                connection.Open();

                dbCommand = new NpgsqlCommand(query, connection);

                using (var reader = dbCommand.ExecuteReader())
                {
                    switch (method)
                    {
                        #region Get method that return table records
                        case "Get":
                            var list = CreateList(TableName);

                            while (reader.Read())
                            {
                                //Create new object for current record (current table)
                                var resObj = Activator.CreateInstance(TableName);

                                foreach (var column in Columns)
                                {
                                    //Get data from column
                                    PropertyInfo info = TableName.GetProperty(column);
                                    try
                                    {
                                        //Add new value for object
                                        info.SetValue(resObj, Convert.ChangeType(reader[column], info.PropertyType, null));
                                    }
                                    catch (Exception exc)
                                    {
                                        Debug.WriteLine(method + ": " + exc.Message);
                                    }
                                }
                                list.Add(resObj);
                            }

                            obj = list;
                            break;
                        #endregion

                        #region GetValue method that return one value after query
                        case "GetValue":
                            if (reader.FieldCount != 0)
                            {
                                try
                                {
                                    reader.Read();
                                    obj = reader[0].ToString();
                                }
                                catch (Exception exc)
                                {
                                    Debug.WriteLine(method + ": " + exc.Message);
                                }
                            }
                            break;
                        #endregion

                        #region SQLQuery method that just execute query without return values
                        case "SQLQuery":
                            obj = true;
                            break;
                        #endregion

                        default:
                            obj = false;
                            break;
                    }

                    dbCommand.Dispose();
                    connection.Close();

                    return obj;
                }
            }
            catch (Exception exc)
            {
                try
                {
                    connection.Close();
                }
                catch (Exception dbExc)
                {
                    Debug.WriteLine(method + ": " + dbExc.Message);
                }

                try
                {
                    dbCommand.Dispose();
                }
                catch (Exception dbExc)
                {
                    Debug.WriteLine(method + ": " + dbExc.Message);
                }

                Debug.WriteLine(method + ": " + exc.Message);

                return null;
            }
        }

        static bool CheckObj(params object[] data)
        {
            if (data == null || data.Count() < 1)
                return false;
            if (data != null)
                foreach (var item in data)
                    if (item == null)
                        return false;
            TableName = data[0].GetType();
            return true;
        }

        public static bool Insert(params object[] data)
        {
            if (CheckObj(data) == false)
                return false;

            SQLValue = "INSERT INTO " + TableName.Name;

            var strWithColumns = string.Format(" ({0}) values ", (string.Join(",", Columns.ToArray())).TrimEnd(','));
            var strWithValues = string.Empty;

            foreach (var table in data)
            {
                strWithValues += '(';
                foreach (var column in Columns)
                {
                    if (column.Length <= 2 && column.ToLower().IndexOf("id") != -1)
                    {
                        var IdValue = TableName.GetProperty(column).GetValue(table, null);

                        if ((int)IdValue <= 0)
                        {
                            string idValue = GetValue("SELECT MAX(Id) FROM " + TableName.Name);

                            int maxId = 1;

                            if (!string.IsNullOrEmpty(idValue))
                            {
                                try
                                {
                                    maxId = int.Parse(idValue);

                                    if (maxId <= 0)
                                        maxId = 1;
                                    else
                                        maxId++;
                                }
                                catch
                                {
                                    maxId = 1;
                                }
                            }

                            strWithValues += string.Format("'{0}',", maxId.ToString());

                            continue;
                        }
                    }

                    var value = TableName.GetProperty(column).GetValue(table, null);

                    if (value == null)
                        value = " ";

                    strWithValues += string.Format("'{0}',", value);
                }
                strWithValues = strWithValues.TrimEnd(',') + "),";
            }
            strWithValues = strWithValues.TrimEnd(',') + ";";

            SQLValue = string.Format("{0}{1}{2}", SQLValue, strWithColumns, strWithValues);

            if (ExecuteQuery(SQLValue, "SQLQuery") == null)
                return false;
            else
                return (bool)obj;
        }

        public static List<T> Get<T>()
        {
            TableName = typeof(T);
            return (List<T>)ExecuteQuery("SELECT * FROM " + TableName.Name, "Get");
        }

        public static List<object> Get(string table, string condition)
        {
            try
            {
                TableName = Activator.CreateInstance(Type.GetType("PianoEmulator.Models." + table)).GetType();
            }
            catch
            {
                return null;
            }

            string Query = "SELECT * FROM " + table;

            if (!string.IsNullOrEmpty(condition))
                Query += " " + condition;

            var obj = ExecuteQuery(Query, "Get");

            if (obj == null)
                return null;

            if (obj is IEnumerable)
                return ((IEnumerable)obj).Cast<object>().ToList();
            return new List<object>() { obj };
        }
       
        public static string GetValue(string query)
        {
            try
            {
                return ExecuteQuery(query, "GetValue") == null ? null : (string)obj;
            }
            catch
            {
                return null;
            }
        }

        public static bool Update(int oldId, params object[] data)
        {
            if (CheckObj(data) == false)
                return false;

            if (oldId <= 0)
                return false;

            SQLValue = "UPDATE " + TableName.Name + " SET ";

            foreach (var table in data)
            {
                foreach (var column in Columns)
                {
                    SQLValue += column + " = '" + TableName.GetProperty(column).GetValue(table, null) + "',";
                }
                SQLValue = SQLValue.TrimEnd(',') + " WHERE Id = " + oldId + ";";
            }

            if (ExecuteQuery(SQLValue, "SQLQuery") == null)
                return false;
            else
                return (bool)obj;
        }

        public static bool Delete(params object[] data)
        {
            SQLValue = "DELETE FROM " + TableName.Name + " WHERE Id = ";

            foreach (var id in data)
            {
                SQLValue += TableName.GetProperty("Id").GetValue(id, null);
            }

            if (ExecuteQuery(SQLValue, "SQLQuery") == null)
                return false;
            else
                return (bool)obj;
        }

        public static bool SQLQuery(string query) => ExecuteQuery(query, "SQLQuery") == null ? false : (bool)obj;

        public static IList CreateList(Type listItemType) => (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(listItemType));
    }
}