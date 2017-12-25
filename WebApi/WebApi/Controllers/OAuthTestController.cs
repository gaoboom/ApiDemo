using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class OAuthTestController : ApiController
    {
        // GET api/<controller>
        [Authorize(Roles = "EnterpriseUser,PersonalUser")]
        public IEnumerable<string> Get()
        {
            var user = User.Identity;
            var a = user.AuthenticationType;
            var b = user.IsAuthenticated;
            var c = user.Name;
            return new string[] { "Hello", "World" };
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