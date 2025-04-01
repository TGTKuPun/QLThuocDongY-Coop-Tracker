using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_FormUser
    {
        public string USERID { get; set; }
        public string FULLNAME { get; set; }
        public string USERNAME { get; set; }
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }

        public DTO_FormUser(string user_id, string fullname, string username, string email, string password) 
        {
            this.USERID = user_id;
            this.FULLNAME = fullname;
            this.USERNAME = username;
            this.EMAIL = email;
            this.PASSWORD = password;
        }
    }
}
