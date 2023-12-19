using PianoEmulator.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace PianoEmulator.Classes
{
    public class FormGenerator
    {
        // Глобальная переменная для хранения названия проекта
        static readonly string projectName = MethodBase.GetCurrentMethod().DeclaringType.Namespace;
        // Глобальная переменная для хранения размера лейбла
        static int labelSize = 0;
        // Глобальная переменная для хранения размера панели
        static int panelHeight = 0;
        // Глобальная переменная для хранения названия таблицы
        static int _currentTable;
        // Глобальная переменная для хранения объекта формы
        static Form _form;
        // Глобальная переменная для хранения названия таблицы
        static string _table;
        // Глобальная переменная для хранения текущего действия
        static string _action;
        // Глобальная переменная для хранения объекта панели
        static Panel panel;
        // Глобальная переменная для хранения поля ввода
        static TextBox tbBuffer = new TextBox();
        // Глобальная переменная для хранения поля ввода
        static ComboBox cbBuffer = new ComboBox();
        // Глобальная переменная для хранения значений редактирования
        static List<string> values = new List<string>();
        // Глобальная переменная для хранения id строки
        static string _idEdit;
        // Глобальная переменная для хранения объекта объекта
        static object model = null;
        // Глобальная переменная для хранения столбцов
        static List<string> columns = null;
        // Глобальная переменная для хранения свойств
        static PropertyInfo[] prop = null;
        // Глобальная переменная для хранения объекта работы с картинкой
        static OpenFileDialog openImageDialog;
        // Глобальная переменная для хранения объекта работы с музыкой
        static OpenFileDialog openSoundDialog;

        // Конструктор класса
        public FormGenerator(Form form, string action, string table, string idEdit, int currentTable)
        {
            // Перенос значений
            _form = form;
            _table = table;
            _action = action;
            _idEdit = idEdit;
            _currentTable = currentTable;

            // Генерация объёкта модели
            model = Activator.CreateInstance(Type.GetType(projectName.Substring(0, projectName.IndexOf(".")) + ".Models." + _table));
            // Получение русских названий полей
            columns = ModelAttributes.GetFieldsName(model);
            // Получние получение свойств модели
            prop = model.GetType().GetProperties();
        }

        // Метод закрытия формы и открытия главной
        static void Return()
        {
            Admin admin = new Admin();
            admin.cbTables.SelectedIndex = _currentTable;
            admin.LoadData();
            admin.isLoad = 0;
            admin.Show();
        }

        // Событие закрытия формы
        public static void Form_FormClosing(object sender, FormClosingEventArgs e) => Return();

        // Глобальная переменная для хранения значения полей ввода
        static string tbName = "";

        // Метод нажатия на кнопку OK
        public static void ButtonOk_Click(object sender, EventArgs e)
        {
            // Список по элементам панели, проверка на пустоту полей ввода
            foreach (Control itemPanel in panel.Controls)
            {
                // Если элемент 
                if (itemPanel.GetType().Equals(typeof(TextBox)))
                {
                    // Привидение элемента к типу TextBox
                    tbBuffer = (TextBox)itemPanel;

                    // Получение названия эллемента
                    string Name = tbBuffer.Name;

                    if (tbName == Name)
                        continue;

                    // Получение названия
                    tbName = tbBuffer.Name.ToString();

                    // Если поле ввода пустое, то выводим предупреждающее сообщение
                    if (string.IsNullOrEmpty(tbBuffer.Text))
                    {
                        MessageBox.Show("Все поля обязательны для заполнения!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // И ставим фокус на данное поле ввода
                        tbBuffer.Focus();
                        return;
                    }
                }
            }

            // Переменная для запроса
            string query = "";

            // Добавить
            if (_action.Equals("Add"))
            {
                // Генерируем строку запроса
                query += "INSERT INTO " + _table + " (";

                // Получаем название столбцов
                for (int i = 0; i < prop.Length; i++)
                {
                    query += prop[i].Name + ",";
                }

                // Обрезание последней запятой
                query = query.Substring(0, query.LastIndexOf(","));
                // Начало добавления самих значений
                query += ") VALUES ('";

                // Цикл для получения самих значений с панели
                foreach (Control itemPanel in panel.Controls)
                {
                    // Если тип поля TextBox
                    if (itemPanel.GetType().Equals(typeof(TextBox)))
                    {
                        // Привидение типов к типу TextBox
                        tbBuffer = (TextBox)itemPanel;

                        // Добавляем физически звук в папку с проектом
                        if (tbBuffer.Name.IndexOf("Sound") != -1)
                            AddSound(tbBuffer);

                        // Получение самого значения и добавление к строке запроса
                        query += tbBuffer.Text + "','";
                    }
                    // Если тип поля ComboBox
                    else if (itemPanel.GetType().Equals(typeof(ComboBox)))
                    {
                        // Привидение типов к типу ComboBox
                        cbBuffer = (ComboBox)itemPanel;
                        // Получение самого значения и добавление к строке запроса

                        string foreignKeyId = "";
                        if (cbBuffer.Name.IndexOf("Languages") != -1)
                            foreignKeyId = Connector.GetValue(string.Format("SELECT Id FROM languages WHERE FullName = '{0}'", cbBuffer.Text));
                        else if (cbBuffer.Name.IndexOf("Users") != -1)
                            foreignKeyId = Connector.GetValue(string.Format("SELECT Id FROM users WHERE Login = '{0}'", cbBuffer.Text));
                        else
                            foreignKeyId = Connector.GetValue(string.Format("SELECT Id FROM {0} WHERE Name = '{1}'", cbBuffer.Name.Substring(4), cbBuffer.Text));

                        query += foreignKeyId + "','";
                    }
                }

                // Обрезание последней запятой
                query = query.Substring(0, query.LastIndexOf("',"));
                // Закрытие строки запроса
                query += "');";

                // Если запрос не прошёл, то выводим одно сообщение, иначе успех
                if (Connector.SQLQuery(query) == false)
                    MessageBox.Show("Ошибка добавления", "Ошибка");
                else
                    MessageBox.Show("Результат применён!", "Добавление");
            }
            // Изменить
            else
            {
                // Переменая хранения названия поля ввода
                tbName = "";
                // Очистка значений
                values.Clear();
                // Переменная хранения запроса
                query += "UPDATE " + _table + " SET";

                // Цикл по элементам панели, перенос значений
                foreach (Control itemPanel in panel.Controls)
                {
                    // Если поля ввода типа TextBox
                    if (itemPanel.GetType().Equals(typeof(TextBox)))
                    {
                        // Привидение типов к типу TextBox
                        tbBuffer = (TextBox)itemPanel;
                        // Присвоение названия в переменную
                        string Name = tbBuffer.Name;

                        if (tbName == Name)
                            continue;

                        // Добавляем физически звук в папку с проектом
                        if (tbBuffer.Name.IndexOf("Sound") != -1)
                            AddSound(tbBuffer);

                        // Перенос значения
                        tbName = tbBuffer.Name.ToString();
                        // Добавление значений в список
                        values.Add(tbBuffer.Text);
                    }
                    // Если тип поля ComboBox
                    else if (itemPanel.GetType().Equals(typeof(ComboBox)))
                    {
                        // Привидение типов к типу ComboBox
                        cbBuffer = (ComboBox)itemPanel;
                        // Получение самого значения и добавление к строке запроса

                        string foreignKeyId = "";
                        if (cbBuffer.Name.IndexOf("Languages") != -1)
                            foreignKeyId = Connector.GetValue(string.Format("SELECT Id FROM languages WHERE FullName = '{0}'", cbBuffer.Text));
                        else if (cbBuffer.Name.IndexOf("Users") != -1)
                            foreignKeyId = Connector.GetValue(string.Format("SELECT Id FROM users WHERE Login = '{0}'", cbBuffer.Text));
                        else
                            foreignKeyId = Connector.GetValue(string.Format("SELECT Id FROM {0} WHERE Name = '{1}'", cbBuffer.Name.Substring(4), cbBuffer.Text));

                        values.Add(foreignKeyId);
                    }
                }

                // Цикл по свойствам
                for (int i = 0; i < prop.Length; i++)
                {
                    // Если элемент в 0-евой позиции
                    if (i == 0)
                    {
                        // Запрос с id
                        query += " " + prop[i].Name + " = '" + _idEdit + "',";
                        continue;
                    }

                    // Остальные значения
                    query += " " + prop[i].Name + " = '" + values[i - 1] + "',";
                }

                // Обрезание последней запятой
                query = query.Substring(0, query.LastIndexOf("',"));
                // Добавление условия редактирования
                query += "' WHERE Id = " + _idEdit;

                // Если запрос не прошёл, то выводим предупреддающее сообщение, иначе успех
                if (Connector.SQLQuery(query) == false)
                    MessageBox.Show("Ошибка редактирования", "Ошибка");
                else
                    MessageBox.Show("Результат применён!", "Редактирование");
            }
        }
        
        // Метод добавления музыку в папку
        public static void AddSound(TextBox textBox)
        {
            if (File.Exists(@"Data\Sounds\" + textBox.Text))
            {
                File.Delete(@"Data\Sounds\" + textBox.Text);
            }

            try
            {
                File.Copy(openSoundDialog.FileName, @"Data\Sounds\" + textBox.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Звуковой файл");
            }
        }

        // Метод нажатия на кнопку BtnSound
        public static void ButtonSound_Click(object sender, EventArgs e)
        {
            // Получаем TextBox с путём к файлу по имени
            TextBox tbSound = (TextBox)panel.Controls.Find("tbSound", false).FirstOrDefault();
            //Создаём новый объект хранения файла
            openSoundDialog = new OpenFileDialog
            {
                // Указываем форматы изображений
                Filter = "Звуковой файл" + " (*.mp3; *.mp4;)|*.mp3; *.mp4;"
            };

            // Если была нажата кнопка OK, то добавляем файл в объект
            if (openSoundDialog.ShowDialog() == DialogResult.OK)
            {
                // и выводим его название в TextBox  
                tbSound.Text = openSoundDialog.SafeFileName;
            }
        }

        // Метод нажатия на кнопку BtnCancelImage
        public static void ButtonCancelFile_Click(object sender, EventArgs e)
        {
            // Получаем TextBox с путём к файлу по имени
            TextBox tbImage = (TextBox)panel.Controls.Find("tbImage", false).FirstOrDefault();
            // Очищаем поле ввода
            tbImage.Clear();
            // Очищаем объект хранения картинки
            openImageDialog = null;
        }

        // Метод генерации обычного лейбла
        public Label Generatelabel(string Text, string Name, int labelY)
        {
            // Генерация лейбла
            Label label = new Label
            {
                Location = new Point(6, labelY),
                Name = "label" + Name,
                Anchor = ((AnchorStyles.Top | AnchorStyles.Left)),
                Size = new Size(360, 22),
                Text = Text,
                BackColor = Color.Transparent,
                ForeColor = Color.White
            };
            // Перенос высоты лейбла в глобальную переменную
            labelSize = label.Size.Height;
            // Возвращание лейбла
            return label;
        }

        // Метод генерации поля ввода
        public TextBox GenerateTextBox(string Text, string Name, int tbY)
        {
            // Генерация поля ввода
            TextBox textBox = new TextBox
            {
                Location = new Point(9, tbY),
                Name = "tb" + Name,
                Anchor = ((AnchorStyles.Top | AnchorStyles.Left)),
                Size = new Size(360, 20),
                Text = Text
            };
            // Возвращение поля ввода
            return textBox;
        }

        // Метод генерации ComboBox (выпадающий список)
        public ComboBox GenerateComboBox(string Text, string Name, int tbY)
        {
            // Определение названия таблицы мелкими буквами
            string table = Name.Substring(2).ToLower();
            // Получение данных из БД, список строк
            List<object> data = Connector.Get(table, null);
            // Переменная для хранения одного столбца из БД
            List<string> items = new List<string>();
            // Если данные есть
            if (data != null && data.Count > 0)
            {
                string returnField = "";
                foreach (var item in data)
                {
                    if (table.Equals("languages"))
                        returnField = "FullName";
                    else if (table.Equals("users"))
                        returnField = "Login";
                    else
                        returnField = "Name";

                    try
                    {
                        items.Add((string)item.GetType().GetProperty(returnField).GetValue(item, null));
                    }
                    catch (Exception exc)
                    {
                        items.Add(exc.Message);
                    }
                }
            }
            // Генерация самого выпадющего списка
            ComboBox comboBox = new ComboBox
            {
                Location = new Point(9, tbY),
                Name = "cb" + Name,
                Anchor = ((AnchorStyles.Top | AnchorStyles.Left)),
                Size = new Size(360, 20),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            // Если данные есть, то переносим полученые из БД данные в выпадающий список
            // и ставим первый элемент теущим выбранным
            if (data != null && data.Count > 0)
            {
                comboBox.Items.AddRange(items.ToArray());
                comboBox.SelectedIndex = 0;
            }

            // Установка редактируемого значения
            if (!string.IsNullOrEmpty(Text))
            {
                string returnField = "";

                if (table.Equals("languages"))
                    returnField = "FullName";
                else if (table.Equals("users"))
                    returnField = "Login";
                else
                    returnField = "Name";

                comboBox.Text = Connector.GetValue(string.Format("SELECT {0} FROM {1} WHERE Id = {2}", returnField, Name.Substring(2), Text));
            }                

            //Возвращаем выпадающий список
            return comboBox;
        }

        // Метод генерации поля ввода для файла
        public TextBox GenerateFileField(string Text, string Name, int tbY)
        {
            // Генерация поля ввода
            TextBox textBox = new TextBox
            {
                Location = new Point(9, tbY),
                Name = "tb" + Name,
                Anchor = ((AnchorStyles.Top | AnchorStyles.Left)),
                Size = new Size(360, 20),
                Text = Text,
                ReadOnly = true
            };
            // Возвращение поля ввода
            return textBox;
        }

        // Метод генерации кнопки для работы с файлов музыки
        public Button GenerateSoundBtn(string Name, int tbY)
        {
            // Генерация кнопки по добавлению картинки 
            Button btnSound = new Button
            {
                Location = new Point(9, tbY),
                Name = "btn" + Name,
                Anchor = ((AnchorStyles.Top | AnchorStyles.Left)),
                Size = new Size(360, 40),
                Text = "Добавить звуковой файл",
                ForeColor = Color.White
            };

            // Навешиваем кнопке обработчик клика
            btnSound.Click += ButtonSound_Click;

            return btnSound;
        }

        // Метод генерации кнопки отмены добавления картинки
        public Button GenerateCancelFileBtn(string Name, int tbY)
        {
            // Генерация кнопки по добавлению картинки 
            Button btnFile = new Button
            {
                Location = new Point(9, tbY),
                Name = "btnCancel" + Name,
                Anchor = ((AnchorStyles.Top | AnchorStyles.Left)),
                Size = new Size(360, 40),
                Text = "Отмена",
                ForeColor = Color.White
            };

            // Навешиваем кнопке обработчик клика
            btnFile.Click += ButtonCancelFile_Click;

            return btnFile;
        }

        // Метод генерации формы
        public void Generate()
        {
            // Переменная для хранения размера панели
            panelHeight = 0;

            // Создание объекта типа Form
            Form form = new Form
            {
                Width = 430,
                Font = _form.Font,
                Icon = _form.Icon,
                BackColor = _form.BackColor,
                ForeColor = _form.ForeColor,
                FormBorderStyle = _form.FormBorderStyle,
                MaximizeBox = false,
                StartPosition = FormStartPosition.CenterScreen,
                Text = _action.Equals("Add") ? "Добавление" : "Изменение"
            };

            // Добавление события закрытия формы
            form.FormClosing += Form_FormClosing;

            // Создание объекта типа Panel
            panel = new Panel
            {
                Name = "panelMain",
                Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right),
                AutoScroll = true,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(12, 12)
            };

            // Переменные для хранения позиции элементов по оси Y
            int textBoxY = 0;
            int labelY = 0;

            // Добавить
            if (_action.Equals("Add"))
            {
                // Цикл по колонкам формы (генерация элементов в панели)
                for (int i = 0; i < columns.Count; i++)
                {
                    // Определение начально и последующих позиций элементов в панели
                    if (textBoxY == 0 && labelY == 0)
                    {
                        labelY += 7;
                        textBoxY += 23;
                    }
                    else
                        labelY += 47;

                    panel.Controls.Add(Generatelabel(columns[i], prop[i].Name, labelY));

                    // Определение позиции TextBox на основе Label
                    textBoxY = labelY + labelSize + 10;

                    // Если элемент является внешним ключом, то выводим вместо TextBox элемент ComboBox
                    if (prop[i].Name.IndexOf("Fk") != -1)
                    {
                        panel.Controls.Add(GenerateComboBox(null, prop[i].Name, textBoxY));
                    }
                    // Если элемент является картинкой, ты выводим поле отображения пути к файлу и кнопку добавить
                    else if (prop[i].Name.IndexOf("Image") != -1)
                    {
                        panel.Controls.Add(GenerateFileField("", prop[i].Name, textBoxY));
                        panel.Controls.Add(GenerateCancelFileBtn(prop[i].Name, textBoxY + 80));
                    }
                    else if (prop[i].Name.IndexOf("Sound") != -1)
                    {
                        panel.Controls.Add(GenerateFileField("", prop[i].Name, textBoxY));
                        panel.Controls.Add(GenerateSoundBtn(prop[i].Name, textBoxY + 40));
                        panel.Controls.Add(GenerateCancelFileBtn(prop[i].Name, textBoxY + 80));
                    }
                    else
                    {
                        panel.Controls.Add(GenerateTextBox("", prop[i].Name, textBoxY));
                    }

                    // Добавление расстояния между элементами
                    labelY += 20;
                }
            }
            // Изменить
            else
            {
                // Получение модели с данными
                model = Connector.Get(_table, "WHERE Id = " + _idEdit).FirstOrDefault();

                // Цикл по колонкам формы (генерация элементов в панели)
                for (int i = 1; i < columns.Count; i++)
                {
                    // Определение начально и последующих позиций элементов в панели
                    if (textBoxY == 0 && labelY == 0)
                    {
                        labelY += 7;
                        textBoxY += 23;
                    }
                    else
                        labelY += 47;

                    // Добавление Label на панель
                    panel.Controls.Add(Generatelabel(columns[i], prop[i].Name, labelY));

                    // Определение позиции TextBox на основе Label
                    textBoxY = labelY + labelSize + 10;

                    // Если элемент является внешним ключом, то выводим вместо TextBox элемент ComboBox с данными
                    if (prop[i].Name.IndexOf("Fk") != -1)
                    {
                        panel.Controls.Add(GenerateComboBox(prop[i].GetValue(model, null).ToString(), prop[i].Name, textBoxY));
                    }
                    // Если элемент является картинкой, ты выводим поле отображения пути к файлу и кнопку добавить
                    else if (prop[i].Name.IndexOf("Image") != -1)
                    {
                        panel.Controls.Add(GenerateFileField(prop[i].GetValue(model, null).ToString(), prop[i].Name, textBoxY));
                        panel.Controls.Add(GenerateCancelFileBtn(prop[i].Name, textBoxY + 80));
                    }
                    else if (prop[i].Name.IndexOf("Sound") != -1)
                    {
                        panel.Controls.Add(GenerateFileField(prop[i].GetValue(model, null).ToString(), prop[i].Name, textBoxY));
                        panel.Controls.Add(GenerateSoundBtn(prop[i].Name, textBoxY + 40));
                        panel.Controls.Add(GenerateCancelFileBtn(prop[i].Name, textBoxY + 80));
                    }
                    else
                    {
                        panel.Controls.Add(GenerateTextBox(prop[i].GetValue(model, null).ToString(), prop[i].Name, textBoxY));
                    }

                    // Добавление расстояния между элементами
                    labelY += 25;
                }
            }

            // Определение размера панели
            foreach (var item in panel.Controls)
            {
                // Если элемент на форме типа Label
                if (item.GetType() == typeof(Label))
                {
                    Label label = (Label)item;
                    panelHeight += label.Height + 15;
                }
                // Если элемент на форме типа textBox
                else if (item.GetType() == typeof(TextBox))
                {
                    TextBox textBox = (TextBox)item;
                    panelHeight += textBox.Height + 15;
                }
                // Если элемент на форме типа ComboBox
                else if (item.GetType() == typeof(ComboBox))
                {
                    ComboBox comboBox = (ComboBox)item;
                    panelHeight += comboBox.Height + 15;
                }
                // Если элемент на форме типа Button
                else if (item.GetType() == typeof(Button))
                {
                    Button button = (Button)item;
                    panelHeight += button.Height + 15;
                }
            }

            // Установка размеров панели
            panel.Size = new Size(390, panelHeight);
            // Установка скролл бара
            panel.AutoScrollMinSize = new Size(0, (55 * columns.Count));

            // Создание объекта типа Button
            Button btnOk = new Button
            {
                Name = "btnOk",
                Text = "Применить",
                Width = 390,
                Height = 40,
                Anchor = (AnchorStyles.Bottom | AnchorStyles.Left),
                Location = new Point(12, panel.Location.Y + panelHeight + 20),
                ForeColor = Color.White
            };

            // Установка размеры всей формы, высота
            form.Height = panel.Height + btnOk.Height + 100;

            // Навешивание события нажатия кнопки для созданного объекта выше
            btnOk.Click += ButtonOk_Click;
            // Добавление панели на форму
            form.Controls.Add(panel);
            // Добавление кнопки на форму
            form.Controls.Add(btnOk);
            // Отображение формы
            form.Show();
        }
    }
}