using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for ContactMe.xaml
    /// </summary>
    public partial class ContactMe : Window
    {
        public ContactMe()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_linkedin_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.linkedin.com/in/marcin-pierchala");
        }

        private void btn_GitHub_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/MarcinPierchala");
        }

        private void btn_aboutMePage_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://marcinpierchala.github.io/a_little_about_me/#");
        }
    }
}
