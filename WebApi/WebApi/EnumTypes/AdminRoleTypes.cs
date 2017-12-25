using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApi.EnumTypes
{
    /// <summary>
    /// 管理员角色枚举类
    /// </summary>
    public enum AdminRoleTypes
    {
        [Description("匿名管理员，未获取到管理员类别或者默认类别")]
        AnonymousAdmin =0,
        [Description("客服")]
        CustomServiceAdmin = 1,
        [Description("超级管理员")]
        SuperAdmin = 9527

    }
}