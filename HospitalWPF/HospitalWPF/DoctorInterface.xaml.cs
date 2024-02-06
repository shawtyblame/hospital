using HospitalWPF.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace HospitalWPF
{
    /// <summary>
    /// Логика взаимодействия для DoctorInterface.xaml
    /// </summary>
    public partial class DoctorInterface : Window
    {
        public DoctorInterface()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string phone = phoneblock.Text;
            string url = $"https://localhost:7181/getinfo?number={phone}";
            HttpClient httpClient = new HttpClient();
            try
            {
                HttpResponseMessage responceMessage = await httpClient.GetAsync(url);
                string responceBody = await responceMessage.Content.ReadAsStringAsync();
                UserViewModel userViewModel = JsonConvert.DeserializeObject<UserViewModel>(responceBody);
                infoblock.Text = userViewModel.Email;
            }
            catch(HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
