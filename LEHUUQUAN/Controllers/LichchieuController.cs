using LEHUUQUAN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LEHUUQUAN.Controllers
{
    public class LichchieuController : Controller
    {
        RapchieuphimDataContext data = new RapchieuphimDataContext();
        // GET: Lichchieu
        public ActionResult Index()
        {
            var all_lich = from s in data.LichChieus select s;
            return View(all_lich);
        }
    }
}