using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QLTU_SINH.Models;
using System.Data;
using Dapper;
using System.Text;


namespace QLTU_SINH.API
{
    public class PhongNguController : ApiController
    {
        private QLTuSinhEntities db = new QLTuSinhEntities();
        [HttpPost]
        [Route("api/Api_PhongNgu/DanhSachPhongNguTheoGioiTinh")] 
        public dynamic DanhSachPhongNguTheoGioiTinh(ThamSo thamso)
        {
            dynamic returnedData = null;
            returnedData = db.Database.Connection.Query<dynamic>("Get_DSPhongNguTheoGT", new
            {
              gioitinh = thamso.gioitinh,
              tukhoa = thamso.tukhoa
            }
            , commandType: CommandType.StoredProcedure).ToList();
            return returnedData;
        }

        [HttpPost]
        [Route("api/Api_PhongNgu/DanhSachPhongNgu")]
        public dynamic DanhSachPhongNgu(ThamSo thamso)
        {
            dynamic returnedData = null;
            returnedData = db.Database.Connection.Query<dynamic>("Get_DSPhongNgu", new
            {
                maphong = thamso.maphong
            }
            , commandType: CommandType.StoredProcedure).ToList();
            return returnedData;
        }


        [HttpPost]
        [Route("api/Api_PhongNgu/ThemPhongNgu")]
        public dynamic ThemPhongNgu(PHONG_NGU phongngu)
        {
            HttpResponseMessage message = new HttpResponseMessage();
            var check = db.PHONG_NGU.FirstOrDefault(x => x.MA_PHONG == phongngu.MA_PHONG);
            if (check == null)
            {
                try
                {
                    PHONG_NGU danhmuckho = new PHONG_NGU()
                    {
                        MA_PHONG = phongngu.MA_PHONG,
                        TEN_PHONG = phongngu.TEN_PHONG,
                        LOAI_PHONG = phongngu.LOAI_PHONG,
                        KICH_THUOC = phongngu.KICH_THUOC,
                       

                    };
                    db.PHONG_NGU.Add(phongngu);
                    db.SaveChanges();
                    message.StatusCode = HttpStatusCode.OK;
                    message.Content = new StringContent($"Thêm thành công phòng ngủ{phongngu.MA_PHONG}!", Encoding.UTF8, "text/plain");
                }
                catch (Exception ex)
                {
                    message.StatusCode = HttpStatusCode.InternalServerError;
                    message.Content = new StringContent(ex.Message, Encoding.UTF8, "text/plain");
                }
            }
            else
            {
                message.StatusCode = HttpStatusCode.InternalServerError;
                message.Content = new StringContent($"Phòng Ngủ {phongngu.MA_PHONG} đã tồn tại!", Encoding.UTF8, "text/plain");
            }
            return message;
        }
        //
        [HttpPost]
        [Route("api/Api_PhongNgu/SuaPhongNgu")]
        public dynamic SuaPhongNgu(PHONG_NGU phongngu)
        {
            try
            { 
            var query = db.PHONG_NGU.Where(x => x.MA_PHONG == phongngu.MA_PHONG).FirstOrDefault();

            if (query != null)
            {


                query.MA_PHONG = phongngu.MA_PHONG;
                query.TEN_PHONG = phongngu.TEN_PHONG;
                query.LOAI_PHONG = phongngu.LOAI_PHONG;
                query.KICH_THUOC = phongngu.KICH_THUOC;


                db.SaveChanges();

                return query;

            }
                else
                {
                    return Ok("Cập nhật NCC thất bại !");
                }
            }
            catch (Exception ex)
                {
                return BadRequest("Đã xảy ra lỗi ! " + ex);
                }
       
        }
        //
        //[HttpPost]
        //[Route("api/Api_PhongNgu/TimKiemPhongNgu")]
        //public dynamic TimKiemPhongNgu(ThamSo thamso)
        //{
        //    var timkiem = db.PHONG_NGU.Where(x => x.MA_PHONG.Contains(thamso.maphong) || x.TEN_PHONG.Contains(thamso.maphong)).ToList();

        //    return timkiem;
        //    //
        //}
        //[HttpPost]
        //[Route("api/Api_PhongNgu/SearchPhongNgu")]
        //public dynamic SearchPhongNgu(ThamSo thamSo)
        //{
        //    var returnData = db.PHONG_NGU.Where ( x => x.MA_PHONG == )
        //}
        ////
        [HttpPost]
        [Route("api/Api_PhongNgu/XoaPhongNgu")]
        public dynamic XoaPhongNgu(ThamSo thamso)
        {
            var kho = db.PHONG_NGU.Where(x => x.MA_PHONG == thamso.maphong).FirstOrDefault();
            if (kho != null)
            {
                db.PHONG_NGU.Remove(kho);
                db.SaveChanges();
            }
            return Ok("Thành công!");
            //
        }

        [HttpPost]
        [Route("api/Api_PhongNgu/GetDSTuSinhPhongNgu")]
        public dynamic GetDSTuSinhPhongNgu(ThamSo thamso)
        {
            dynamic returnedData = null;
            returnedData = db.Database.Connection.Query<dynamic>("Proc_GetDSTuSinhTrongPhongNgu", new
            {
                maphong = thamso.maphong
            }
            , commandType: CommandType.StoredProcedure).ToList();
            return returnedData;
        }

    }


}
