using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_FormChangePass
    {
        DAL_FormChangePass dal_FormChangePass = new DAL_FormChangePass();

        public DTO_FormChangePass checkEmail(string email)
        {
            DTO_FormChangePass emailInfo = dal_FormChangePass.getEmail(email);

            if (emailInfo != null)
            {
                return emailInfo;
            }

            return null;
        }

        public void changePassword (string email, string new_password)
        {
            dal_FormChangePass.changePassword(email, new_password);
        }

    }
}
