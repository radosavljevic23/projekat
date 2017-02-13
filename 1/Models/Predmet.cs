using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _1.Models
{
    public class Predmet
    {
        [Key]
        public string Ime { get; set; }
        
        public int Semestar { get; set; }
        public string Profesor { get; set; }
        public string Smer { get; set; }
    }
}