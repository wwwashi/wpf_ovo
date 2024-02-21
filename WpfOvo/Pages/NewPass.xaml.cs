using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Policy;
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
using System.Xml.Linq;
using WpfOvo.Model;

namespace WpfOvo.Pages
{
    /// <summary>
    /// Логика взаимодействия для NewPass.xaml
    /// </summary>
    public partial class NewPass : Page
    {
        private Users currentUser;
        
        public NewPass(Users currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string pass = HashPasswords.HashPasswords.Hash(tbxPass.Text.Replace("\"", ""));
            if (!String.IsNullOrEmpty(pass))
                SaveUser(pass);
            else
                MessageBox.Show("Введите данные");
        }
        private void SaveUser(string pass)
        {
            var dbContext = new Model1();
            currentUser.Password = pass;

            dbContext.Users.AddOrUpdate(currentUser);
            dbContext.SaveChanges();
            MessageBox.Show("Обновлено");
            NavigationService.Navigate(new Autho());
        }
    }
}
