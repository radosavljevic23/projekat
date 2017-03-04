using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1.Models
{
    public class Student : ApplicationUser
    {

        public string Name { get; set; }

        //[Key]
        //public int brIndexa { get; set; }
        public string Prezime { get; set; }
        
        public int GodinaStudija { get; set; }
        //public string username { get; set; }
        //public string password { get; set; }
        public int Number { get; set; }
        public Pol PolType { get; set; }

        public virtual ICollection<Status_Predmeta> Statusi { get; set; }


    }
   
    public enum Pol
    {
        Male,
        Female
    }
}