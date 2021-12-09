using _19522221_Lab5.Models;
using Microsoft.AspNetCore.Mvc;

namespace _19522221_Lab5.Controllers
{
    public class CongNhanController : Controller
    {
        public IActionResult LietKeCongNhanTheoSoTrieuChung()
        {
            return View();
        }

        public IActionResult ListSoLan(int solan)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(_19522221_Lab5.Models.DataContext)) as DataContext;
            return View(context.sqlListCongNhanSoLan(solan));
        }

      


    }
}
