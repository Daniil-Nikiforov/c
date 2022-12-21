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
using MedObr.Data;

namespace MedObr.TablePages
{
    /// <summary>
    /// Логика взаимодействия для AdminUserPage.xaml
    /// </summary>
    public partial class AdminUserPage : Page
    {
        int maxCount = 0;
        public AdminUserPage()
        {
            InitializeComponent();
            var allUsers = bdEntities.GetContext().User.ToList();
            allUsers.Insert(0, new User
            {
                login = "Все пользователи"
            });
            CBType.ItemsSource = allUsers;
            CBType.SelectedIndex = 0;
            UpdateUsers();
        }
        public static bool find_user(string login)
        {
            var allUser = bdEntities.GetContext().User.ToList();
            var currentUser = allUser.Where(a => a.login.ToLower().Contains(login.ToLower())).ToList();

            if (currentUser.Count > 0)
                return true;
            return false;
        }
        private void UpdateUsers()
        {
            var allUsers = bdEntities.GetContext().User.ToList();
            var currentUser = bdEntities.GetContext().User.ToList();

            if (CBType.SelectedIndex > 0)
            {
                var b = CBType.SelectedItem as User;
                currentUser = currentUser.Where(a => a.login.Equals(b.login)).ToList();
            }

            currentUser = currentUser.Where(a => a.login.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            LViewUsers.ItemsSource = currentUser.ToList();
            LViewUsers.ItemsSource = currentUser;
            switch (CBSort.SelectedIndex)
            {
                case 0:
                    currentUser = currentUser.OrderBy(x => x.login).ToList();
                    break;
                case 1:
                    currentUser = currentUser.OrderBy(x => x.surname).ToList();
                    break;
                case 2:
                    currentUser = currentUser.OrderBy(x => x.birthDay).ToList();
                    break;
            }
            LViewUsers.ItemsSource = currentUser;
            tbCount.Text = LViewUsers.Items.Count.ToString() + "/" + maxCount.ToString();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new AddPages.AddUserAdmin((sender as Button).DataContext as User));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new AddPages.AddUser(null));
        }

        private void CBType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateUsers();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateUsers();
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                bdEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                maxCount = LViewUsers.Items.Count;
                tbCount.Text = LViewUsers.Items.Count.ToString() + "/" + maxCount.ToString();
                LViewUsers.ItemsSource = bdEntities.GetContext().User.ToList();
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateUsers();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var usersForRemoving = LViewUsers.SelectedItems.Cast<User>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить следующие {usersForRemoving.Count()} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    bdEntities.GetContext().User.RemoveRange(usersForRemoving);
                    bdEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    UpdateUsers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
