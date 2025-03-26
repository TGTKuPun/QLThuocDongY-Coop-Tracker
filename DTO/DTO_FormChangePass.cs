using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_FormChangePass
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public DTO_FormChangePass(string email, string password)
        {   
            this.Email = email;
            this.Password = password;
        }
    }
}
