using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HashPasswords;
using WpfOvo.Model;
using System.Data.Entity;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using System.Linq.Expressions;

namespace WpfOvo.Pages
{
    public partial class Autho : Page
    {
        Model1 dbContext = new Model1();
        Users user = new Users();
        int countUnsuccessful = 0;
        public Autho()
        {
            InitializeComponent();
            tboxCaptcha.Visibility = Visibility.Hidden;
            tblockCaptcha.Visibility = Visibility.Hidden;
        }
        private void btnEnterGuests_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Guest());
        }
        private void btnSign_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registration());
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tbxLogin.Text) && !String.IsNullOrEmpty(pasboxPassword.Password))
            {
                LoginUser();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите логин и пароль", "Предупреждение");
                countUnsuccessful++;
                GenerateCaptcha();
                if (countUnsuccessful % 3 == 0)
                {
                    TimerBLock();
                    return;
                }
            }
        }
        
        private void LoginUser()
        {

            if (countUnsuccessful > 0)
            {
                if (countUnsuccessful % 3 == 0) // Проверка 3-ю неправильного ввода, чтобы не обнулять и не пропадала проверка капчи ;)
                {
                    TimerBLock();
                    return;
                }
                if (!CheckingCaptcha())
                {
                    MessageBox.Show("Неверная капча", "Предупреждение");
                    countUnsuccessful++;
                    GenerateCaptcha();
                }
            }


            string Login = tbxLogin.Text.Trim();
            string pass = pasboxPassword.Password.Trim();
            string Password = HashPasswords.HashPasswords.Hash(pass.Replace("\"", ""));

            user = dbContext.Users.Where(p => p.Login == Login).FirstOrDefault();
            if (user != null)
            {
                if (user?.Password == Password)
                {
                    LoadForm(user.RoleID.ToString());
                    tbxLogin.Text = "";
                    tboxCaptcha.Text = "";
                    countUnsuccessful = 0;
                    tboxCaptcha.Visibility = Visibility.Hidden;
                    tblockCaptcha.Visibility = Visibility.Hidden;
                }
                else
                {
                    MessageBox.Show("неверный пароль", "Предупреждение");
                    GenerateCaptcha();
                    countUnsuccessful++;
                    if (countUnsuccessful % 3 == 0)
                        TimerBLock();
                }
            }
            else
            {
                MessageBox.Show("пользователя с логином '" + Login + "' не существует", "Предупреждение");
                GenerateCaptcha();
                countUnsuccessful++;
                if (countUnsuccessful % 3 == 0)
                    TimerBLock();
                return;
            }
        }

        private async void TimerBLock()
        {
            panel.IsEnabled = false;

            await Task.Factory.StartNew(() =>
            {
                for (int i = 10; i > 0; i--)
                {
                    //Каждую секунду вызывает метод для обновления текста
                    tblockTimer.Dispatcher.Invoke(() =>
                    {
                        tblockTimer.Text = $"подождите {i} сек";
                    });
                    Task.Delay(1000).Wait();//приостанавливает выполнение задачи на 1 секунду
                }
            });

            tblockTimer.Text = "";
            panel.IsEnabled = true;
        }

        private void LoadForm(string _role)
        {
            switch (_role)
            {
                //клиент -- посмотреть свои данные и обьекты 
                case "1":
                    NavigationService.Navigate(new Client(user));
                    break;
                //админ -- умеет все 
                case "2":
                    NavigationService.Navigate(new Admin(user));
                    break;
                //Сотрудник отдела вневедомственной охраны -- составляет договоры 
                case "3":
                    if (TimeWork())
                    {
                        NavigationService.Navigate(new Employee(user));
                    }
                    else
                    {
                        MessageBox.Show("рабочий день закончен или еще не начался", "Предупреждение");
                    }
                    break;
            }
        }
        private bool TimeWork()
        {
            var currentTime = DateTime.Now;
            if (currentTime.Hour < 10 || currentTime.Hour > 17) return false;
            return true;
        }
        private void GenerateCaptcha()
        {
            tboxCaptcha.Visibility = Visibility.Visible;
            tblockCaptcha.Visibility = Visibility.Visible;

            char[] letters = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();
            Random rand = new Random();

            string word = "";
            for (int j = 1; j <= 8; j++)
            {
                int letter_num = rand.Next(0, letters.Length - 1);
                word += letters[letter_num];
            }

            tblockCaptcha.Text = word;
            tblockCaptcha.TextDecorations = TextDecorations.Strikethrough;
            tboxCaptcha.Text = "";
        }
        private bool CheckingCaptcha() => tblockCaptcha.Text == tboxCaptcha.Text.Trim();

    }
}
