using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementAPI.Models.DTO
{
    public class LoginResponsedto
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }

        public int UserID { get; set; }

        public bool IsAdminUser { get; set; }
    }
}
