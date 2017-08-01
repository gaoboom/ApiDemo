using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class User
    {
        public Guid UserID { get; set; }

        public string UserName { get; set; }

        public string UserPassword { get; set; }

        /// <summary>
        /// 用户角色，此处应为枚举类型
        /// 0-未分配角色 1-普通用户 2-管理员用户
        /// </summary>
        public int UserRole { get; set; }
    }
}