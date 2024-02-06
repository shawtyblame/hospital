using HospitalWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;
using HospitalWeb.ViewModel;
using System.Text;

namespace HospitalWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Registration() => View();
        [HttpGet]
        public IActionResult Hospitalization() => View();

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel registrationViewModel)
        {
            var registration = new RegistrationViewModel()
            {
                Login = registrationViewModel.Login,
                Password = registrationViewModel.Password,
                Name = registrationViewModel.Name,
                Lastname = registrationViewModel.Lastname,
                Surname = registrationViewModel.Surname,
                Email = registrationViewModel.Email,
                PhoneNumber = registrationViewModel.PhoneNumber,
                Gender = registrationViewModel.Gender,
                DateOfBirth = registrationViewModel.DateOfBirth,
                PassportSeries = registrationViewModel.PassportSeries,
                PassportNumber = registrationViewModel.PassportNumber,
                Address = registrationViewModel.Address,
                WorkPlace = registrationViewModel.WorkPlace,
                InsurancePolicyNumber = registrationViewModel.InsurancePolicyNumber,
                InsurancePolicyEndDate = registrationViewModel.InsurancePolicyEndDate,
            };
            var json = JsonConvert.SerializeObject(registration);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "https://localhost:7181/registration";
            using var client = new HttpClient();
            var responce = await client.PostAsync(url, data);
            var result = await responce.Content.ReadAsStringAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Hospitalization(HospitalizationViewModel hospitalizationViewModel)
        {
            var hospitalizationModel = new HospitalizationViewModel()
            {
                PhoneNumber = hospitalizationViewModel.PhoneNumber,
                Departament = hospitalizationViewModel.Departament,
                Condition = hospitalizationViewModel.Condition,
                Target = hospitalizationViewModel.Target,
                Diagnosis = hospitalizationViewModel.Diagnosis,
            };
            var json = JsonConvert.SerializeObject(hospitalizationModel);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "https://localhost:7181/sendto";
            using var client = new HttpClient();
            var responce = await client.PostAsync(url, data);
            var result = await responce.Content.ReadAsStringAsync();
            return View();
        }
    }
}
