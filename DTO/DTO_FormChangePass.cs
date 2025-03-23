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

        public DTO_FormChangePass(string email)
        {
            this.Email = email;
        }
    }
}
