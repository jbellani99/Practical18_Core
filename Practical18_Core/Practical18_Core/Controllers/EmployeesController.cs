using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Practical18_Core.Models;
using Practical18_Core.ViewModel;
using System.Net.Http.Headers;
using System.Text;
using AutoMapper;

namespace Practical18_Core.Controllers
{
    public class EmployeesController : Controller
    {
        private string _url;
        public EmployeesController()
        {

            _url = "https://localhost:7285/api/Employee";


        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            var employees = new List<EmployeeViewModel>();
            HttpResponseMessage response = client.GetAsync(_url).Result;
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                employees = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(apiResponse);
                return View(employees);
            }
            return View();
        }




        [HttpPost]



        public async Task<IActionResult> Create(EmployeeViewModel employee)
        {
            var json = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));




            HttpResponseMessage response = await client.PostAsync(_url, json);



            if (response.IsSuccessStatusCode)
            {

                string responseBody = await response.Content.ReadAsStringAsync();

                return RedirectToAction("Index");
            }
            else
            {

                return StatusCode((int)response.StatusCode);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            HttpClient client = new HttpClient();
            var customers = new EmployeeViewModel();
            HttpResponseMessage response = client.GetAsync($"https://localhost:7285/api/Employee/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                customers = JsonConvert.DeserializeObject<EmployeeViewModel>(response.Content.ReadAsStringAsync().Result);
            }
            return View(customers);
        }



        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeViewModel employee)
        {
            try
            {



                var json = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();



                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));




                var response = await client.PutAsync(_url, json);

                if (response.IsSuccessStatusCode)
                {



                    return RedirectToAction("Index");
                }
                else
                {

                    return StatusCode((int)response.StatusCode);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }



        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                HttpClient client = new HttpClient(); // Make the HTTP DELETE request to the API
                var response = await client.DeleteAsync($"https://localhost:7285/api/Employee/{id}");




                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }



                else
                {
                    return StatusCode((int)response.StatusCode);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }



        }



        [HttpGet]

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                HttpClient client = new HttpClient(); // Make the HTTP DELETE request to the API
                var response = await client.GetAsync($"https://localhost:7285/api/Employee/{id}");



                var employee = new EmployeeViewModel();
                if (response.IsSuccessStatusCode)
                {
                    employee = JsonConvert.DeserializeObject<EmployeeViewModel>(response.Content.ReadAsStringAsync().Result);
                    return View(employee);
                }



                else
                {
                    return StatusCode((int)response.StatusCode);
                }
            }
            catch (Exception ex)
            {



                return StatusCode(500, ex.Message);
            }



        }
    }
}
