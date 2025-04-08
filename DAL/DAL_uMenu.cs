using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_uMenu
    {
        public DataTable getOrderByUserId(string userId)
        {
            string sql = "SELECT RTRIM(id_donhang) AS id_donhang, RTRIM(id_user) AS id_user, trangthai, " +
                         "ngaymua, tongtien, firstname, lastname, " +
                         "RTRIM(email) AS email, RTRIM(phone) AS phone, detail_address, payment_method " +
                         "FROM tb_donhang " +
                         $"WHERE id_user = '{userId}' " +
                         "ORDER BY ngaymua DESC";

            return Connection.selectQuery(sql);
        }

        public DTO_uMenu getOrderByOrderId(string orderId)
        {
            string sql = "SELECT RTRIM(id_donhang) AS id_donhang, RTRIM(id_user) AS id_user, trangthai, " +
                         "ngaymua, tongtien, firstname, lastname, " +
                         "RTRIM(email) AS email, RTRIM(phone) AS phone, detail_address, payment_method " +
                         $"FROM tb_donhang WHERE id_donhang = '{orderId}'";

            DataTable dt = Connection.selectQuery(sql);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new DTO_uMenu(
                    row["id_donhang"].ToString(),
                    row["id_user"].ToString(),
                    row["trangthai"].ToString(),
                    Convert.ToDateTime(row["ngaymua"]),
                    row["tongtien"].ToString(),
                    row["firstname"].ToString(),
                    row["lastname"].ToString(),
                    row["email"].ToString(),
                    row["phone"].ToString(),
                    row["detail_address"].ToString()
                );
            }

            return null;
        }

        public void delOrderByOrderId(string orderID)
        {
            string sql = $"DELETE FROM tb_donhang WHERE id_donhang = '{orderID}'";
            try
            {
                Connection.actionQuery(sql);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the order: " + ex.Message);
            }
        }

        public bool updateOrder(string orderId, string phone, string address)
        {
            string sql = $"UPDATE tb_donhang SET phone = N'{phone}', detail_address = N'{address}' WHERE id_donhang = '{orderId}'";
            try
            {
                Connection.actionQuery(sql);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
