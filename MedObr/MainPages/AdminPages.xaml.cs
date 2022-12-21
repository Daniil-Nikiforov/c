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
    /// Логика взаимодействия для AdminPages.xaml
    /// </summary>
    public partial class AdminPages : Page
    {
        public AdminPages()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new TablePages.AdminOborudPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new TablePages.AdminUserPage());
        }
    }
}
