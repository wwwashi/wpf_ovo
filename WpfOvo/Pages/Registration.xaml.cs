using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfOvo.Model;

namespace WpfOvo.Pages
{
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }
        private void btnSign_Click(object sender, RoutedEventArgs e)
        {
            string login = tbxLogin.Text;
            string password = HashPasswords.HashPasswords.Hash(tbxPassword.Text.Replace("\"", ""));
            string name = tbxName.Text;
            string surname = tbxSurname.Text;
            string phone = tbxPhone.Text;
            string midname = tbxMidname.Text;
            int? gender;
            if (cbGender.SelectedIndex == 0)
                gender = 1;
            if (cbGender.SelectedIndex == 1)
                gender = 2;
            else
                gender = null;

            if (!String.IsNullOrEmpty(phone) && !String.IsNullOrEmpty(surname) && !String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(login) && !String.IsNullOrEmpty(password))
            {
                if (tbxPassword.Text.Length > 6)
                {
                    if (phone.Length == 11)
                    {
                        if (!CheckUserLoginExists(login))
                        {
                            SaveUser(login, password, name, surname, phone, midname, gender);
                        }
                        else
                        {
                            MessageBox.Show("Пользователь с таким логином уже существует");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Номер телефона должен иметь формат 79991112233");
                    }
                }
                else
                {
                    MessageBox.Show("Пароль должен иметь длину не менее 6 символов");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите данные");
            }
        }
        private void SaveUser(string login, string password, string name, string surname, string phone, string midname, int? gender)
        {
            var dbContext = new Model1();
            var user = new Users();
            user.Login = login;
            user.Password = password;
            user.Name = name;
            user.Surname = surname;
            user.Midname = midname;
            user.Phone = phone;
            user.GenderID = gender;
            user.RoleID = 1;

            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            MessageBox.Show("Пользователь успешно зарегистрирован");
            NavigationService.Navigate(new Autho());
        }
        private bool CheckUserLoginExists(string login)
        {
            using (var dbContext = new Model1())
            {
                return dbContext.Users.Where(p => p.Login == login).Any();
            }
        }
    }
}