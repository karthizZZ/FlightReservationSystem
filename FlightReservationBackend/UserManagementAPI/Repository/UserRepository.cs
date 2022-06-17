using Microsoft.EntityFrameworkCore;
using UserManagementAPI.DbContexts;
using UserManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool AddNewUser(User objUser)
        {
            _db.User.Add(objUser);
            _db.SaveChanges();
            return true;
        }

        public bool ChangePassword(Password objPassword)
        {
            throw new NotImplementedException();
        }

        public bool DeleteExistingUser(int UserID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUserDetails(User objUser)
        {
            if (objUser.UserID != 0)
            {
                User dbUserDetails = _db.User.AsNoTracking().FirstOrDefault(x => x.UserID == objUser.UserID);
                if (dbUserDetails != null)
                {
                    _db.User.Update(objUser);
                    _db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public List<User> GetUserList()
        {
            throw new NotImplementedException();
        }

        public User Login(User UserCred)
        {
            if(UserCred.Email!=null & UserCred.Password != null)
            {
                User dbUserDetails = _db.User.FirstOrDefault(x => x.Email == UserCred.Email 
                && x.IsDeleted==false);
                if (dbUserDetails != null)
                {
                    return dbUserDetails;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
