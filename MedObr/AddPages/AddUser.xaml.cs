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
using System.Text.RegularExpressions;

namespace MedObr.AddPages
{
    /// <summary>
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Page
    {
        private User _currnetUser = new User();
        public AddUser(User selectedUser)
        {
            InitializeComponent();
            if (selectedUser != null)
                _currnetUser = selectedUser;

            DataContext = _currnetUser;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currnetUser.login))
                errors.AppendLine("1");
            if (string.IsNullOrWhiteSpace(_currnetUser.password))
                errors.AppendLine("1");
            if (string.IsNullOrWhiteSpace(_currnetUser.name))
                errors.AppendLine("1");
            if (string.IsNullOrWhiteSpace(_currnetUser.surname))
                errors.AppendLine("1");
            if (string.IsNullOrWhiteSpace(_currnetUser.lastname))
                errors.AppendLine("1");
            if (string.IsNullOrWhiteSpace(_currnetUser.phone))
                errors.AppendLine("1");
            if (tbBirth.SelectedDate == null)
                errors.AppendLine("1");
            if (string.IsNullOrWhiteSpace(_currnetUser.email))
                errors.AppendLine("1");
            if (tbPass.Text.Length < 8)
                errors.AppendLine("1");
            if (IsTextAllowed3(tbEmail.Text))
                errors.AppendLine("1");
            //tbBirth.DisplayDateStart = DateTime.Now;
            if (errors.Length > 0)
            {
                MessageBox.Show("Ошибка! Проверьте правильность введенных данных");
                return;
            }
            try
            {
                
                User userObj = new User()
                {
                    login = tbLogin.Text,
                    name = tbName.Text,
                    surname = tbSur.Text,
                    lastname = tbLastName.Text,
                    phone = tbPhone.Text,
                    birthDay = Convert.ToDateTime(tbBirth.DisplayDate),
                    email = tbEmail.Text,
                    password = tbPass.Text,
                    id_role = 2
                };
                if (_currnetUser.id == 0)
                    bdEntities.GetContext().User.Add(userObj);

                try
                {
                    _currnetUser.birthDay = tbBirth.DisplayDate;
                    bdEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно обновлены");
                    AppFrame.frameMain.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при изменении данных!",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        public static bool Add_user(string log, string name, string surname, string lastname, string phone, DateTime data, string email, string pass)
        {
            User userObj = new User()
            {
                login = log,
                name = name,
                surname = surname,
                lastname = lastname,
                phone = phone,
                birthDay = data,
                email = email,
                password = pass,
                id_role = 10
            };
            if (userObj == null)
                return false;
            return true;
        }
        private static readonly Regex _regex = new Regex("[А-я]+");
        private static readonly Regex _regex2 = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }
        private static bool IsTextAllowed2(string text)
        {
            return _regex.IsMatch(text);
        }
        private static bool IsTextAllowed3(string text)
        {
            return !_regex2.IsMatch(text);
        }
        private void txbName_TextChanged2(object sender, TextChangedEventArgs e)
        {
            for (int i = 0; i < tbSur.Text.Length; i++)
            {
                if (IsTextAllowed(tbSur.Text[i].ToString()))
                {
                    tbSur.Text = tbSur.Text.Substring(0, tbSur.Text.Length - 1);
                    tbSur.SelectionStart = tbSur.Text.Length;
                    tbSur.SelectionLength = 0;
                }
            }
        }

        private void txbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            for (int i = 0; i < tbName.Text.Length; i++)
            {
                if (IsTextAllowed(tbName.Text[i].ToString()))
                {
                    tbName.Text = tbName.Text.Substring(0, tbName.Text.Length - 1);
                    tbName.SelectionStart = tbName.Text.Length;
                    tbName.SelectionLength = 0;
                }
            }
        }

        private void txbName_TextChanged3(object sender, TextChangedEventArgs e)
        {
            for (int i = 0; i < tbLastName.Text.Length; i++)
            {
                if (IsTextAllowed(tbLastName.Text[i].ToString()))
                {
                    tbLastName.Text = tbLastName.Text.Substring(0, tbLastName.Text.Length - 1);
                    tbLastName.SelectionStart = tbLastName.Text.Length;
                    tbLastName.SelectionLength = 0;
                }
            }
        }

        private void txbName_TextChanged4(object sender, TextChangedEventArgs e)
        {
            for (int i = 0; i < tbPhone.Text.Length; i++)
            {
                if (IsTextAllowed2(tbPhone.Text[i].ToString()))
                {
                    tbPhone.Text = tbPhone.Text.Substring(0, tbPhone.Text.Length - 1);
                    tbPhone.SelectionStart = tbPhone.Text.Length;
                    tbPhone.SelectionLength = 0;
                }
            }
        }
    }
}
