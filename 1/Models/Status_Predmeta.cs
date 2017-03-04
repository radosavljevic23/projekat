using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace _1.Models
{
    public class Status_Predmeta
    {
        public bool Polozen { get; set; }
        public bool Prijavljen { get; set; }
        [Key]
        public int ID { get; set; }
  
        public virtual Student Student { get; set; }
        public virtual Predmet Predmet { get; set; }
    }
}