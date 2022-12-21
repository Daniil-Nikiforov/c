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
using Microsoft.Win32;
using System.IO;
using System.Text.RegularExpressions;

namespace MedObr.AddPages
{
    /// <summary>
    /// Логика взаимодействия для AddObor.xaml
    /// </summary>
    public partial class AddObor : Page
    {
        private Oborudovanie _currnetObor = new Oborudovanie();
        String imgName = null;
        public AddObor(Oborudovanie selectedOborudovanie)
        {
            InitializeComponent();

            var allProizv = bdEntities.GetContext().Proizvoditel.ToList();
            var allType = bdEntities.GetContext().Type.ToList();
            var allColor = bdEntities.GetContext().Color.ToList();

            CBProizvod.ItemsSource = allProizv;
            CBType.ItemsSource = allType;
            CBColor.ItemsSource = allColor;
            if (selectedOborudovanie != null)
            {
                _currnetObor = selectedOborudovanie;
            }
            DataContext = _currnetObor;
        }

        private void Image_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Image images = new System.Windows.Controls.Image();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (!(bool)openFileDialog1.ShowDialog()) return;
            openFileDialog1.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files(*.png)|*.png";
            openFileDialog1.DefaultExt = ".jpeg";
            imgName = openFileDialog1.FileName;
            ImageSource imageSource = new BitmapImage(new Uri(imgName));
            Image.Source = imageSource;
            _currnetObor.photo = File.ReadAllBytes(imgName);
        }
        //private static readonly Regex regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
        private static readonly Regex regex = new Regex(@"^\d$");
        private static bool IsTextAllowed(string text)
        {
            return !regex.IsMatch(text);
        }
        private void txbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            for (int i = 0; i < tbWeight.Text.Length; i++)
            {
                if (IsTextAllowed(tbWeight.Text[i].ToString()))
                {
                    tbWeight.Text = tbWeight.Text.Substring(0, tbWeight.Text.Length - 1);
                    tbWeight.SelectionStart = tbWeight.Text.Length;
                    tbWeight.SelectionLength = 0;
                }
            }
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            var author = CBProizvod.SelectedItem as Proizvoditel;
            var idauthor = 0;

            if (author != null)
                idauthor = author.id;

            var genre = CBType.SelectedItem as Data.Type;
            var idgenre = 0;

            if (genre != null)
                idgenre = genre.id;

            var pubhouse = CBColor.SelectedItem as Data.Color;
            var idpubhouse = 0;

            if (pubhouse != null)
                idpubhouse = pubhouse.id;

            if (string.IsNullOrWhiteSpace(_currnetObor.name))
                errors.AppendLine("Укажите название книги");

            if (idauthor == 0)
                errors.AppendLine("Укажите автора");

            if (idpubhouse == 0)
                errors.AppendLine("Укажите издательство");

            if (string.IsNullOrWhiteSpace(Convert.ToString(_currnetObor.weight)))
                errors.AppendLine("1");

            //decimal tbWeight = (Convert.ToDecimal(tbWeight.t));

            if (Convert.ToInt32(tbWeight.Text) <= 0)
                errors.AppendLine("1");

            if (string.IsNullOrWhiteSpace(_currnetObor.description))
                errors.AppendLine("1");

            if (idgenre == 0)
                errors.AppendLine("1");

            if (string.IsNullOrWhiteSpace(Convert.ToString(_currnetObor.price)))
                errors.AppendLine("1");
            if (Convert.ToInt32(tbPrice.Text) <= 0)
                errors.AppendLine("1");
            if (_currnetObor.photo == null)
                errors.AppendLine("1");

            if (errors.Length > 0)
            {
                MessageBox.Show("Ошибка! Проверьте правильность введенных данных");
                return;
            }
            try
            {
                Oborudovanie oborObj = new Oborudovanie()//
                {
                    name = tbName.Text,
                    id_proizvoditel = idauthor,
                    id_color = idpubhouse,
                    weight = Convert.ToDouble(tbWeight.Text),
                    description = tbDesc.Text,
                    id_type = idgenre,
                    price = Convert.ToInt32(tbPrice.Text),
                    photo = File.ReadAllBytes(imgName)
                };
                if (_currnetObor.id == 0)
                    bdEntities.GetContext().Oborudovanie.Add(oborObj);

                try
                {
                    _currnetObor.id_proizvoditel = idauthor;
                    _currnetObor.id_color = idpubhouse;
                    _currnetObor.id_type = idgenre;
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
        public static bool Add_obor(string name, int id_proizvod, int id_color, double weight, string desc, int id_type, int price)
        {
            Oborudovanie oborObj = new Oborudovanie()//
            {
                name = name,
                id_proizvoditel = id_proizvod,
                id_color = id_color,
                weight = weight,
                description = desc,
                id_type = id_type,
                price = price,
                //photo = File.ReadAllBytes(imgName)
            };
            if (oborObj == null)
                return false;
            return true;
        }
        private static readonly Regex regex2 = new Regex(@"^\d$");
        private static bool IsTextAllowed2(string text)
        {
            return !regex2.IsMatch(text);
        }
        private void txbName2_TextChanged(object sender, TextChangedEventArgs e)
        {
            for (int i = 0; i < tbPrice.Text.Length; i++)
            {
                if (IsTextAllowed2(tbPrice.Text[i].ToString()))
                {
                    tbPrice.Text = tbPrice.Text.Substring(0, tbPrice.Text.Length - 1);
                    tbPrice.SelectionStart = tbPrice.Text.Length;
                    tbPrice.SelectionLength = 0;
                }
            }
        }
    }
}
