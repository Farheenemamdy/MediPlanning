using System;
using System.Collections.Generic;
using System.Text;
namespace MediPlanning.Models
{
    public class SalleConsultation
    {
        private int numSalleC;
        private int etageSalleC;
        private string batimentSalleC;

        public int Num_Salle_C
        {
            get { return numSalleC; }
            set { numSalleC = value; }
        }

        public int Etage_Salle_C
        {
            get { return etageSalleC; }
            set { etageSalleC = value; }
        }

        public string Batiment_Salle_C
        {
            get { return batimentSalleC; }
            set { batimentSalleC = value; }
        }

        public SalleConsultation(
            int numSalleC,
            int etageSalleC,
            string batimentSalleC)
        {
            this.numSalleC = numSalleC;
            this.etageSalleC = etageSalleC;
            this.batimentSalleC = batimentSalleC;
        }

        public void EstDisponible()
        {
            Console.WriteLine($"La salle {numSalleC} est disponible.");
        }

        public void AffecterMedecin()
        {
            Console.WriteLine($"Médecin affecté à la salle {numSalleC}.");
        }
    }
}