using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebBoVoyage.Models
{
    public class DossierReservation
    {
            public int Id { get; set; }
            public int NumeroUnique { get; set; }
            public string NumeroCarteBancaire { get; set; }
            public decimal PrixParPersonne { get; set; }
            public decimal PrixTotal
            {
                get
                {
                    decimal prixTotal = 0;
                    foreach (var participant in this.Participants)
                    {
                        prixTotal += (1 - (decimal)participant.Reduction) * PrixParPersonne;
                    }

                    foreach (var assurance in this.Assurances)
                    {
                        if (assurance.TypeAssurance == TypeAssurance.Annulation)
                        {
                            prixTotal += (decimal)assurance.Montant;
                        }
                    }
                    return prixTotal;
                }
            }
            public EtatDossierReservation EtatDossierReservation { get; set; }
            public RaisonAnnulationDossier RaisonAnnulationDossier { get; set; }
            public int VoyageId { get; set; }
            public int ClientId { get; set; }


            [ForeignKey("VoyageId")]
            public virtual Voyage Voyage { get; set; }

            [ForeignKey("ClientId")]
            public virtual Client Client { get; set; }

            public virtual ICollection<Assurance> Assurances { get; set; }
            public virtual ICollection<Participant> Participants { get; set; }
    }


        public enum EtatDossierReservation { EnAttente=0, EnCours=1, Refuse=2, Accepte=3}
        public enum RaisonAnnulationDossier { Client = 1, PlacesInsuffisantes = 2 }
   

}