using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_FormLogin
    {   
        public string UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public DTO_FormLogin(string userID, string username, string password, string email)
        {   
            this.UserID = userID;
            this.Username = username;
            this.Password = password;
            this.Email = email;  
        }
    }
}
