using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BUS
{
    public class BUS_FormLogin
    {
        private DAL_FormLogin dal_FormLogin = new DAL_FormLogin();

        public bool checkLogin(string username, string password, out bool isAdmin)
        {
            isAdmin = false; // Mặc định không phải admin

            // Kiểm tra thông tin đăng nhập
            DataTable result = dal_FormLogin.checkLogin(username, password);
            if (result.Rows.Count > 0)
            {
                // Lấy email từ database dựa vào username
                string email = dal_FormLogin.getEmailByUsername(username).Trim();

                // Debug để kiểm tra email lấy được
                Console.WriteLine("Email lấy được: " + email);

                // So sánh đúng email admin
                if (email.Equals("janedoe_admin@gmail.com", StringComparison.OrdinalIgnoreCase))
                {
                    isAdmin = true;
                }

                return true;
            }

            return false;
        }
    }
}
