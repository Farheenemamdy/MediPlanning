using System;
using System.Collections.Generic;
using System.Text;
namespace MediPlanning.Models
{
    public class Senior : User
    {
        private int experience;
        private string responsabilite;
        private string servicePrincipal;

        public int Experience
        {
            get { return experience; }
            set { experience = value; }
        }

        public string Responsabilite
        {
            get { return responsabilite; }
            set { responsabilite = value; }
        }

        public string ServicePrincipal
        {
            get { return servicePrincipal; }
            set { servicePrincipal = value; }
        }

        public Senior(
            string nom,
            string prenom,
            string numRegistreNational,
            string telephone,
            string email,
            int experience,
            string responsabilite,
            string servicePrincipal)
            : base(nom, prenom, numRegistreNational, telephone, email)
        {
            this.experience = experience;
            this.responsabilite = responsabilite;
            this.servicePrincipal = servicePrincipal;
        }

        public void SuperviserInterne()
        {
            Console.WriteLine($"Le senior {Prenom} {Nom} supervise un interne.");
        }

        public void ValiderPlanning()
        {
            Console.WriteLine($"Le senior {Prenom} {Nom} valide un planning.");
        }

        public override void AfficherProfil()
        {
            Console.WriteLine($"Senior : {Prenom} {Nom} - {experience} ans d'expérience - {servicePrincipal}");
        }
    }
}