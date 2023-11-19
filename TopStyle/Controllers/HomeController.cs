using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TopStyle.Models;
using PagedList;
using PagedList.Mvc;

namespace TopStyle.Controllers
{
    public class HomeController : Controller
    {
        // GET: ShopQuanAo
        dbShopQuanAoDataContext data = new dbShopQuanAoDataContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult ChiTiet()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public List<SanPham> Laymoi(int count)
        {

            return data.SanPhams.OrderByDescending(a => a.NgayCapNhat).Take(count).ToList();
        }
        public List<SanPham> Layhet()
        {

            return data.SanPhams.ToList();
        }
        public ActionResult IndexLayhet(int? Page)
        {
            int pageSize = 12;
            //Tao bien so trang
            int pageNum = (Page ?? 1);
            //Lấy top 5 Album bán chạy nhất
            var layhet = Layhet();
            return PartialView(layhet.ToPagedList(pageNum, pageSize));
        }
        public PartialViewResult IndexLaymoi()
        {
            var quanaomoi = Laymoi(5);
            return PartialView(quanaomoi);
        }
        public PartialViewResult SPTheoLoai(string id)
        {
            var sanpham = from s in data.SanPhams where s.MaLoai == id select s;
            return PartialView(sanpham);
        }
        public PartialViewResult LoaiSP()
        {
            var loaisp = from cd in data.LoaiSanPhams select cd;
            return PartialView(loaisp);
        }
        public ActionResult Shop()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult GioHang()
        {
            return View();
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        public ActionResult DangKy()
        {
            return View();
        }

    }
}