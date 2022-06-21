using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LEHUUQUAN.Models
{
    public class GioHang
    {
        RapchieuphimDataContext data = new RapchieuphimDataContext();
        public int id { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string tensp { get; set; }
        [Display(Name = "Hình ảnh")]
        public string hinhsp { get; set; }
        [Display(Name = "Giá")]
        public double gia { get; set; }
        [Display(Name = "Số lượng")]
        public int soluong { get; set; }
        [Display(Name = "Thành tiền")]
        public double dthanhtien
        {
            get
            {
                return soluong * gia;
            }
        }
        public GioHang(string id)
        {

            this.id = int.Parse(id);
            var sp = data.LichChieus.Single(n => n.malich == id.ToString());
            tensp = sp.maphim.ToString();
            gia = double.Parse(sp.gia.ToString());
            soluong = 1;

        }
    }
}
