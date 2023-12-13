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
            fio.Content = "Вы вошли как сотрудник " + currentUser.Surname.ToString() + " " + currentUser.Name.ToString();
        }
    }
}
