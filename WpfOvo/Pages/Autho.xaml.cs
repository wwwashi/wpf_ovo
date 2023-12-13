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

namespace WpfOvo.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autho.xaml
    /// </summary>
    public partial class Autho : Page
    {
        Model1 dbContext = new Model1();
        Users user = new Users();
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

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tbxLogin.Text) && !String.IsNullOrEmpty(pasboxPassword.Password))
            {
                LoginUser();
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите логин и пароль");
            }
        }
        int countUnsuccessful = 0;
        private void LoginUser()
        {

            if (countUnsuccessful > 0)
            {
                if (tboxCaptcha.Text != tblockCaptcha.Text)
                {
                    MessageBox.Show("Неверная капча");
                    countUnsuccessful++;
                    return;
                }
                else
                {
                    MessageBox.Show("капча введена правильно");
                }
            }


            string Login = tbxLogin.Text;
            string Password = HashPasswords.HashPasswords.Hash(pasboxPassword.Password.Replace("\"", ""));

            user = dbContext.Users.Where(p => p.Login == Login).FirstOrDefault();
            if (user != null)
            {
                if (user?.Password == Password)
                {
                    LoadForm(user.RoleID.ToString());
                    tbxLogin.Text = "";
                    tboxCaptcha.Text = "";
                    tboxCaptcha.Visibility = Visibility.Hidden;
                    tblockCaptcha.Visibility = Visibility.Hidden;
                }
                else
                {
                    MessageBox.Show("неверный пароль");
                    GenerateCaptcha();
                    countUnsuccessful++;
                    if (countUnsuccessful > 3)
                    {
                        TimerBLock();
                    }
                }
            }
            else
            {
                MessageBox.Show("пользователя с логином '" + Login + "' не существует");
                countUnsuccessful++;
                return;
            }
        }

        private async void TimerBLock()
        {
            tbxLogin.IsEnabled = false;
            pasboxPassword.IsEnabled = false;
            tboxCaptcha.IsEnabled = false;

            btnEnterGuests.IsEnabled = false;
            btnEnter.IsEnabled = false;
            btnSign.IsEnabled = false;

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

            countUnsuccessful = 0;

            tblockTimer.Text = "";
            tbxLogin.IsEnabled = true;
            pasboxPassword.IsEnabled = true;
            tboxCaptcha.IsEnabled = true;

            btnEnterGuests.IsEnabled = true;
            btnEnter.IsEnabled = true;
            btnSign.IsEnabled = true;
        }

        private void btnSign_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registration());
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
                    NavigationService.Navigate(new Employee(user));
                    break;
            }
        }
        private void GenerateCaptcha()
        {
            tboxCaptcha.Visibility = Visibility.Visible;
            tblockCaptcha.Visibility = Visibility.Visible;

            Random rdm = new Random();
            int rndNum = rdm.Next(1, 6);
            switch (rndNum)
            {
                case 1:
                    tblockCaptcha.Text = "ju2sT8Cds";
                    tblockCaptcha.TextDecorations = TextDecorations.Strikethrough;
                    break;
                case 2:
                    tblockCaptcha.Text = "iNmK2cl";
                    tblockCaptcha.TextDecorations = TextDecorations.Strikethrough;
                    break;
                case 3:
                    tblockCaptcha.Text = "uOozGk95";
                    tblockCaptcha.TextDecorations = TextDecorations.Strikethrough;
                    break;
                case 4:
                    tblockCaptcha.Text = "Isfnwk54";
                    tblockCaptcha.TextDecorations = TextDecorations.Strikethrough;
                    break;
                case 5:
                    tblockCaptcha.Text = "D9ddGjss";
                    tblockCaptcha.TextDecorations = TextDecorations.Strikethrough;
                    break;
                case 6:
                    tblockCaptcha.Text = "8djJHFsl";
                    tblockCaptcha.TextDecorations = TextDecorations.Strikethrough;
                    break;
            }
        }
    }
}
