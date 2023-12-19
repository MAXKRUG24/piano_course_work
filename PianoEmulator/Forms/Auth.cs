using PianoEmulator.Classes;
using PianoEmulator.Models;
using System.Linq;
using System.Windows.Forms;

namespace PianoEmulator.Forms
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }

        // Авторизация
        private void btnAuth_Click(object sender, System.EventArgs e)
        {
            // Получение логина и пароля с формы
            string login = tbLogin.Text;
            string password = tbPassword.Text;

            // Проверка на пустоту, если данные не введены, то выводим предупреждающее сообщение
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                MessageBox.Show("Все поля обязательный для заполнения!", "Предупреждение");
            else
            {
                // Если пользователь существует то открываем формы связанные с эмулятором пианино
                if (Connector.Get<users>().Where(u => u.Login.Equals(login) && u.Password.Equals(password)).FirstOrDefault() != null)
                {
                    // Добавляем текущего пользователя в глобальную переменную
                    Connector.currentUser = Connector.Get<users>().Where(u => u.Login.Equals(login) && u.Password.Equals(password)).FirstOrDefault();
                    // Открываем форму эмулятора пианино
                    new Main().Show();
                }
                // Если вошёл администратора
                else if (Connector.Get<admins>().Where(u => u.Login.Equals(login) && u.Password.Equals(password)).FirstOrDefault() != null)
                    // Открываем панель администратора
                    new Admin().Show();
                else
                {
                    // Если никого и нигде не нашло, то выводим соответствующее сообщение
                    MessageBox.Show("Логин или пароль не верны!", "Ошибка");
                    // Выходим из метода заранее
                    return;
                }

                // Закрываем текущую
                Close();
            }
        }

        // Закрыть приложение
        private void btnClose_Click(object sender, System.EventArgs e) => Application.Exit();
    }
}