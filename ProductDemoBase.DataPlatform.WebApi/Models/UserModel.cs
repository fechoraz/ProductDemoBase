using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductDemoBase.DataPlatform.WebApi.Models
{
    public class UserModel
    {
        public int Id { get; set; }        

        public bool IsMapped { get; set; } = false;

        public string OriginalUserName { get; set; }
    }
}