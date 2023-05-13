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
    public class TuSinhController : ApiController
    {
        private QLTuSinhEntities db = new QLTuSinhEntities();
        [HttpPost]
        [Route("api/Api_TuSinh/DanhSachTuSinh")]
        public dynamic DanhSachTuSinh(ThamSo thamso)
        {
            dynamic returnedData = null;
            returnedData = db.Database.Connection.Query<dynamic>("Get_DSTuSinh", new
            {
                sothe = thamso.sothe,
                hoten = thamso.hoten
            }
            , commandType: CommandType.StoredProcedure).ToList();
            return returnedData;
        }
        [HttpPost]
        [Route("api/Api_TuSinh/ThemTuSinhMoi")]
        public dynamic ThemTuSinhMoi(TU_SINH tusinh)
        {
            HttpResponseMessage message = new HttpResponseMessage();
            var check = db.TU_SINH.FirstOrDefault(x => x.ID == tusinh.ID);
            if (check == null)
            {
                try
                {
                    TU_SINH danhmucts = new TU_SINH()
                    {
                        SO_THE = tusinh.SO_THE,
                        HO_TEN = tusinh.HO_TEN,
                        NAM_SINH = tusinh.NAM_SINH,
                        GIOI_TINH = tusinh.GIOI_TINH,
                        TEN_PHU_HUYNH = tusinh.TEN_PHU_HUYNH,
                        SDT = tusinh.SDT,
                        QUE_QUAN = tusinh.QUE_QUAN,
                        ID_PHONG = tusinh.ID_PHONG,
                        ID_KHOA_TU = tusinh.ID_KHOA_TU,
                       

                    };
                    db.TU_SINH.Add(tusinh);
                    db.SaveChanges();
                    message.StatusCode = HttpStatusCode.OK;
                    message.Content = new StringContent($"Thêm thành công tu sinh{tusinh.SO_THE}!", Encoding.UTF8, "text/plain");
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
                message.Content = new StringContent($"Tu sinh {tusinh.HO_TEN} đã tồn tại!", Encoding.UTF8, "text/plain");
            }
            return message;
        }
        //
        [HttpPost]
        [Route("api/Api_TuSinh/SuaTuSinh")]
        public dynamic SuaTuSinh(TU_SINH tusinh)
        {
            try
            {
                var query = db.TU_SINH.Where(x => x.SO_THE == tusinh.SO_THE).FirstOrDefault();

                if (query != null)
                {


                    query.SO_THE = tusinh.SO_THE;
                    query.HO_TEN = tusinh.HO_TEN;
                    query.NAM_SINH = tusinh.NAM_SINH;
                    query.GIOI_TINH = tusinh.GIOI_TINH;
                    query.TEN_PHU_HUYNH = tusinh.TEN_PHU_HUYNH;
                    query.SDT = tusinh.SDT;
                    query.QUE_QUAN = tusinh.QUE_QUAN;
                    query.ID_PHONG = tusinh.ID_PHONG;
                  


                    db.SaveChanges();

                    return query;

                }
                else
                {
                    return Ok("Cập nhật tu sinh !");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Đã xảy ra lỗi ! " + ex);
            }

        }

        //
        [HttpPost]
        [Route("api/Api_TuSinh/XoaTuSinh")]
        public dynamic XoaTuSinh(ThamSo thamso)
        {
            var ts = db.TU_SINH.Where(x => x.SO_THE == thamso.sothe).FirstOrDefault();
            if (ts != null)
            {
                db.TU_SINH.Remove(ts);
                db.SaveChanges();
            }
            return Ok("Thành công!");
            //
        }

        //
    }
}
