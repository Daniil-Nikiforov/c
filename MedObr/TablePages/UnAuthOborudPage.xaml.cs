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
    /// Логика взаимодействия для UnAuthOborudPage.xaml
    /// </summary>
    public partial class UnAuthOborudPage : Page
    {
        int maxCount = 0;
        public UnAuthOborudPage()
        {
            InitializeComponent();

            var allTypes = bdEntities.GetContext().Type.ToList();
            allTypes.Insert(0, new Data.Type
            {
                name = "Все"
            });
            CBType.ItemsSource = allTypes;
            CBType.SelectedIndex = 0;

            UpdateBooks();
        }
        private void UpdateBooks()
        {
            var currentBook = bdEntities.GetContext().Oborudovanie.ToList();
            var allBooks = bdEntities.GetContext().Oborudovanie.ToList();

            if (CBType.SelectedIndex > 0)
            {
                var b = CBType.SelectedItem as Data.Type;
                var queryBook1 = from p in allBooks
                                 where p.id_type == b.id
                                 select p;
                currentBook = queryBook1.ToList();
            }

            currentBook = currentBook.Where(a => a.name.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            Lview.ItemsSource = currentBook;
            switch (CBSort.SelectedIndex)
            {
                case 0:
                    currentBook = currentBook.OrderBy(x => x.price).ToList();
                    break;
                case 1:
                    currentBook = currentBook.OrderByDescending(x => x.price).ToList();
                    break;
                case 2:
                    currentBook = currentBook.OrderBy(x => x.name).ToList();
                    break;
                case 3:
                    currentBook = currentBook.OrderByDescending(x => x.name).ToList();
                    break;
            }
            Lview.ItemsSource = currentBook;
            tbCount.Text = Lview.Items.Count.ToString() + "/" + maxCount.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new AddPages.AddObor(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                bdEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                maxCount = Lview.Items.Count;
                tbCount.Text = Lview.Items.Count.ToString() + "/" + maxCount.ToString();
                Lview.ItemsSource = bdEntities.GetContext().Oborudovanie.ToList();
            }
        }

        private void CBType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateBooks();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateBooks();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateBooks();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new AddPages.AddUser(null));
        }
    }
}
