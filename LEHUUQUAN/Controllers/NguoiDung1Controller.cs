using LEHUUQUAN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LEHUUQUAN.Controllers
{
    public class NguoiDung1Controller : Controller
    {
        // GET: NguoiDung
        RapchieuphimDataContext data = new RapchieuphimDataContext();
        public ActionResult Index()
        {
            var all_sach = from s in data.KhachHangs select s;
            return View(all_sach);


        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(FormCollection collection, KhachHang kh)
        {
            var hoten = collection["hoten"];
            var matkhau = collection["matkhau"];
            var diachi = collection["diachi"];
            var dienthoai = collection["dienthoai"];

            kh.hoten = hoten;
            kh.matkhau = matkhau;
            kh.diachi = diachi;
            kh.dienthoai = dienthoai;

            data.KhachHangs.InsertOnSubmit(kh);
            data.SubmitChanges();

            return RedirectToAction("DangNhap");


            return this.DangKy();
        }

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection collection)
        {
            var dienthoai = collection["dienthoai"];
            KhachHang kh = data.KhachHangs.SingleOrDefault(n => n.dienthoai == dienthoai);
            if (kh != null)
            {
                ViewBag.ThongBao = "Chúc mừng đăng nhập thành công";
                Session["TaiKhoan"] = kh;
            }
            else
            {
                ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return RedirectToAction("Index", "Rapchieuphim");
        }
        // GET: NguoiDung
       
    }
}