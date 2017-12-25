using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.EnumTypes;

namespace WebApi.Models
{
    public class User
    {
        public Guid UserID { get; set; }

        public string UserName { get; set; }

        public string UserPassword { get; set; }

        /// <summary>
        /// 用户角色，此处应为枚举类型
        /// 0-匿名用户 1-常规个人用户 2-常规企业用户
        /// </summary>
        public UserRoleTypes UserRole { get; set; }
    }
}