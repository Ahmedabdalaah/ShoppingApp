using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Areas.Peport.Models;
using ShoppingApp.Repository;
using ShoppingApp.Repository.Base;

namespace ShoppingApp.Areas.Report.Controllers
{
    [Area("Report")]
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var all = _unitOfWork.employees.FindAll();
            return View(all);
        }
    }
}
