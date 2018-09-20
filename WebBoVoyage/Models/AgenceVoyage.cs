using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBoVoyage.Models
{   [Table ("AgenceVoyage")]
    public class AgenceVoyage
    {
     

            public int Id { get; set; }
            public string Nom { get; set; }
            //[NotMapped]
            //public ICollection<Voyage> Voyages {get;set;}

    }
}
