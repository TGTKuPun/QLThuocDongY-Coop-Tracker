using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_FormChangePass
    {
        public DTO_FormChangePass getEmail(string email)
        {
            string sql = $"SELECT email FROM tb_useraccount WHERE email = '{email}'";

            DataTable dt = Connection.selectQuery(sql);

            if (dt.Rows.Count > 0)
            {
                return new DTO_FormChangePass(
                    dt.Rows[0]["email"].ToString().Trim()
                );
            }
            else return null;
        }

        public void changePassword (string email, string new_password)
        {
            string sql = $"UPDATE tb_useraccount SET matkhau = '{new_password}' WHERE email = '{email}' ";

            Connection.actionQuery(sql);
        }
    }
}
