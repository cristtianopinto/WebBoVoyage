using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebBoVoyage.Models
{
    [Table("Voyages")]
    public class Voyage   
    {
        [Column("Id")]       
        public int Id { get; set; }

        [Column("DateAller")]        
        public DateTime DateAller { get; set; }

        [Column("DateRetour")]       
        public DateTime DateRetour { get; set; }

        [Column("PlacesDisponibles")]
        public int PlacesDisponibles { get; set; }

        [Column("PrixParPersonne")]
        public decimal PrixParPersonne { get; set; }

        [Column("IdDestination")]
        public int IdDestination{ get; set; }
        [Column("IdAgenceVoyage")]
        public int IdAgenceVoyage { get; set; }

        [ForeignKey("IdDestination")]
        public virtual Destination Destination { get; set; }

        [ForeignKey("IdAgenceVoyage")]
        public AgenceVoyage AgenceVoyage { get; set; }

        public void Reserver(int places)
        {
            this.PlacesDisponibles --;
        }

       
    }

}