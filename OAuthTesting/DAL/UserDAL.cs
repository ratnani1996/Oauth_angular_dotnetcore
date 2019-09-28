using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OAuthTesting.DBContext;
using OAuthTesting.Model;
using OAuthTesting.Common;


namespace OAuthTesting.DAL
{
    public class UserDAL
    {
        public readonly UserContext _userContext;
        public UserDAL(UserContext context)
        {
            this._userContext = context;
        }

        public async Task<bool> UserSignup(UserModel user)
        {
            try
            {
                if (!CheckUsername(user.Username))
                {
                    return false;
                }
                byte[] passwordHash, passwordSalt;
                user.Id = new Guid();
                Encryption.CreatePasswordHash(user.Password, out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                this._userContext.User.Add(user);
                await _userContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public bool Login(UserModel user)
        {
            try
            {
                string username = user.Username;
                var data = _userContext.User.FirstOrDefault(x => x.Username == username);
                if(data != null && Encryption.VerifyPassword(user.Password, data.PasswordHash, data.PasswordSalt))
                {
                    return true;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public bool CheckUsername(string username)
        {
            try
            {
                var data = _userContext.User.FirstOrDefault(x => x.Username == username);
                if (data != null)
                    return false;
                else
                    return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return true;
        }
    }
}
