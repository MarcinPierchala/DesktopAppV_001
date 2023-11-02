using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
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
        private void SendEmail(string recipientAddress, string subject, string body)
        {
            // Outgoing 
            string mailFrom = "adminserver@op.pl";
            string mailFromDisplayName = "adminserver";
            string mailServer = "smtp.poczta.onet.pl";
            SmtpClient client = new SmtpClient(mailServer);
            client.Port = 587;// 465;
            // Use asusming OAuth authentication (need to create an app password)
            client.Credentials = new NetworkCredential(mailFrom, ApplicationData.MailPass);
            client.EnableSsl = true;
            // Prepare Mail 
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(mailFrom, mailFromDisplayName);
            mail.To.Add(recipientAddress);
            mail.Subject = subject;
            mail.Body = body;
            try
            {
                client.Send(mail);
                mail.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //using (MailMessage mailMessage = new MailMessage())
            //{
            //    mailMessage.From = new MailAddress("adminserver@op.pl");
            //    mailMessage.To.Add(new MailAddress(recipientAddress));
            //    mailMessage.Subject = subject;
            //    mailMessage.Body = body;
            //    mailMessage.IsBodyHtml = true;


            //    using (SmtpClient smtp = new SmtpClient("smtp.poczta.onet.pl"))
            //    {
            //        smtp.UseDefaultCredentials = false;
            //        smtp.Credentials = new NetworkCredential("adminserver@op.pl", ApplicationData.MailPass);
            //        smtp.EnableSsl = true;
            //        smtp.Port = 465;
            //        smtp.EnableSsl= true;
            //        smtp.Send(mailMessage);
            //    }
            //}
        }

        private void btn_sendMail_Click(object sender, RoutedEventArgs e)
        {
            if(this.tb_ext_ip.Text.Length > 0)
            {
                SendEmail("marcin.pierchala@icloud.com", "Ext IP Notification", 
                    "Aktualny adres zewnętrzny servera to: " + this.tb_ext_ip.Text);
            }
            else
            {
                SendEmail("marcin.pierchala@icloud.com", "Ext IP Notification",
                    "Coś poszło nie tak - spróbuj ponownie");
            }
            
        }
    }
}
