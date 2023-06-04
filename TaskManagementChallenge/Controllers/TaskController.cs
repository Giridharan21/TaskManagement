using Microsoft.AspNetCore.Mvc;

namespace TaskManagementChallenge.Controllers
{
    public class TaskController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
