using Microsoft.AspNetCore.Mvc;

namespace Json_file_table.Controllers
{
    public class LocalUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
