using System;
using System.Collections.Generic;
using System.Text;
namespace MediPlanning.Models
{ 

public class Consultation : Creneau //Attributs et propriétés//
    {
    private string motif;
    private string patientReferent;

    public string Motif
    {
        get { return motif; }
        set { motif = value; }
    }

    public string PatientReferent
    {
        get { return patientReferent; }
        set { patientReferent = value; }
    }

    public Consultation( //Constructeur//
          DateTime dateConsultation,
          int heureDebut,
          int heureFin,
          string motif,
          string patientReferent)
          : base(dateConsultation, heureDebut, heureFin)
        {
            this.motif = motif;
            this.patientReferent = patientReferent;
        }

        public override void AfficherDetails()
        {
            Console.WriteLine(
                "[CONSULTATION] "
                + Date.ToShortDateString()
                + " | "
                + HeureDebut
                + "h - "
                + HeureFin
                + "h | Motif : "
                + motif
                + " | Patient référent : "
                + patientReferent
            );
        }

        public void Planifier() //Méthodes//
    {
        Console.WriteLine("Consultation planifiée.");
    }

    public void Annuler()
    {
        Console.WriteLine("Consultation annulée.");
    }
}

}