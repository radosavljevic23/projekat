using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1.Models
{
    public class Administrator
    {
        public string Name { get; set; }
        [Key]
        public string username { get; set; }
        public string Prezime { get; set; }
              
        public string password { get; set; }
    }
}