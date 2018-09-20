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

        [Column("NumeroUnique")]
        public int NumeroUnique { get; set; }

        [Column("Reduction")]
        public double Reduction
        {
                get
                {
                    if (Age < 12)
                        return 0.7d;
                    else
                        return 0d;
                }
        }
        [ForeignKey("IdDossierReservation")]
        public int IdDossierReservation { get; set; }

        [ForeignKey("IdDossierReservation")]
        public virtual DossierReservation DossierReservation { get; set; }

    }
}