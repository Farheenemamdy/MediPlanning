using System;
using System.Collections.Generic;
using System.Text;
namespace MediPlanning.Models
{
    public class User
    {
        private string nom; //Attributs//
        private string prenom;
        private string numRegistreNational;
        private string telephone;
        private string email;

        public string Nom //Propriétés//
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        public string NumRegistreNational
        {
            get { return numRegistreNational; }
            set { numRegistreNational = value; }
        }

        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public User( //Constructeur//
            string nom,
            string prenom,
            string numRegistreNational,
            string telephone,
            string email)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.numRegistreNational = numRegistreNational;
            this.telephone = telephone;
            this.email = email;
        }

        public void SeConnecter() //Méthodes//
        {
            Console.WriteLine($"{prenom} {nom} est connecté.");
        }

        public virtual void AfficherProfil()
        {
            Console.WriteLine($"{prenom} {nom}");
        }
    }
}