using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeAPI.Models.ViewModels
{
    public class EmployeeVM
    {
        public Employee oEmployee { get; set; }
        public List<SelectListItem> oPosition { get; set; }
    }
}
