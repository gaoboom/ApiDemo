using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using WebApi.Models;

namespace WebApi
{
    /// <summary>
    /// Token验证
    /// </summary>
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.Factory.StartNew(() => context.Validated());
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            await Task.Factory.StartNew(() => context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" }));
            //开始对用户名和密码进行数据校验
            ApiDemoDbContext dbContext = new ApiDemoDbContext();
            User user = dbContext.Users.FirstOrDefault(u => u.UserName == context.UserName && u.UserPassword == context.Password);
            if (user==null)
            {
                //未找到该用户，报错返回
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;

            }
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            identity.AddClaim(new Claim("role", "user"));
            context.Validated(identity);
        }
    }
}