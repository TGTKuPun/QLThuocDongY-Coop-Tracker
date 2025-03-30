using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_FormUser
    {
        public string id_user { get; set; }
        public string hoten { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        public DTO_FormUser(string idUser, string Hoten, string Username, string Email, string Pass) 
        {
            this.id_user = idUser;
            this.hoten = Hoten;
            this.username = Username;
            this.email = Email;
            this.password = Pass;
        }
    }
}
