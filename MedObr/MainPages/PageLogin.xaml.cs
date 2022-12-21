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

namespace MedObr.MainPages
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public static int idU = 0;
        public PageLogin()
        {
            InitializeComponent();
        }
        public static bool getUser(string log, string pas)
        {
            var Users = bdEntities.GetContext().User.ToList();
            var userObj = Users.FirstOrDefault(x => x.login == log && x.password == pas);
            if (userObj == null)
                return false;
            return true;
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = AppConnect.modelBd.User.FirstOrDefault(x => x.login == tbLogin.Text && x.password == pbPassword.Password);
                if (userObj == null)
                {
                    Captcha captcha = new Captcha();
                    captcha.ShowDialog();
                }
                else
                {
                    switch (userObj.id_role)
                    {
                        case 1:
                            MessageBox.Show("Здравствуйте, Администратор " + userObj.name + "!",
                            "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            AppFrame.frameMain.Navigate(new MainPages.AdminPages());
                            break;
                        case 2:
                            MessageBox.Show("Здравствуйте, Покупатель " + userObj.name + "!",
                        "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            idU = userObj.id;
                            AppFrame.frameMain.Navigate(new TablePages.Oborud());
                            break;
                        case 3:
                            MessageBox.Show("Здравствуйте, Менеджер " + userObj.name + "!",
                        "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            idU = userObj.id;
                            AppFrame.frameMain.Navigate(new TablePages.Oborud());
                            break;
                        default:
                            MessageBox.Show("Данные не обнаружены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка " + ex.Message.ToString() + "Критическая работа приложения!",
                     "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void Button_Registr(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new AddPages.AddUser(null));
        }

        private void Button_UnAutho(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new TablePages.UnAuthOborudPage());
        }
    }
}
