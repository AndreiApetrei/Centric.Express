using Microsoft.AspNetCore.Mvc;

namespace CentricExpress.WebApi.Controllers
{
    public class OrderController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return
            View();
        }
    }
}