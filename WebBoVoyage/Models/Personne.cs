using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBoVoyage.Models
{
    [Table("Personnes")]
    public class Personne
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Civilite")]
        public string Civilite { get; set; }

        [Column("Nom")]
        [Required]
        [StringLength(50)]
        public string Nom { get; set; }

        [Column("Prenom")]
        [StringLength(30)]
        public string Prenom { get; set; }

        [Column("Adresse")]
        public string Adresse { get; set; }

        [Column("Telephone")]
        public string Telephone { get; set; }

        [Column("DateNaissance")]
        public DateTime DateNaissance { get; set; }

        [NotMapped]
        public int Age { get; set; }
    }
}