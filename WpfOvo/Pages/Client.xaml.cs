using System.Windows.Controls;
using WpfOvo.Model;

namespace WpfOvo.Pages
{
    /// <summary>
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class Client : Page
    {
        private Users currentUser;
        public Client(Users currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
            LabelText();
        }

        private void LabelText()
        {
            fio.Content = "Добро пожаловать " + currentUser.Surname.ToString() + " " + currentUser.Name.ToString();
        }
    }
}
