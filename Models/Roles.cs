using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserAuth.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        
        public string UserName { get; set; } //imagine uptill now UserName is Unique 
        public string RolesName { get; set; }
        //public IList<Users> Users { get; set; }
    }
}