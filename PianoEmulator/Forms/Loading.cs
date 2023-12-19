using PianoEmulator.Classes;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PianoEmulator.Forms
{
    public partial class Loading : Form
    {
        // Глобальная переменная определяющая нужно ли закрывать форму
        public bool isClose = true;

        public Loading()
        {
            InitializeComponent();
            // Установка интервала таймера в 1 секунду (1000) и его запуск
            pianoTimer.Interval = 1000;
            pianoTimer.Start();
        }

        // Событие после закрытия формы
        private void Loading_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isClose == true)
                Application.Exit();
        }

        // Таймер запускающий проверку соединения с БД, проверку настроек
        private void pianoTimer_Tick(object sender, EventArgs e)
        {
            //Если существует файл настроек подключения
            if (File.Exists("config.cfg"))
            {
                //Создаем объект для чтения из файла читаем данные о подключении в переменную
                StreamReader streamReader = new StreamReader("config.cfg");
                string ConnectionString = streamReader.ReadLine();
                streamReader.Close();

                //Передаем строку подключения на ранение в экземпляр класса
                Connector.NpgsqlConnectionstring = ConnectionString;

                if (!string.IsNullOrEmpty(ConnectionString) && Connector.SQLQuery("SELECT version();") == true)
                {
                    //Остановка таймера
                    pianoTimer.Stop();
                    // Ставим флаг закрытия формы в false
                    isClose = false;
                    //Загрузка формы авторизации
                    new Auth().Show();
                    //Скрытие этой формы
                    Hide();
                }
                else
                {
                    labelCheckSettings.Text = "Ошибка соединения";
                    labelCheckSettings.Location = new Point(215, 273);
                    //Остановка таймера
                    pianoTimer.Stop();
                    //Предложение об ручной настройке соединения
                    if (MessageBox.Show("Нужна настройка доступа к БД. Настроить?", "Ошибка", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        // Ставим флаг закрытия формы в false
                        isClose = false;
                        //Если нажали да, то создаем экземпляр класса формы настроек
                        Settings settings = new Settings();
                        settings.btnReturn.Enabled = false;
                        settings.btnCancel.Enabled = true;
                        settings.Show();
                        //Скрываем эту форму
                        Hide();
                    }
                    else
                        Close();
                }
            }
            else
            {
                //Создаем объект для создания файла со строкой подключения
                new StreamWriter("config.cfg").Close();
            }
        }

        private void Loading_Load(object sender, EventArgs e)
        {

        }

        private void labelCheckSettings_Click(object sender, EventArgs e)
        {

        }
    }
}