using System;
using System.Collections.Generic;
using System.Text;
using MediPlanning.Models;

namespace MediPlanning.Data
{
    public static class FakeDatabase
    {
        public static List<Medecin> Medecins { get; private set; }
        public static List<Interne> Internes { get; private set; }
        public static List<Senior> Seniors { get; private set; }
        public static List<PatientReferent> PatientsReferents { get; private set; }

        public static Planning PlanningPrincipal { get; private set; }

        static FakeDatabase()
        {
            Medecins = new List<Medecin>();
            Internes = new List<Interne>();
            Seniors = new List<Senior>();
            PatientsReferents = new List<PatientReferent>();

            InitialiserMedecins();
            InitialiserInternes();
            InitialiserSeniors();
            InitialiserPatientsReferents();

            PlanningPrincipal = new Planning(
                DateTime.Today,
                8,
                18,
                Medecins[0],
                "Planning principal"
            );

            InitialiserCreneaux();
        }
        private static void InitialiserMedecins()
        {
            Medecins.Add(new Medecin(
                "Benali",
                "Sami",
                "85041212345",
                "0477000001",
                "sami.benali@hopital.be",
                "Cardiologie",
                "Médecin",
                "Actif",
                "Cardiologie"
            ));

            Medecins.Add(new Medecin(
                "Martin",
                "Lina",
                "90092354321",
                "0477000002",
                "lina.martin@hopital.be",
                "Urgences",
                "Médecin",
                "Actif",
                "Urgences"
            ));
        }

        private static void InitialiserInternes()
        {
            Internes.Add(new Interne(
                "Diallo",
                "Amir",
                "99031512345",
                "0477000003",
                "amir.diallo@hopital.be",
                "ULB",
                4,
                "Dr Benali",
                "Cardiologie"
            ));

            Internes.Add(new Interne(
                "Rossi",
                "Eva",
                "98072154321",
                "0477000004",
                "eva.rossi@hopital.be",
                "UCLouvain",
                5,
                "Dr Martin",
                "Urgences"
            ));
        }

        private static void InitialiserSeniors()
        {
            Seniors.Add(new Senior(
                "Durand",
                "Paul",
                "78041298765",
                "0477000005",
                "paul.durand@hopital.be",
                15,
                "Chef de service",
                "Cardiologie"
            ));

            Seniors.Add(new Senior(
                "Leroy",
                "Nadia",
                "80092345678",
                "0477000006",
                "nadia.leroy@hopital.be",
                12,
                "Responsable des gardes",
                "Urgences"
            ));
        }

        private static void InitialiserPatientsReferents()
        {
            PatientsReferents.Add(new PatientReferent(
                "Lambert",
                "Noah",
                new DateTime(1995, 4, 12),
                "PAT001"
            ));

            PatientsReferents.Add(new PatientReferent(
                "Petit",
                "Emma",
                new DateTime(1988, 9, 23),
                "PAT002"
            ));
        }

        private static void InitialiserCreneaux()
        {
            Consultation consultation = new Consultation(
                DateTime.Today,
                9,
                10,
                "Contrôle médical",
                "Noah Lambert"
            );

            Garde garde = new Garde(
                DateTime.Today,
                20,
                8,
                "Nuit"
            );

            Indisponibilite indisponibilite = new Indisponibilite(
                DateTime.Today,
                12,
                14,
                "Réunion médicale"
            );

            PlanningPrincipal.AjouterCreneau(consultation);
            PlanningPrincipal.AjouterCreneau(garde);
            PlanningPrincipal.AjouterCreneau(indisponibilite);
        }
    }
}
