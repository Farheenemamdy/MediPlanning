using System;
using System.Collections.Generic;
using System.Text;
namespace MediPlanning.Models
{
    public class Planning
    {
        // Attributs
        private DateTime dateJour;
        private int heureDebut;
        private int heureFin;
        private User user;
        private string noteProfessionnelle;

        private List<Creneau> creneaux;

        // Propriétés
        public DateTime DateJour
        {
            get { return dateJour; }
            set { dateJour = value; }
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

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public string NoteProfessionnelle
        {
            get { return noteProfessionnelle; }
            set { noteProfessionnelle = value; }
        }

        public List<Creneau> Creneaux
        {
            get { return creneaux; }
            set { creneaux = value; }
        }

        // Constructeur
        public Planning(
            DateTime dateJour,
            int heureDebut,
            int heureFin,
            User user,
            string noteProfessionnelle)
        {
            this.dateJour = dateJour;
            this.heureDebut = heureDebut;
            this.heureFin = heureFin;
            this.user = user;
            this.noteProfessionnelle = noteProfessionnelle;

            creneaux = new List<Creneau>();
        }

        // Méthodes
        public void AjouterCreneau(Creneau creneau)
        {
            creneaux.Add(creneau);
        }

        public bool VerifierDisponibilite(DateTime date, int heureDebut, int heureFin)
        {
            foreach (Creneau creneau in creneaux)
            {
                bool memeDate = creneau.Date.Date == date.Date;

                bool chevauchement =
                    heureDebut < creneau.HeureFin &&
                    heureFin > creneau.HeureDebut;

                if (memeDate && chevauchement)
                {
                    return false;
                }
            }

            return true;
        }

        public void AfficherPlanning()
        {

            if (creneaux.Count == 0)
            {
                Console.WriteLine("Aucun créneau prévu.");
            }
            else
            {
                foreach (Creneau creneau in creneaux)
                {
                    creneau.TraiterCreneau();
                    Console.WriteLine();
                }
            }
        }
    }
}

    