using LEHUUQUAN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LEHUUQUAN.Controllers
{
    public class RapchieuphimController : Controller
    {
        RapchieuphimDataContext data = new RapchieuphimDataContext();
        // GET: Rapchieuphim
        public ActionResult Index()
        {
            var all_phim = from s in data.Phims select s;
            return View(all_phim);
           
        }
    }
}