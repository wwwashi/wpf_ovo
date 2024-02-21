using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using WpfOvo.Model;

namespace WpfOvo.Pages
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        private Users currentUser;
        public Admin(Users currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
            LabelText();
        }
        private void LabelText()
        {
            fio.Content = $"{TimeOfDay()}! \n{Gender()} {currentUser.Surname} {currentUser.Name} {currentUser?.Midname}";
        }

        private string Gender()
        {
            int gender = Convert.ToInt32(currentUser.GenderID.ToString());
            if (gender == 1)
                return "Mr";
            if (gender == 2)
                return "Mrs";
            return " ";
        }
        private string TimeOfDay()
        { /*
           в переменную currenTime берется в настоящий момент времени и далее сравниваются часы.
            в зависимости от времени пользователю выводится сообщение.
            
            если пользователь залогинился с 10 до 12 выводится сообщение "доброе утро"
            если пользователь залогинился с 12 до 17 выводится сообщение "добрый день"
            если пользователь залогинился с 17 до 19 выводится сообщение "добрый вечер"
            если залогинился в другое время то добро пожаловать

           */
            var currentTime = DateTime.Now;
            if (currentTime.Hour >= 10 && currentTime.Hour <= 12) return "Доброе утро";
            if (currentTime.Hour >= 12 && currentTime.Hour <= 17) return "Добрый день";
            if (currentTime.Hour >= 17 && currentTime.Hour <= 19) return "Добрый вечер";
            return "Добро пожаловать";
        }

        private void btnUsersList_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminEmployeeList());
        }
    }
}