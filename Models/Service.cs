using System;
using System.Collections.Generic;
using System.Text;
namespace MediPlanning.Models
{
    public class Service
    {
        private string nomService;
        private int etageService;
        private string batimentService;

        public string Nom_Service
        {
            get { return nomService; }
            set { nomService = value; }
        }

        public int Etage_Service
        {
            get { return etageService; }
            set { etageService = value; }
        }

        public string Batiment_Service
        {
            get { return batimentService; }
            set { batimentService = value; }
        }

        public Service(
            string nomService,
            int etageService,
            string batimentService)
        {
            this.nomService = nomService;
            this.etageService = etageService;
            this.batimentService = batimentService;
        }

        public void AjouterMedecin()
        {
            Console.WriteLine($"Médecin ajouté au service {nomService}.");
        }

        public void ListerMedecins()
        {
            Console.WriteLine($"Liste des médecins du service {nomService}.");
        }
    }
}