using System;
using System.Collections.Generic;
using System.Text;
using MediPlanning.Models;

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
