using System;
using System.Windows.Controls;

namespace WpfOvo.Pages
{
    public partial class Guest : Page
    {
        public Guest()
        {
            InitializeComponent();
            LabelText();
        }
        private void LabelText()
        {
            fio.Content = $"{TimeOfDay()}!";
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
