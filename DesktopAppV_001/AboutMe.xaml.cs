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

namespace DesktopAppV_001
{
    /// <summary>
    /// Interaction logic for AboutMe.xaml
    /// </summary>
    public partial class AboutMe : Window
    {
        public AboutMe()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
