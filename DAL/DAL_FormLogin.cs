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
        public DataTable checkLogin(string username, string password)
        {
            string query = "SELECT * FROM tb_useraccount WHERE username = '" + username + "' AND matkhau = '" + password + "'";
            return Connection.selectQuery(query);
        }

        public string getEmailByUsername(string username)
        {
            string query = "SELECT email FROM tb_useraccount WHERE username = '" + username + "'";
            DataTable result = Connection.selectQuery(query);
            if (result.Rows.Count > 0)
            {
                return result.Rows[0]["email"].ToString();
            }
            return null;
        }
    }
}
