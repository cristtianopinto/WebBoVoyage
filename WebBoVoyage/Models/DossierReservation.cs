using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebBoVoyage.Models
{
    [Table("DossierReservation")]
    public class DossierReservation
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("NumeroUnique")]
        public int NumeroUnique { get; set; }

        [Column("NumeroCarteBancaire")]
        public string NumeroCarteBancaire { get; set; }
        [Column("PrixParPersonne")]
        public decimal PrixParPersonne { get; set; }

        [Column("Prixtotal")]
        public decimal PrixTotal
            {
                get
                {
                    decimal prixTotal = 0;
                    if (this.Participants != null)
                    {
                        foreach (var participant in this.Participants)
                        {
                            prixTotal += (1 - (decimal)participant.Reduction) * PrixParPersonne;
                        }
                    }
                    if (this.Assurances != null)
                    {
                        foreach (var assurance in this.Assurances)
                        {
                            if (assurance.TypeAssurance == TypeAssurance.Annulation)
                            {
                                prixTotal += (decimal)assurance.Montant;
                            }
                        }
                    }
                    return prixTotal;
                }
            }
        [Column("EtatDossierReservation")]
        public EtatDossierReservation EtatDossierReservation { get; set; }

        [Column("RaisonAnnulationDossier")]
        public RaisonAnnulationDossier RaisonAnnulationDossier { get; set; }

        [Column("IdVoyage")]
        public int IdVoyage { get; set; }

        [Column("IdClient")]
        public int IdClient { get; set; }
      
        [ForeignKey("IdVoyage")]
        public  Voyage Voyage { get; set; }

        [ForeignKey("IdClient")]
        public Client Client { get; set; }
        

        public   ICollection<Assurance> Assurances { get; set; }
        public   ICollection<Participant> Participants { get; set; }
    }
    public enum EtatDossierReservation { EnAttente=0, EnCours=1, Refuse=2, Accepte=3}
    public enum RaisonAnnulationDossier {SansAnnulation=0, Client = 1, PlacesInsuffisantes = 2 }
   
}