using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DesktopAppV_001
{
    /// <summary>
    /// Interaction logic for FindAddress.xaml
    /// </summary>
    public partial class FindAddress : Window
    {
        public FindAddress()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_find_ipp_Click(object sender, RoutedEventArgs e)
        {
            giveMeAnAddress();
        }

        private async Task giveMeAnAddress()
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    //var json = string.Empty;
                    string url = string.Format("http://checkip.dyndns.org/");
                    var json = await wc.DownloadStringTaskAsync(url);
                    //Thread.Sleep(3000);
                    string result = "";
                    foreach (char c in json)
                    {
                        if (c == '.' || Char.IsDigit(c))
                        {
                            result += c;
                        }
                    }
                    tb_ext_ip.Text = result;
                    return;
                }

            }
            catch { return; ; }
        }
    }
}
