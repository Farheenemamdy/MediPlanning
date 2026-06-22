using System;
using System.Collections.Generic;
using System.Text;
namespace MediPlanning.Models
{

    public class Specialite
    {
        private string nomSpecialite;
        private string descSpecialite;
        private string codeSpecialite;

        public string Nom_Specialite
        {
            get { return nomSpecialite; }
            set { nomSpecialite = value; }
        }

        public string Desc_Specialite
        {
            get { return descSpecialite; }
            set { descSpecialite = value; }
        }

        public string Code_Specialite
        {
            get { return codeSpecialite; }
            set { codeSpecialite = value; }
        }

        public Specialite(
            string nomSpecialite,
            string descSpecialite,
            string codeSpecialite)
        {
            this.nomSpecialite = nomSpecialite;
            this.descSpecialite = descSpecialite;
            this.codeSpecialite = codeSpecialite;
        }

        public void AssignerMedecin()
        {
            Console.WriteLine($"Médecin assigné à la spécialité {nomSpecialite}.");
        }

        public void AfficherSpecialite()
        {
            Console.WriteLine($"Spécialité : {nomSpecialite}");
        }
    }
}