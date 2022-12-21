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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MedObr.MainPages
{
    /// <summary>
    /// Логика взаимодействия для Captcha.xaml
    /// </summary>
    public partial class Captcha : Window
    {
        DispatcherTimer _timer;
        TimeSpan _time;
        public Captcha()
        {
            InitializeComponent();

            String allowchar = "";
            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
            allowchar += "1,2,3,4,5,6,7,8,9,0";
            char[] a = { ',' };
            String[] ar = allowchar.Split(a);
            String pwd = "";
            string temp = "";
            Random r = new Random();

            for (int i = 0; i < 4; i++)
            {
                temp = ar[(r.Next(0, ar.Length))];
                pwd += temp;
            }
            txcaptcha.Text = pwd;
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            String allowchar = "";
            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
            allowchar += "1,2,3,4,5,6,7,8,9,0";
            char[] a = { ',' };
            String[] ar = allowchar.Split(a);
            String pwd = "";
            string temp = "";
            Random r = new Random();

            for (int i = 0; i < 4; i++)
            {
                temp = ar[(r.Next(0, ar.Length))];
                pwd += temp;
            }
            txcaptcha.Text = pwd;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txBoxCaptcha.Text == txcaptcha.Text)
            {
                this.Close();
                //MainWindow main = new MainWindow();
                //main.Show();
            }
            else
            {
                _time = TimeSpan.FromSeconds(10);

                _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
                {
                    tbTime.Text = _time.ToString("c");

                    if (_time == TimeSpan.Zero)
                    {
                        _timer.Stop();
                        tbTime.IsEnabled = false;
                        obno.IsEnabled = true;
                        vvod.IsEnabled = true;
                    }
                    else
                    {
                        obno.IsEnabled = false;
                        vvod.IsEnabled = false;
                    }

                    _time = _time.Add(TimeSpan.FromSeconds(-1));
                }, Application.Current.Dispatcher);

                _timer.Start();
            }

        }
        public static bool Check_captcha(string captchaText,string yourText)
        {
            if (captchaText == yourText)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
