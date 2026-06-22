using System;
using System.Collections.Generic;
using System.Text;
namespace MediPlanning.Models
{
    public class Medecin : User
    {
        private string specialite;
        private string grade;
        private string statut;
        private string service;

        public string Specialite
        {
            get { return specialite; }
            set { specialite = value; }
        }

        public string Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public string Statut
        {
            get { return statut; }
            set { statut = value; }
        }

        public string Service
        {
            get { return service; }
            set { service = value; }
        }

        public Medecin(
            string nom,
            string prenom,
            string numRegistreNational,
            string telephone,
            string email,
            string specialite,
            string grade,
            string statut,
            string service)
            : base(nom, prenom, numRegistreNational, telephone, email)
        {
            this.specialite = specialite;
            this.grade = grade;
            this.statut = statut;
            this.service = service;
        }

        public void ConsulterPlanning()
        {
            Console.WriteLine($"Dr {Prenom} {Nom} consulte son planning.");
        }

        public void AjouterDisponibilite()
        {
            Console.WriteLine($"Disponibilité ajoutée pour Dr {Prenom} {Nom}.");
        }

        public override void AfficherProfil()
        {
            Console.WriteLine($"Médecin : Dr {Prenom} {Nom} - {specialite} - {grade}");
        }
    }
}