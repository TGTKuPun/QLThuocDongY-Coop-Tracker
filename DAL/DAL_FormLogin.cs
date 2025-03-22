using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL_FormLogin
    {
        public DTO_FormLogin checkLogin(string username, string password)
        {
            string sql = $"SELECT * FROM tb_useraccount WHERE username = '{username}' AND matkhau = '{password}'";
            DataTable dt = Connection.selectQuery(sql);

            if (dt.Rows.Count > 0)
            {
                return new DTO_FormLogin(
                    dt.Rows[0]["username"].ToString().Trim(),
                    dt.Rows[0]["matkhau"].ToString().Trim(),
                    dt.Rows[0]["email"].ToString().Trim()
                );
            }
            return null;
        }
    }
}
