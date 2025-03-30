using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class DAL_FormUser
    {

        public DataTable getUser()
        {
            string sql = "SELECT RTRIM(id_user) AS id_user, hoten, username, RTRIM(email) AS email, matkhau FROM tb_useraccount";
            return Connection.selectQuery(sql);
        }

        public void addUser(DTO_FormUser user)
        {
            string sql = string.Format("INSERT INTO tb_useraccount(id_user, hoten, username, email, matkhau) VALUES(N'{0}', N'{1}', N'{2}', N'{3}', N'{4}')",
                user.id_user, user.hoten, user.username, user.email, user.password);
            Connection.actionQuery(sql);
        }

        public string generateUserID()
        {
            string sql = "SELECT COUNT(*) FROM tb_useraccount";
            DataTable dt = Connection.selectQuery(sql);

            int count = int.Parse(dt.Rows[0][0].ToString()) + 1; // Đếm số user và tăng lên 1
            return "U" + count.ToString("D3"); // Format thành U001, U002...
        }

        public void delUser(List<string> userIDs)
        {
            string ids = string.Join("','", userIDs); // Chuyển danh sách ID thành chuỗi SQL
            string sql = $"DELETE FROM tb_useraccount WHERE id_user IN ('{ids}')";

            Connection.actionQuery(sql);
        }

        public void updateUser(DTO_FormUser user)
        {
            string sql = string.Format("UPDATE tb_useraccount SET hoten = N'{1}', username = N'{2}', email = N'{3}' WHERE id_user = N'{0}'",
                                        user.id_user, user.hoten, user.username, user.email);
            Connection.actionQuery(sql);
        }

    }
}
