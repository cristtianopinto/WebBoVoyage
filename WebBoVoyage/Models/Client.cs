using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBoVoyage.Models
{
    [Table("Clients")]
    public class Client : Personne
    {
        [Column("Email")]
        public string Email { get; set; }
       
    }
}