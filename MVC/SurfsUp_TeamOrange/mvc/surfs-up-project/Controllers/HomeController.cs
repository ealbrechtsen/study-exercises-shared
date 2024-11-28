using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using surfs_up_project.Models;

namespace surfs_up_project.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
