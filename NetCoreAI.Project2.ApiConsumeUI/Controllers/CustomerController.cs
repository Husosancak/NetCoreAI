using Microsoft.AspNetCore.Mvc;

namespace NetCoreAI.Project2.ApiConsumeUI.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult CustomerList()
        {
            return View();
        }
    }
}
