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
    public class KhoaTuController : ApiController
    {
        private QLTuSinhEntities db = new QLTuSinhEntities();

        [HttpPost]
        [Route("api/Api_KhoaTu/DanhSachKhoaTu")]
        public dynamic DanhSachKhoaTu(ThamSo thamso)
        {
            dynamic returnedData = null;
            returnedData = db.Database.Connection.Query<dynamic>("Get_DSKhoaTu", new
            {
                makhoatu = thamso.makhoatu
            }
            , commandType: CommandType.StoredProcedure).ToList();
            return returnedData;
        }
    }
}
