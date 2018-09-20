using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBoVoyage.Models
{
    [Table("Destinations")]
    public class Destination
    {
        [Column("Id")]
        public int Id { get; set; }

        [StringLength(20)]
        [Column("Continent")]
        public string Continent { get; set; }
        
        [StringLength(20)]
        [Column("Pays")]
        public string Pays { get; set; }

        [Column("Region")]
        [StringLength(20)]
        public string Region { get; set; }

        [Column("Description")]
        [StringLength(250)]
        public string Description { get; set; }
    }
}