using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.EnumTypes;

namespace WebApi.DtoModels
{
    public class DtoUser
    {
        public Guid UserID { get; set; }

        public string UserName { get; set; }

        public string UserRole { get; set; }

    }
}