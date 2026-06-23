using System;
using System.Collections.Generic;
using System.Text;
using MediPlanning.Models;

// Factory Method : centralise la création des différents types de créneaux.//

namespace MediPlanning.Factories
{
    public class CreneauFactory
    {
        public Creneau CreerCreneau(
            string type,
            DateTime date,
            int heureDebut,
            int heureFin,
            string information,
            string patientReferent = "")
        {
            
// Détermine l'objet concret créé : Consultation, Garde ou Indisponibilite.//
            switch (type.ToLower())
            {
                case "consultation":
                    return new Consultation(
                        date,
                        heureDebut,
                        heureFin,
                        information,
                        patientReferent
                    );

                case "garde":
                    return new Garde(
                        date,
                        heureDebut,
                        heureFin,
                        information
                    );

                case "indisponibilite":
                    return new Indisponibilite(
                        date,
                        heureDebut,
                        heureFin,
                        information
                    );

                default:
                    throw new ArgumentException("Type de créneau inconnu.");
            }
        }
    }
}
