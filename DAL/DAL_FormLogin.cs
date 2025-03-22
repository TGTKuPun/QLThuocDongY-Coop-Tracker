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
        // 🔹 Trả về `bool` thay vì `DataTable`
        DTO_FormLogin dto_FormLogin;

        public DAL_FormLogin(string username, string password)
        {
            dto_FormLogin = new DTO_FormLogin(username, password);
        }

        public DataTable checkLogin()
        {
            string sql = "SELECT * FROM tb_useraccount WHERE Username = '" + dto_FormLogin.Username + "' AND matkhau = '" + dto_FormLogin.Password + "'";
            return Connection.selectQuery(sql);
        }
    }
}
