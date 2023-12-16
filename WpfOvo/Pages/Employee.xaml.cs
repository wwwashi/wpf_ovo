using System;
using System.Windows.Controls;
using WpfOvo.Model;

namespace WpfOvo.Pages
{
    public partial class Employee : Page
    {
        private Users currentUser;
        public Employee(Users currentUser)
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
        {
            var currentTime = DateTime.Now;
            if (currentTime.Hour >= 10 && currentTime.Hour <= 12) return "Доброе утро";
            if (currentTime.Hour >= 12 && currentTime.Hour <= 17) return "Добрый день";
            if (currentTime.Hour >= 17 && currentTime.Hour <= 19) return "Добрый вечер";
            return "Добро пожаловать";
        }
    }
}
