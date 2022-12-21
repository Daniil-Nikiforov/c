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
namespace MedObr.AddPages
{
    /// <summary>
    /// Логика взаимодействия для Buy.xaml
    /// </summary>
    public partial class Buy : Page
    {
        private Order _currnetOrder = new Order();
        public Buy()
        {
            InitializeComponent(); var allBooks = bdEntities.GetContext().Oborudovanie.ToList();

            CBObor.ItemsSource = allBooks;

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            var book = CBObor.SelectedItem as Oborudovanie;
            var idBook = 0;

            if (book != null)
                idBook = book.id;

            if (book == null)
                errors.AppendLine("Укажите название книги");

            if (errors.Length > 0)
            {
                MessageBox.Show("Ошибка! Проверьте правильность введенных данных");
                return;
            }
            try
            {
                var allBooks = bdEntities.GetContext().Oborudovanie.ToList();
                var allUsers = bdEntities.GetContext().User.ToList();
                var b = CBObor.SelectedItem as User;

                var queryUser1 = from p in allUsers
                                 where p.id == MainPages.PageLogin.idU
                                 select p;

                var us = queryUser1.ToList().First();

                var queryBook2 = from p in allBooks
                                 where p.id == idBook
                                 select p;
                var bo = queryBook2.ToList().First();

                Order orderObj = new Order()
                {
                    id_user = MainPages.PageLogin.idU,
                    id_oborudovanie = idBook,
                    sum = bo.price,
                    count = 1,
                    date = DateTime.Now

                };
                if (_currnetOrder.id == 0)
                    bdEntities.GetContext().Order.Add(orderObj);

                try
                {
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
        public static bool Add_order(int id_obor,int price,int count)
        {
            Order orderObj = new Order()
            {
                id_user = MainPages.PageLogin.idU,
                id_oborudovanie = id_obor,
                sum = price * count,
                count = count,
                date = DateTime.Now

            };
            if(orderObj == null)
                return false;
            return true;
        }
        private void ComboAuthorSelection(object sender, SelectionChangedEventArgs e)
        {


            var curB = CBObor.SelectedItem as Oborudovanie;
            TBPrice.Text = "Стоимость: " + Convert.ToString(curB.price) + " РУБ";

            var allBooks = bdEntities.GetContext().Oborudovanie.ToList();
            var allAuthors = bdEntities.GetContext().Proizvoditel.ToList();

            var curA = CBObor.SelectedItem as Oborudovanie;

            var queryA = from p in allAuthors
                         where p.id == curA.id_proizvoditel
                         select p;
            var currA = queryA.ToList().First();

            TBProizv.Text = "Производитель: " + Convert.ToString(currA.name);
        }
    }
}
