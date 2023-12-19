using System;
using System.IO;
using System.Windows.Forms;

namespace PianoEmulator.Forms
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        // Кнопка создания соединения с БД
        private void btnConnection_Click(object sender, EventArgs e)
        {
            if (tbServer.Text.Equals("") || tbUser.Text.Equals("") || tbPassword.Text.Equals("") || tbDBName.Text.Equals("") || tbPort.Text.Equals(""))
                MessageBox.Show("Все поля обязательны для заполнения!", "Предупреждение");
            else
            {
                try
                {
                    StreamWriter streamWriter = new StreamWriter("config.cfg");
                    streamWriter.WriteLine(string.Format("Server={0};Port={1};Database={2};User Id={3};Password={4};",
                        tbServer.Text, tbPort.Text, tbDBName.Text, tbUser.Text, tbPassword.Text));
                    streamWriter.Close();
                    MessageBox.Show("Соединение создано!", "Создано");
                    new Loading().Show();
                    Close();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Ошибка с конфигурационным файлом");
                }
            }
        }

        // Кнопка отмены
        private void btnCancel_Click(object sender, EventArgs e)
        {
            new Loading().Show();
            Close();
        }

        //Кнопка выхода в главное меню
        private void btnReturn_Click(object sender, EventArgs e)
        {
            new Admin().Show();
            Close();
        }
    }
}