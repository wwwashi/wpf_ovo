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

            if (!String.IsNullOrEmpty(phone) && !String.IsNullOrEmpty(surname) && !String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(login) && !String.IsNullOrEmpty(password))
            {
                if (tbxPassword.Text.Length > 6)
                {
                    if (phone.Length == 18)
                    {
                        if (!CheckUserLoginExists(login))
                        {
                            SaveUser(login, password, name, surname, phone);
                        }
                        else
                        {
                            MessageBox.Show("Пользователь с таким логином уже существует");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Номер телефона должен иметь формат +9 (999) 999-99-99");
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
        private void SaveUser(string login, string password, string name, string surname, string phone)
        {
            var dbContext = new Model1();
            var user = new Users();
            user.Login = login;
            user.Password = password;
            user.Name = name;
            user.Surname = surname;
            user.Phone = phone;
            user.RoleID = 1;

            dbContext.Users.Add(user);
            dbContext.SaveChanges();
            MessageBox.Show("Пользователь успешно зарегистрирован");
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