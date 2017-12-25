using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using WebApi.EnumTypes;
using WebApi.Models;

namespace WebApi
{
    /// <summary>
    /// Token验证
    /// </summary>
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        /// <summary>
        /// 客户端验证
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId = context.Parameters["client_id"];
            string clientSecret = context.Parameters["client_secret"];
            //未获取到ClientId或者ClientSecret，报错返回
            if(string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientSecret))
            {
                context.SetError("invalid_grant", "The ClientId or ClientSecret is incorrect.");
                return;
            }
            //检查ClientId或者ClientSecret是否匹配，不匹配则报错返回
            if (clientId!= "EsbMobile" || clientSecret!= "123456")
            {
                context.SetError("invalid_grant", "The ClientId or ClientSecret is incorrect.");
                return;
            }
            await Task.Factory.StartNew(() => context.Validated());
        }

        /// <summary>
        /// 用户账号密码验证和授权
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
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
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Role, Enum.GetName(typeof(UserRoleTypes),user.UserRole)));
            identity.AddClaim(new Claim("UserID", user.UserID.ToString()));
            context.Validated(identity);
        }

    }
}