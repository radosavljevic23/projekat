using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1.Models
{
    public class Administrator: ApplicationUser
    {
        public string Name { get; set; }
        //[Key]
        //public string korisnickoIme { get; set; }
        //public string Prezime { get; set; }
              
        //public string password { get; set; }
        public virtual ICollection<Student> StudentID { get; set; }
        public virtual ICollection<Predmet> PredmetID { get; set; }
        
        
    }
}