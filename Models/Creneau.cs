using System;

namespace MediPlanning.Models
{
    public abstract class Creneau
    {
        // Attributs
        private DateTime date;
        private int heureDebut;
        private int heureFin;

        // Propriétés
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public int HeureDebut
        {
            get { return heureDebut; }
            set { heureDebut = value; }
        }

        public int HeureFin
        {
            get { return heureFin; }
            set { heureFin = value; }
        }

        // Constructeur
        public Creneau(DateTime date, int heureDebut, int heureFin)
        {
            this.date = date;
            this.heureDebut = heureDebut;
            this.heureFin = heureFin;
        }

        // Template Method
        public void TraiterCreneau()
        {
            Console.WriteLine("Validation du créneau...");
            AfficherDetails();
            Console.WriteLine("Créneau traité avec succès.");
        }

        // Méthode 
        public abstract void AfficherDetails();
    }
}
