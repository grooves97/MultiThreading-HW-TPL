using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using Newtonsoft.Json;
using NASAApi.Models;

namespace NASAApi
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();

            jokesTextBlock.Text = GetDataAsync().Result;
        }

        private static Task<string> GetDataAsync()
        {
            var client = new WebClient();
            string url = "https://joke3.p.rapidapi.com/v1/joke";
            client.Headers.Add("X-RapidAPI-Host", "joke3.p.rapidapi.com");
            client.Headers.Add("X-RapidAPI-Key", "f1ce2d9953mshdd667e60c5cbb2ep1aee29jsne173a2d2a766");
            client.Headers.Add("accept", "application/json");
            string jsonEvent = client.DownloadString(url);
            var result = JsonConvert.DeserializeObject<RandomJokes>(jsonEvent);

            return Task.FromResult(result.Content);
        }
    }
}
