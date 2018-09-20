using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBoVoyage.Models
{
    [Table("Assurance")]
    public class Assurance
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Montant")]
        public decimal Montant { get; set; }

        [Column("TypeAssurance")]
        public TypeAssurance TypeAssurance { get; set; }

        //public virtual ICollection<DossierReservation> DossierReservations { get; set; }
    }
    public enum TypeAssurance { Annulation = 1 }


}
