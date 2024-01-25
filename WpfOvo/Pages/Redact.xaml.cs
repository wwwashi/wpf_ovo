using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfOvo.Model;

namespace WpfOvo.Pages
{
    public partial class Redact : Page
    {
        private Users currentUser;
        public Redact(Users selectedUser)
        {
            InitializeComponent();
            this.currentUser = selectedUser;

            tbFam.Text = currentUser.Surname;
            tbName.Text = currentUser.Name;
            tbOtch.Text = currentUser.Midname;
            tbPhone.Text = currentUser.Phone;

            if (currentUser.RoleID == 1)
                tbRole.SelectedIndex = 0;
            if (currentUser.RoleID == 2)
                tbRole.SelectedIndex = 1;
            if (currentUser.RoleID == 3)
                tbRole.SelectedIndex = 2;

            if (currentUser.GenderID == 1)
                tbGender.SelectedIndex = 0;
            if (currentUser.GenderID == 2)
                tbGender.SelectedIndex = 1;

            tbLogin.Text = currentUser.Login;
            tbPass.Text = currentUser.Password;
            //ImageUser.Source = currentUser.Image;
        }

        private void AddImage_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == true)
            {
                ImageUser.Source = new BitmapImage(new Uri(openFileDialog.FileName));

            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                currentUser.Surname = tbFam.Text;
                currentUser.Name = tbName.Text;
                currentUser.Midname = tbOtch.Text;
                currentUser.Phone = tbPhone.Text;
                if (tbRole.SelectedIndex == 0)
                    currentUser.RoleID = 1;
                if (tbRole.SelectedIndex == 1)
                    currentUser.RoleID = 2;
                if (tbRole.SelectedIndex == 2)
                    currentUser.RoleID = 3;

                if (tbGender.SelectedIndex == 0)
                    currentUser.GenderID = 1;
                if (tbGender.SelectedIndex == 1)
                    currentUser.GenderID = 2;

                currentUser.Login = tbLogin.Text;
                currentUser.Password = tbPass.Text;

                using (var context = new Model1())
                {
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Handle database errors:
                MessageBox.Show("Error updating user: " + ex.Message);
            }
        }
    }
}
