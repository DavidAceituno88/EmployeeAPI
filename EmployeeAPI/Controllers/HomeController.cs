using EmployeeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbemployeesContext _DBContext;

        public HomeController(DbemployeesContext context)
        {
            _DBContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

      
    }
}
