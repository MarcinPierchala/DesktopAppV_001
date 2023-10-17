using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
    /// Interaction logic for ChatConversation.xaml
    /// </summary>
    public partial class ChatConversation : Window
    {
        public ChatConversation()
        {
            InitializeComponent();
        }

        public async Task ConversationWithChat(string query)
        {
            string myKey = ApplicationData.ChatApiKey;
            string defaultPrompt = query;
            int requestCount = 0;
            txt_conversation.Text = "You: " + query + "\n";

            using(HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", myKey);

                var request = new
                {
                    prompt = defaultPrompt,
                    max_tokens = 2000
                };

                var jsonRequest = Newtonsoft.Json.JsonConvert.SerializeObject(request);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                //TimeSpan delay = TimeSpan.FromSeconds(2);
                //await Task.Delay(delay);
                requestCount++;

                var response = await client.PostAsync("https://api.openai.com/v1/engines/davinci/completions", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    txt_conversation.Text += "ChatGPT: " + responseContent + "\n";
                }
                else
                {
                    txt_conversation.Text += $"Error while requesting: {response.ReasonPhrase}";
                    txt_conversation.Text += "ilość żądań: " + requestCount.ToString() + "\n";
                }
            }
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            string query = txt_query.Text;
            if(e.Key == Key.Return)
            {
                ConversationWithChat(query);
            }
            
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
