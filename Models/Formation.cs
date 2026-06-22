using System;
using System.Collections.Generic;
using System.Text;
namespace MediPlanning.Models
{
    public class Formation
    {
        private string nom_Formation;
        private DateTime date_Formation;
        private string organisme;
        private int duree_Heures;
        public string NomFormation
        {
            get { return nom_Formation; }
            set { nom_Formation = value; }
        }
        public DateTime DateFormation
        {
            get { return date_Formation; }
            set { date_Formation = value; }
        }
        public string Organisme
        {
            get { return organisme; }
            set { organisme = value; }
        }
        public int DureeHeures
        {
            get { return duree_Heures; }
            set { duree_Heures = value; }
        }
        public Formation(string nom_Formation,
                         DateTime date_Formation,
                         string organisme,
                         int duree_Heures)
        {
            this.nom_Formation = nom_Formation;
            this.date_Formation = date_Formation;
            this.organisme = organisme;
            this.duree_Heures = duree_Heures;
        }
        public void InscrireMedecin()
        {
            Console.WriteLine("Inscription à la formation réussie.");
        }
        public void AnnulerInscription()
        {
            Console.WriteLine("Inscription à la formation annulée.");
        }
    }
}