using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_uOrder
    {
        public DataTable getProduct ()
        {
            string sql = "SELECT RTRIM(id_thuoc) AS id_thuoc, ten_thuoc, gia_thuoc, donvitinh, soluong FROM tb_thuoc";

            return Connection.selectQuery(sql);
        }
    }
}
