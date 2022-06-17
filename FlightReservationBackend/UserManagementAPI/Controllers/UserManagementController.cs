using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;
using UserManagementAPI.Models.DTO;
using UserManagementAPI.Repository;
using UserManagementAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public readonly ITokenService _tokenService;

        public UserManagementController(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("AddNewUser")]
        public ActionResult<LoginResponsedto> AddNewUser([FromBody]User userDetails)
        {
            var hmac = new HMACSHA512();

            var user = new User
            {
                FirstName = userDetails.FirstName,
                LastName = userDetails.LastName,
                Email = userDetails.Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDetails.Password)),
                PasswordSalt = hmac.Key
            };
            bool IsSuccess =  _userRepository.AddNewUser(user);
            return new LoginResponsedto
            {
                UserName = user.FirstName + "" + user.LastName,
                Email = user.Email,
                UserID = user.UserID,
                IsAdminUser = user.IsAdminUser,
                Token = _tokenService.CreatedToken(user)
            };
        }

        [HttpPost("ChangeUserPassword")]
        public bool ChangeUserPassword([FromBody]Password objPassword)
        {
            bool IsSuccess = _userRepository.ChangePassword(objPassword);
            return IsSuccess;
        }

        [HttpPost("UpdateUserDetails")]
        public bool UpdateUserDetails([FromBody] User UserDetails)
        {
            bool IsSuccess = _userRepository.UpdateUserDetails(UserDetails);
            return IsSuccess;
        }

        [HttpGet("DeleteUser/{UserID}")]
        public bool DeleteUser(int UserID)
        {
            bool IsSuccess = _userRepository.DeleteExistingUser(UserID);
            return IsSuccess;
        }

        [Authorize(Roles ="Admin")]
        [HttpGet("GetUserList")]
        public List<User> GetUserList()
        {
            List<User> objUserList = _userRepository.GetUserList();

            return objUserList;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public ActionResult<LoginResponsedto> Login([FromBody] User UserCredentials)
        {
            User UserProfile = _userRepository.Login(UserCredentials);
            if (UserProfile == null) return Unauthorized();

            var hmac = new HMACSHA512(UserProfile.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(UserCredentials.Password));
            for(int i=0; i<computedHash.Length; i++)
            {
                if (computedHash[i] != UserProfile.PasswordHash[i]) return Unauthorized();
            }
            return new LoginResponsedto
            {
                UserName = UserProfile.FirstName + "" + UserProfile.LastName,
                Email = UserProfile.Email,
                UserID = UserProfile.UserID,
                IsAdminUser = UserProfile.IsAdminUser,
                Token = _tokenService.CreatedToken(UserProfile)
            };           
        }
    }
}
