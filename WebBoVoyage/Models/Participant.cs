using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBoVoyage.Models
{
    [Table("Participants")]
    public class Participant : Personne
    {
        [Column("Reduction")]
        public float Reduction { get; set; }

        /*
        [Column("IdDossierReservation")]
        public int IdDossierReservation { get; set; }
        
        [ForeignKey("IdDossierReservation")]
        public virtual DossierReservation DossierReservation { get; set; }
        */
    }
}