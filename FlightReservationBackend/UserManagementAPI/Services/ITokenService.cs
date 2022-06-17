using UserManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementAPI.Services
{
    public interface ITokenService
    {
        string CreatedToken(User userdetails);
    }
}
