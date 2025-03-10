using Microsoft.AspNetCore.Mvc;
using NetCoreAI.Project2.ApiConsumeUI.Dtos;
using Newtonsoft.Json;

namespace NetCoreAI.Project2.ApiConsumeUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomerController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> CustomerList()
        {
            var client = _httpClientFactory.CreateClient();
            var reponseMessage = await client.GetAsync("https://localhost:7224/api/Customers");
            if (reponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await reponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCustomerDto>>(jsonData);
                return View(values);
            }

            return View();
        }
        [HttpGet]
        public IActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDto createCustomerDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCustomerDto);
            StringContent stringContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var reponseMessage = await client.PostAsync("https://localhost:7224/api/Customers", stringContent);
            if (reponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CustomerList");
            }

            return View();
        }


       
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var client = _httpClientFactory.CreateClient();         
            var reponseMessage = await client.DeleteAsync("https://localhost:7224/api/Customers?id=" + id);
            if (reponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CustomerList");
            }

            return View();
        }
       
        public async Task<IActionResult> UpdateCustomer(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var reponseMessage = await client.GetAsync("https://localhost:7224/api/Customers/GetCustomer?id=" + id);
            if (reponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await reponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetByIdCustomerDto>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerDto updateCustomerDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCustomerDto);
            StringContent stringContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var reponseMessage = await client.PutAsync("https://localhost:7224/api/Customers", stringContent);
            if (reponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CustomerList");
            }

            return View();
        }

    }
}
