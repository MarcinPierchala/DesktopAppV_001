using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
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
using static System.Net.Mime.MediaTypeNames;

namespace DesktopAppV_001
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            TextBox_01.Text = "CZEŚĆ ĆŚEZC";
            //TextBox_02.Text = "";
            //TB_03.Text = "";
        }
        public void SetLabel_01(string txt)
        {
            string str = txt;
            TextBox_01.Text = txt;
            
        }

        private void SetLabel_01(object sender, TextCompositionEventArgs e)
        {
            TextBox_01.Text = sender.ToString();
        }

        private void SetLabel_01_02(object sender, TextChangedEventArgs e)
        {
            //foreach(char c in TextBox_01.Text) { }
         string str = TextBox_01.Text;
            var str2 = str.ToCharArray().Reverse(); 
            TextBox_02.Text = new string(str2.ToArray());
            string str01 = TextBox_01.Text;
            string str02 = TextBox_02.Text;
            TB_03.Text = str01 + str02;
        }

        private void SetMirrorText_TB_03(object sender, TextChangedEventArgs e)
        {
            //string str01 = TextBox_01.Text;
            //string str02 = TextBox_02.Text;
            //TB_03.Text = str01 + str02;
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure to close the application?","Close_button",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Close();
            }            
        }

        private void btn_about_Click(object sender, RoutedEventArgs e)
        {            
            AboutMe aboutMe = new AboutMe();
            aboutMe.Show();
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            TextBox_01.Text = "";
            //TextBox_02.Text = "";
            //TB_03.Text = "";
        }

        private void btn_contact_Click(object sender, RoutedEventArgs e)
        {
            ContactMe contactMe = new ContactMe();
            contactMe.Show();
        }

        private void btn_weather_Click(object sender, RoutedEventArgs e)
        {
            Weather weather = new Weather();
            weather.Show();
        }

        private void btn_external_ip_Click(object sender, RoutedEventArgs e)
        {
            FindAddress findAddress = new FindAddress();
            findAddress.Show();
        }

        private void btn_learningLetters_Click(object sender, RoutedEventArgs e)
        {
            LearningLetters learningLetters = new LearningLetters();
            learningLetters.Show();
        }
    }
}
