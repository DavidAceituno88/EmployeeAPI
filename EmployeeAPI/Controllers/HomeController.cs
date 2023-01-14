using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeAPI.Models;
using EmployeeAPI.Models.ViewModels;
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
            List<Employee> list = _DBContext.Employees.Include(e => e.oPosition).ToList();
            return View(list);
        }

        public IActionResult Employee_Detail()
        {
            EmployeeVM oEmployeeVM = new EmployeeVM()
            {
                oEmployee = new Employee(),
                oPositionList = _DBContext.Positions.Select(position => new SelectListItem()
                {
                    Text = position.PositionDescription,
                    Value = position.IdPosition.ToString()
                }).ToList()
            };

            return View(oEmployeeVM);
        }
        [HttpPost]
        public IActionResult Employee_Detail(EmployeeVM oEmployeeVM)
        {
           if (oEmployeeVM.oEmployee.IdEmployee == 0)
            {
                _DBContext.Employees.Add(oEmployeeVM.oEmployee);
            }
            _DBContext.SaveChanges();

            return RedirectToAction("Index","Home");
        }

    }
}
