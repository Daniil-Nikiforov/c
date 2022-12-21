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


namespace MedObr
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppConnect.modelBd = new bdEntities();

            AppFrame.frameMain = FrmMain;
            FrmMain.Navigate(new MainPages.PageLogin());
        }
        public static bool Connect_bd()
        {
            try
            {
                AppConnect.modelBd = new bdEntities();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }

        private void Frame_ContentRendered(object sender, EventArgs e)
        {
            if (FrmMain.CanGoBack)
                BtnBack.Visibility = Visibility.Visible;
            else
                BtnBack.Visibility = Visibility.Hidden;
        }
        public static bool Check_button_back()
        {
            return false;
        }

    }
}
