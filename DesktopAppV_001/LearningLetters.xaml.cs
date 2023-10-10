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
    /// Interaction logic for LearningLetters.xaml
    /// </summary>
    public partial class LearningLetters : Window
    {
        private int result = 0;

        public LearningLetters()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            List<char> letters = new List<char>();
            var random = new Random();
            for(int l = 97; l <= 122; l++)
            {
                letters.Add(Convert.ToChar(l));
            }
            txt_letter.Text = letters[random.Next(letters.Count)].ToString();
            txt_inp_user_hidden.Focus();

            }

        private void CompareResult()
        {
            if (txt_inp_user_hidden.Text.ToLower() == txt_letter.Text)
            {
                this.btn_start_Click(null, null);
                txt_inp_user_hidden.Text = "";
            }
            else
            {
                txt_inp_user_hidden.Text = "";
            }
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            txt_inp_user_hidden.Text = e.Key.ToString().ToUpper();
            CompareResult();
        }
    }
}
