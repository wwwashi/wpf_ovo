using System;
using System.Collections.Generic;
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

namespace WpfOvo.Pages
{
    public partial class AdminEmployeeList : Page
    {
        private Model1 context = new Model1();
        public AdminEmployeeList()
        {
            InitializeComponent();
            var ppl = context.Users.ToList();
            LViewPpl.ItemsSource = ppl;
        }
        private void Selector_OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            var selectedUser = (Users)LViewPpl.SelectedItem;

            // Check if a user is selected:
            if (selectedUser != null)
            {
                // Navigate to the Redact page with the selected user:
                NavigationService.Navigate(new Redact(selectedUser));
            }
            else
            {
                // Handle the case where no user is selected:
                MessageBox.Show("Please select a user to edit.");
            }
        }
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = txtSearch.Text;

            if (searchText.Length == 0)
            {
                var ppl = context.Users.ToList();
                LViewPpl.ItemsSource = ppl;
            }
            else
            {
                if (cmbSorting.SelectedIndex == 0)//по возр
                {
                    switch (cmbFilter.SelectedIndex)
                    {
                        // Должность
                        case 0:
                            var filteredAndSortedPpl = context.Users.Where(u => u.UserRole.NameRole.Contains(searchText))
                                                      .OrderBy(u => u.UserRole.NameRole)
                                                      .ToList();
                            LViewPpl.ItemsSource = filteredAndSortedPpl;
                            break;

                        // Фамилия
                        case 1:
                            var filteredAndSortedPpl1 = context.Users.Where(u => u.Surname.Contains(searchText))
                                                      .OrderBy(u => u.Surname)
                                                      .ToList();
                            LViewPpl.ItemsSource = filteredAndSortedPpl1;
                            break;
                        // Имя
                        case 2:
                            var filteredAndSortedPpl2 = context.Users.Where(u => u.Name.Contains(searchText))
                                                      .OrderBy(u => u.Name)
                                                      .ToList();
                            LViewPpl.ItemsSource = filteredAndSortedPpl2;
                            break;
                        // Отчество
                        case 3:
                            var filteredAndSortedPpl3 = context.Users.Where(u => u.Midname.Contains(searchText))
                                                      .OrderBy(u => u.Midname)
                                                      .ToList();
                            LViewPpl.ItemsSource = filteredAndSortedPpl3;
                            break;
                    }
                }
                if (cmbSorting.SelectedIndex == 1)//по убыв
                {
                    switch (cmbFilter.SelectedIndex)
                    {
                        // Должность
                        case 0:
                            var filteredAndSortedPpl = context.Users.Where(u => u.UserRole.NameRole.Contains(searchText))
                                                      .OrderByDescending(u => u.UserRole.NameRole)
                                                      .ToList();
                            LViewPpl.ItemsSource = filteredAndSortedPpl;
                            break;

                        // Фамилия
                        case 1:
                            var filteredAndSortedPpl1 = context.Users.Where(u => u.Surname.Contains(searchText))
                                                      .OrderByDescending(u => u.Surname)
                                                      .ToList();
                            LViewPpl.ItemsSource = filteredAndSortedPpl1;
                            break;
                        // Имя
                        case 2:
                            var filteredAndSortedPpl2 = context.Users.Where(u => u.Name.Contains(searchText))
                                .OrderByDescending(u => u.Name)
                                .ToList();
                            LViewPpl.ItemsSource = filteredAndSortedPpl2;
                            break;
                        // Отчество
                        case 3:
                            var filteredAndSortedPpl3 = context.Users.Where(u => u.Midname.Contains(searchText))
                                                      .OrderByDescending(u => u.Midname)
                                                      .ToList();
                            LViewPpl.ItemsSource = filteredAndSortedPpl3;
                            break;
                    }

                }
            }
        }

        private void AddEmployer_Click(object sender, RoutedEventArgs e)
        {
            Users newuser = new Users();
            NavigationService.Navigate(new Redact(newuser));
        }
    }
}
