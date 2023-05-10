using QLTU_SINH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QLTU_SINH.API
{
    public class LoginController : ApiController
    {

        public class ThamSo
        {
            public string username { get; set; }
            public string password { get; set; }
        }

        private QLTuSinhEntities db = new QLTuSinhEntities();

        //public dynamic UpdateKhachHang(CCTC_CONG_TY_NEW ct)
        //{
        //    try
        //    {
        //        DateTime? ngaythanhlap = null;

        //        if (ct.NGAY_THANH_LAP != null)
        //        {
        //            ngaythanhlap = xlnt.Xulydatetime2(ct.NGAY_THANH_LAP);
        //        }
        //        var query = db.CCTC_CONG_TY.Where(x => x.MA_CONG_TY == ct.MA_CONG_TY).FirstOrDefault();
        //        if (query != null)
        //        {

        //            query.TEN_CONG_TY = ct.TEN_CONG_TY;
        //            query.CONG_TY_ME = ct.CONG_TY_ME;
        //            query.GHI_CHU = ct.GHI_CHU;
        //            query.NGAY_THANH_LAP = ngaythanhlap;
        //            query.EMAIL = ct.EMAIL;
        //            query.SDT = ct.SDT;
        //            query.MST = ct.MST;
        //            query.LOGO = ct.LOGO;
        //            query.DIA_CHI = ct.DIA_CHI;
        //            query.DIA_CHI_XUAT_HOA_DON = ct.DIA_CHI_XUAT_HOA_DON;
        //            query.LINK_HDDT = ct.LINK_HDDT;
        //            query.USERNAME_HDDT = ct.USERNAME_HDDT;
        //            query.PASSWORD_HDDT = ct.PASSWORD_HDDT;
        //            query.MA_VIET_TAT = ct.MA_VIET_TAT;
        //            db.SaveChanges();
        //            return query;
        //        }
        //        else
        //        {
        //            return Ok("Cập nhật công ty thất bại !");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest("Đã xảy ra lỗi ! " + ex);
        //    }
        //}







    }
}
