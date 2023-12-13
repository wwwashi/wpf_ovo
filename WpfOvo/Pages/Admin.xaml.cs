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
            fio.Content = "Вы вошли как админ " + currentUser.Surname.ToString() + " " + currentUser.Name.ToString();
        }
    }
}
