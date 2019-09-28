using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OAuthTesting.DAL;
using OAuthTesting.DBContext;
using OAuthTesting.Model;

namespace OAuthTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        public readonly UserContext _userContext;
        public UserAuthController(UserContext context)
        {
            this._userContext = context;
        }

        // GET: api/UserAuth
        [HttpGet]
        [Route("/api/UserAuth")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //Get : api/UserAuth/xyz
        [HttpGet]
        [Route("/api/UserAuth/xyz")]
        public IEnumerable<string> GetTemp()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/UserAuth/5
        [HttpGet("{id}", Name = "Get")]
        [Route("/api/UserAuth/{id}")]
        public string Get(int id)
        {
            return "value " + id.ToString();
        }

        // POST: api/UserAuth
        [HttpPost]
        [Route("/api/UserAuth/Signup")]
        public async Task<string> Post([FromBody] UserModel user)
        {
            try
            {
                UserDAL oDal = new UserDAL(this._userContext);
                bool result = await oDal.UserSignup(user);
                if (result == true)
                    return "Success";
                else
                    return "Failure";
            }
            catch(Exception ex)
            {
                return "Failure" + ex.Message;
            }
            
        }
        //POST : api/UserAuth/Login
        [HttpPost]
        [Route("/api/UserAuth/Login")]
        public string PostLogin ([FromBody] UserModel user)
        {
            UserDAL oDal = new UserDAL(_userContext);
            if (oDal.Login(user))
            {
                return "Success";
            }
            else
            {
                return "Failure";
            }

        }

        // PUT: api/UserAuth/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
