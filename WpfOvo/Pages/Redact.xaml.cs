using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfOvo.Model;
using ValidationResult = System.ComponentModel.DataAnnotations.ValidationResult;

namespace WpfOvo.Pages
{
    public partial class Redact : Page
    {
        private Users user;
        public Redact(Users selectedUser)
        {
            InitializeComponent();
            this.user = selectedUser;
            tbFam.Text = user.Surname;
            tbName.Text = user.Name;
            tbOtch.Text = user.Midname;
            tbPhone.Text = user.Phone;

            if (user.RoleID == 1)
                tbRole.SelectedIndex = 0;
            if (user.RoleID == 2)
                tbRole.SelectedIndex = 1;
            if (user.RoleID == 3)
                tbRole.SelectedIndex = 2;

            if (user.GenderID == 1)
                tbGender.SelectedIndex = 0;
            if (user.GenderID == 2)
                tbGender.SelectedIndex = 1;

            tbLogin.Text = user.Login;
            tbPass.Text = user.Password;
            //ImageUser.Source = user.Image;

        }

        private void AddImage_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog(); openFileDialog.Filter = "Image Files (*.png; *.jpg; *.jpeg; *.bmp)|*.png; *.jpg; *.jpeg; *.bmp|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                //ImageUser.Source = new BitmapImage(new Uri(imagePath));
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            user.Surname = tbFam.Text;
            user.Name = tbName.Text;
            user.Midname = tbOtch.Text;
            user.Phone = tbPhone.Text;
            if (tbRole.SelectedIndex == 0)
                user.RoleID = 1;
            if (tbRole.SelectedIndex == 1)
                user.RoleID = 2;
            if (tbRole.SelectedIndex == 2)
                user.RoleID = 3;

            if (tbGender.SelectedIndex == 0)
                user.GenderID = 1;
            if (tbGender.SelectedIndex == 1)
                user.GenderID = 2;

            user.Login = tbLogin.Text;
            user.Password = HashPasswords.HashPasswords.Hash(tbPass.Text.Replace("\"", ""));
            // Проверка валидации
            var validationResults = user.Validate(new ValidationContext(user));
            if (validationResults.Any())
            {
                string errorMessage = string.Join("\n", validationResults.Select(r => r.ErrorMessage)); MessageBox.Show("Ошибка при сохранении данных: " + errorMessage);
                return;
            }
            else
            {
                var dbContext = new Model1();
                dbContext.Users.AddOrUpdate(user);
                dbContext.SaveChanges();
                MessageBox.Show("Обновлено");
                NavigationService.Navigate(new AdminEmployeeList());
            }
            //user.Image = new BinaryData(imageBytes);
        }
    }
}