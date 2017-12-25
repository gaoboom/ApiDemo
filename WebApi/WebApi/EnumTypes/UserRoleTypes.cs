using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApi.EnumTypes
{
    /// <summary>
    /// 用户角色枚举类
    /// </summary>
    public enum UserRoleTypes
    {
        [Description("匿名用户，未获取到用户类别或者默认类别")]
        AnonymousUser =0,
        [Description("常规个人用户")]
        PersonalUser =1,
        [Description("常规企业用户")]
        EnterpriseUser =2

    }
}