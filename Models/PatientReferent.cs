using System;
using System.Collections.Generic;
using System.Text;
namespace MediPlanning.Models
{
    public class PatientReferent
    {
        private string nom;
        private string prenom;
        private DateTime dateNaissance;
        private string numeroDossier;

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        public DateTime DateNaissance
        {
            get { return dateNaissance; }
            set { dateNaissance = value; }
        }

        public string NumeroDossier
        {
            get { return numeroDossier; }
            set { numeroDossier = value; }
        }

        public PatientReferent(string nom,
                               string prenom,
                               DateTime dateNaissance,
                               string numeroDossier)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.dateNaissance = dateNaissance;
            this.numeroDossier = numeroDossier;
        }

        public void AfficherInfos()
        {
            Console.WriteLine($"{prenom} {nom} - Dossier : {numeroDossier}");
        }
    }
}