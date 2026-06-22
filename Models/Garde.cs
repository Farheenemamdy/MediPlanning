using System;
using System.Collections.Generic;
using System.Text;
namespace MediPlanning.Models
{
    public class Garde : Creneau
    {
        private string typeGarde;

        public string TypeGarde
        {
            get { return typeGarde; }
            set { typeGarde = value; }
        }

        public Garde(
      DateTime dateGarde,
      int heureDebutG,
      int heureFinG,
      string typeGarde)
      : base(dateGarde, heureDebutG, heureFinG)
        {
            this.typeGarde = typeGarde;
        }

        public override void AfficherDetails()
        {
            Console.WriteLine(
                "[GARDE] "
                + Date.ToShortDateString()
                + " | "
                + HeureDebut
                + "h - "
                + HeureFin
                + "h | Type : "
                + typeGarde
            );
        }

        public void PlanifierGarde()
        {
            Console.WriteLine("Garde planifiée.");
        }

        public void AnnulerGarde()
        {
            Console.WriteLine("Garde annulée.");
        }
    }
}