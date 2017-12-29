using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using WebApi.DtoModels;
using WebApi.EnumTypes;

namespace WebApi.Controllers
{
    public class OAuthTestController : ApiController
    {
        // GET api/<controller>
        [Authorize]
        public IEnumerable<string> Get()
        {
            var user = (ClaimsIdentity)User.Identity;
            var a = user.AuthenticationType;
            var b = user.IsAuthenticated;
            var c = user.Name;
            var d = user.FindFirst("UserID").Value;
            
            
            return new string[] { "Hello", "World" };
        }

        [Authorize(Roles = "EnterpriseUser,PersonalUser")]
        public DtoUser GetUserInfoByAccessToken()
        {
            var user = (ClaimsIdentity)User.Identity;
            Guid userId = Guid.Parse(user.FindFirst("UserID").Value);
            DtoUser u = new DtoUser();
            u.UserID = userId;
            u.UserName = user.Name;
            u.UserRole = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            return u;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}