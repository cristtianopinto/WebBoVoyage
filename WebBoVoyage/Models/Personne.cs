﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBoVoyage.Models
{
    
    public abstract class Personne
    {
       
        public int Id { get; set; }        
        public string Civilite { get; set; }        
        public string Nom { get; set; }        
        public string Prenom { get; set; }        
        public string Adresse { get; set; }
        public string Telephone { get; set; }
        public DateTime DateNaissance { get; set; }
        public int Age { get { return DateTime.Today.Year - DateNaissance.Year; } }
    }
}