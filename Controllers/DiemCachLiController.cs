using Microsoft.AspNetCore.Mvc;
using _19522221_Lab5.Models;

namespace _19522221_Lab5.Controllers
{
    public class DiemCachLiController : Controller
    {
        public IActionResult ThemDiemCachLi()
        {
            return View();
        }

        [HttpPost]
        public string AddDCL(DiemCachLiModel diemcachly)
        {
            int count;
            DataContext context = HttpContext.RequestServices.GetService(typeof(_19522221_Lab5.Models.DataContext)) as DataContext;
            count = context.sqlInsertDCL(diemcachly);
            if (count == 1)
            {
                return "Thêm Thành Công!";
            }
            return "Thêm thất bại";
        }

        public IActionResult ListDiemCachLi()
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(_19522221_Lab5.Models.DataContext)) as DataContext;
            return View(context.sqlListDiemCachLi());
        }

        [HttpPost]
        public IActionResult ListDiemCachLi_CongNhan(string MaDiemCachLi)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(_19522221_Lab5.Models.DataContext)) as DataContext;
            return View(context.sqlListDiemCachLi_CongNhan(MaDiemCachLi));
        }

        public IActionResult DeleteCN(string id)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(_19522221_Lab5.Models.DataContext)) as DataContext;
            int count = context.sqlDeleteCN(id);
            if (count > 0)
            {
                ViewData["thongbao"] = "Xoá thành công";
            }
            else
            {
                ViewData["thongbao"] = "Xoá không thành công";
            }
            return View();
        }

        public IActionResult ViewCN(string Id)
        {
            DataContext context = HttpContext.RequestServices.GetService(typeof(_19522221_Lab5.Models.DataContext)) as DataContext;
            CongNhanModel cn = context.sqlViewCN(Id);
            ViewData.Model = cn;
            return View();
        }

    }
}
