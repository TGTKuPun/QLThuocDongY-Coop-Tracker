using DTO;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_FormLogin
    {
        public bool checkLogin(string username, string password)
        {
            DAL_FormLogin dal_FormLogin = new DAL_FormLogin(username, password);
            if (dal_FormLogin.checkLogin().Rows.Count > 0)
                return true;
            return false;
        }
    }
}
