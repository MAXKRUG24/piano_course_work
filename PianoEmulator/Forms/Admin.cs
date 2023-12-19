using PianoEmulator.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace PianoEmulator.Forms
{
    public partial class Admin : Form
    {
        // Глобальная переменная определяющая нужно ли закрывать форму
        public bool isClose = true;
        // Переменная для загрузки данных при загрузке формы, если 1, то грузим
        public int isLoad = 1;

        // Название проекта
        public string projectName = MethodBase.GetCurrentMethod().DeclaringType.Namespace;       

        // Перечисление со списком таблиц
        string[] massTables = new string[] {
            "admins",
            "users",
            "recorded"
        };

        public Admin()
        {
            InitializeComponent();

            projectName = projectName.Substring(0, projectName.IndexOf("."));

            // Загрузка списка таблиц
            cbTables.Items.AddRange(new string[] {
                "Администраторы","Пользователи","Записанные композиции"
            });

            // Устанавливаем базовым значением первый элемент массива
            cbTables.SelectedIndex = 0;
        }

        // Процедура загрузки данных в зависимости от выбранной таблицы
        public void LoadData()
        {
            // Для строк
            List<object> list = null;
            // Получение имени текущей таблицы
            string table = massTables[cbTables.SelectedIndex];
            // Для хранения данных
            BindingSource bindingSource = new BindingSource();
            // Получение имён столбцов текущей выбранной таблицы

            // Переменная хранения записей
            List<string> columns = null;
            // Защита вывода
            try
            {
                columns = ModelAttributes.GetFieldsName(Activator.CreateInstance(Type.GetType(string.Format("{0}.Models.{1}", projectName, table))));
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка: " + exc.Message, "Ошибка");
            }

            // Загрузка данных в лист
            list = Connector.Get(table, null);

            // Если данные есть
            if (list != null && list.Count > 0)
            {
                // Присваиваем сорсу источник данных как лист строк
                bindingSource.DataSource = list;
                // Присваиваем навигатору источник данных как бин сорс 
                navigatorMain.BindingSource = bindingSource;
                // Присваиваем таблицу (гриду) источник данных как бин сорс
                dgvMain.DataSource = bindingSource;

                // Циклом загоняем в таблицу названия колонок
                for (int i = 0; i < columns.Count; i++)
                {
                    dgvMain.Columns[i].HeaderText = columns[i];
                }

                // Переменная для хранения временных данных
                string temp = "";
                int position = 0;
                // Получаем объект таблицы
                var model = Activator.CreateInstance(Type.GetType(projectName + ".Models." + table));

                // Пробегаемся по нему циклом и ищём столбцы с внешними ключами, получаем индекс столбца
                foreach (var item in model.GetType().GetProperties())
                {
                    // Если в модели имеется внешний ключ с припиской FK, то
                    if (item.Name.IndexOf("Fk") != -1)
                    {
                        // запускаем цикл по таблице,
                        for (int i = 0; i < dgvMain.Rows.Count; i++)
                        {
                            // где по полученному индексу берём значение внешного ключа (число)
                            temp = dgvMain[position, i].Value.ToString();
                            // и устанавливаем возвращаемое поле по ключу
                            string findColumn = "";

                            // если таблицы языки, то возвращаем fullName, в остальных случаях name
                            if (item.Name.Substring(2).ToLower().Equals("users"))
                                findColumn = "Login";
                            else
                                findColumn = "Name";

                            // И заменяем внешний ключ (число), его текстовым эквивалентом
                            try
                            {
                                dgvMain[position, i].Value = Connector.GetValue(string.Format("SELECT {0} FROM {1} WHERE Id = {2}", findColumn, item.Name.Substring(2), temp));
                            }
                            catch (Exception exc)
                            {
                                MessageBox.Show(exc.Message, "Ошибка");
                            }
                        }
                    }
                    // Увеличение позиции на 1
                    position++;
                }
            }
            else
            {
                // Если нет данных, то очищаем
                dgvMain.DataSource = null;
                navigatorMain.BindingSource = null;
            }
        }

        // Меню->Авторизация. Кнопка выхода на форму авторизации
        private void authToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isClose = false;
            new Auth().Show();
            Close();
        }

        // Открытие формы настроек
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ставим флаг закрытия в false
            isClose = false;
            // Открываем форму и блокируем ряд кнопок
            Settings settings = new Settings();
            settings.btnCancel.Enabled = false;
            settings.Show();
            // Закрываем текущее окно
            Close();
        }

        // Меню->Выход. Кнопка выхода из программы
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        // Меню->О программе. Кнопка вызова окна о программе
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа эмулятор пианино © 2019",
                "О программе");
        }
        
        // Загрузка формы
        private void Admin_Load(object sender, EventArgs e)
        {
            if (isLoad == 1)
                LoadData();
        }

        // Событие после закрытия формы
        private void Admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isClose == true)
                new Auth().Show();
        }

        // Кнопка загрузки таблицы
        private void btnLoadTable_Click(object sender, EventArgs e) => LoadData();

        // Кнопка открытия формы исправления (поля взяты из выделенной строки)
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Ставим флаг закрытия в false
            isClose = false;
            // Если данных нет, выводим предупреджающее сообщение
            if (dgvMain.RowCount <= 0)
            {
                MessageBox.Show("Нечего изменять", "Редактирование");
                return;
            }

            // Автогенерируем форму добавления и открываем её
            new FormGenerator(this, "Edit", massTables[cbTables.SelectedIndex], dgvMain[0, dgvMain.CurrentRow.Index].Value.ToString(), cbTables.SelectedIndex).Generate();
            // Скрываем текущее окно
            Hide();
        }

        // Кнопка удаления выделенной строки
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Проверка, есть ли в таблице вообще данные
            if (dgvMain.RowCount <= 0)
                MessageBox.Show("Нечего удалять!", "Удаление");

            // Окно с вопросом, если да - удаляем, нет - ничего не делаем
            if (MessageBox.Show("Действительно хотите удалить?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Удаление выбранной строки из базы данных
                Connector.SQLQuery(string.Format("DELETE FROM {0} WHERE Id = {1}", massTables[cbTables.SelectedIndex], int.Parse(dgvMain[0, dgvMain.CurrentRow.Index].Value.ToString())));
                // Отображение оставшихся строк
                LoadData();
            }
        }

        // Кнопка открытия формы добавления (поля пустые)
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Ставим флаг закрытия в false
            isClose = false;
            // Автогенерируем форму добавления и открываем её
            new FormGenerator(this, "Add", massTables[cbTables.SelectedIndex], null, cbTables.SelectedIndex).Generate();
            // Скрываем текущее окно
            Hide();
        }

        // Кнопка печати отображённых данных
        private void btnPrint_Click(object sender, EventArgs e) => new Exports().ExportToExcel(dgvMain);

        // Кнопка поиска по таблице
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dgvMain.RowCount <= 0)
                MessageBox.Show("Нечего искать", "Поиск");

            int i, j = 0;

            for (i = 0; i < dgvMain.ColumnCount; i++)
            {
                for (j = 0; j < dgvMain.RowCount; j++)
                {
                    dgvMain[i, j].Style.BackColor = Color.White;
                    dgvMain[i, j].Style.ForeColor = Color.Black;
                }
            }
            for (i = 0; i < dgvMain.ColumnCount; i++)
            {
                for (j = 0; j < dgvMain.RowCount; j++)
                {
                    if ((dgvMain[i, j].FormattedValue.ToString().Contains(tbSearch.Text.Trim())))
                    {
                        dgvMain[i, j].Style.BackColor = Color.DarkGray;
                        dgvMain[i, j].Style.ForeColor = Color.White;
                    }
                }
            }
        }

        // Кнопка очистки результатов поиска
        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            tbSearch.Clear();
            int i = 0, j = 0;

            for (i = 0; i <= dgvMain.ColumnCount - 1; i++)
            {
                for (j = 0; j <= dgvMain.RowCount - 1; j++)
                {
                    dgvMain[i, j].Style.BackColor = Color.White;
                    dgvMain[i, j].Style.ForeColor = Color.Black;
                }
            }
        }
    }
}