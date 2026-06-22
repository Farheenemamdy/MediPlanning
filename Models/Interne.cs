using System;
using System.Collections.Generic;
using System.Text;
namespace MediPlanning.Models
{
    public class Interne : User
    {
        private string universite;
        private int anneeEtude;
        private string tuteur;
        private string serviceAffecte;

        public string Universite
        {
            get { return universite; }
            set { universite = value; }
        }

        public int AnneeEtude
        {
            get { return anneeEtude; }
            set { anneeEtude = value; }
        }

        public string Tuteur
        {
            get { return tuteur; }
            set { tuteur = value; }
        }

        public string ServiceAffecte
        {
            get { return serviceAffecte; }
            set { serviceAffecte = value; }
        }

        public Interne(
            string nom,
            string prenom,
            string numRegistreNational,
            string telephone,
            string email,
            string universite,
            int anneeEtude,
            string tuteur,
            string serviceAffecte)
            : base(nom, prenom, numRegistreNational, telephone, email)
        {
            this.universite = universite;
            this.anneeEtude = anneeEtude;
            this.tuteur = tuteur;
            this.serviceAffecte = serviceAffecte;
        }

        public void AssisterConsultation()
        {
            Console.WriteLine($"L'interne {Prenom} {Nom} assiste à une consultation.");
        }

        public void ConsulterFormation()
        {
            Console.WriteLine($"L'interne {Prenom} {Nom} consulte ses formations.");
        }

        public override void AfficherProfil()
        {
            Console.WriteLine($"Interne : {Prenom} {Nom} - Année {anneeEtude} - Université : {universite}");
        }
    }
}