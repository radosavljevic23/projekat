using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _1.Models
{
    public class Predmet
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Ime { get; set; }
        
        public int Semestar { get; set; }
        public string Profesor { get; set; }

        public int GodinaStudija { get; set; }

        public virtual ICollection<Status_Predmeta> Statusi { get; set; }

    }
}