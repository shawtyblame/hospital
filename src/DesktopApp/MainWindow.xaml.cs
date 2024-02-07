using HospitalApp.Desktop.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HospitalApp.Desktop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            ApiHelper apiHelper = new ApiHelper();
            var loginModel = new LoginViewModel()
            {
                Login = loginBox.Text,
                Password = passwordBox.Text,
            };
            var json = JsonConvert.SerializeObject(loginModel);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "https://localhost:7181/validate";
            var client = new HttpClient();
            var responce = await client.PostAsync(url, data);
            if(responce.StatusCode == System.Net.HttpStatusCode.OK)
            {
                DoctorInterface doctorInterface = new DoctorInterface();
                doctorInterface.Show();
            }
        }
    }
}
