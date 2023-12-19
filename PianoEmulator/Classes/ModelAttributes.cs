using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace PianoEmulator.Classes
{
    /// <summary>
    /// 0 - StringLengthAttribute
    /// 1 - DisplayAttribute
    /// 2 - RequiredAttribute
    /// 3 - DataTypeAttribute
    /// </summary>

    public static class ModelAttributes
    {
        public static object GetFieldAttribute(string key, object data, int attribute)
        {
            object returnObj = null;

            MemberInfo[] memberInfo = null;

            try
            {
                memberInfo = data.GetType().GetMember(key);
            }
            catch (Exception exc)
            {
                var Error = exc.Message;
                return null;
            }

            //base random initialization
            var attributes = memberInfo[0].GetCustomAttributes(typeof(object), false);

            switch (attribute)
            {
                #region 0 - StringLengthAttribute
                case 0:

                    attributes = memberInfo[0].GetCustomAttributes(typeof(StringLengthAttribute), false);

                    try
                    {
                        returnObj = ((StringLengthAttribute)attributes[0]).MaximumLength;
                    }
                    catch
                    {
                        returnObj = 0;
                    }

                    if ((int)returnObj == 0)
                        returnObj = 2000;

                    break;
                #endregion

                #region 1 - DisplayAttribute(Name)
                case 1:

                    attributes = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);

                    string description = null;
                    try
                    {
                        description = ((DisplayAttribute)attributes[0]).Name;
                    }
                    catch
                    {
                        description = null;
                    }

                    if (string.IsNullOrEmpty(description))
                        returnObj = "";
                    else
                        returnObj = description;

                    break;
                #endregion

                #region 2 - RequiredAttribute
                case 2:

                    attributes = memberInfo[0].GetCustomAttributes(typeof(RequiredAttribute), false);

                    if (attributes.Length == 0)
                        returnObj = false;
                    else
                        returnObj = true;

                    break;
                #endregion

                #region 3 - DataTypeAttribute(Email)
                case 3:

                    attributes = memberInfo[0].GetCustomAttributes(typeof(DataTypeAttribute), false);

                    try
                    {
                        returnObj = ((DataTypeAttribute)attributes[0]).DataType;
                    }
                    catch
                    {
                        returnObj = null;
                    }

                    break;
                #endregion

                default:
                    returnObj = null;
                    break;
            }

            return returnObj;
        }

        public static List<string> GetFieldsName(object model)
        {
            List<string> list = new List<string>();
            PropertyInfo[] properties = model.GetType().GetProperties();

            foreach (var item in properties)
            {
                try
                {
                    list.Add(GetFieldAttribute(item.Name, model, 1).ToString());
                }
                catch
                {
                    list.Add(" ");
                }
            }

            return list;
        }
    }
}