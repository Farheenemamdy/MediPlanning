using System;
namespace MediPlanning.Models
{
    public class Indisponibilite : Creneau
    {
        // Attribut spécifique//
        private string raison;

        // Propriété//
        public string Raison
        {
            get { return raison; }
            set { raison = value; }
        }

        // Constructeur//
        public Indisponibilite(
            DateTime date,
            int heureDebutI,
            int heureFinI,
            string raison)
            : base(date, heureDebutI, heureFinI)
        {
            this.raison = raison;
        }

        // Méthode héritée de Creneau//
        public override void AfficherDetails()
        {
            Console.WriteLine(
                "[INDISPONIBILITÉ] "
                + Date.ToShortDateString()
                + " | "
                + HeureDebut
                + "h - "
                + HeureFin
                + "h | Raison : "
                + raison
            );
        }

        public void Ajouter()
        {
            Console.WriteLine("Indisponibilité ajoutée.");
        }

        public void Supprimer()
        {
            Console.WriteLine("Indisponibilité supprimée.");
        }
    }
}