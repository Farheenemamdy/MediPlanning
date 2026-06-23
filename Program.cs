using MediPlanning.Data;
using System.Text;
using Spectre.Console;
using System.Globalization;
using MediPlanning.Models;
using MediPlanning.Factories;

// Configuration générale de l'application console.//

Console.OutputEncoding = Encoding.UTF8;

CreneauFactory factory = new CreneauFactory();
bool continuer = true;


// Méthodes de saisie sécurisée avec retour possible au menu.//
static bool SaisirTexte(string message, out string valeur)
{
    Console.Write(message);
    valeur = (Console.ReadLine() ?? "").Trim();

    if (valeur == "0")
    {
        return false;
    }

    return true;
}


static bool SaisirDate(string message, out DateTime date)
{
    date = DateTime.MinValue;

    while (true)
    {
        Console.Write(message);
        string saisie = (Console.ReadLine() ?? "").Trim();

        if (saisie == "0")
        {
            return false;
        }

        if (DateTime.TryParseExact(
            saisie,
            "dd/MM/yyyy",
            null,
            DateTimeStyles.None,
            out date))
        {
            return true;
        }

        Console.WriteLine("Format invalide. Exemple attendu : 10/06/2026");
    }
}


static bool SaisirHeure(string message, out int heure)
{
    heure = 0;

    while (true)
    {
        Console.Write(message);
        string saisie = (Console.ReadLine() ?? "").Trim();

        if (saisie == "0")
        {
            return false;
        }

        if (int.TryParse(saisie, out heure) && heure >= 0 && heure <= 23)
        {
            return true;
        }

        Console.WriteLine("Heure invalide. Entrez une heure entre 0 et 23.");
    }
}

// Menu principal de l'application.//
while (continuer)
{
    AnsiConsole.Clear();

    AnsiConsole.Write(
        new Rule("[bold]© MediPlanning[/]")
            .Centered()
    );

    var panel = new Panel(new Markup(
        "Gestion du planning médical : Consultations, Gardes et Indisponibilités."
    ))
    .Header("[bold]⚕  CENTRE HOSPITALIER LANJAMBES[/]", Justify.Center);

    AnsiConsole.Write(Align.Center(panel));

    string choix = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Sélectionnez une action médicale :")
            .HighlightStyle(new Style(decoration: Decoration.Bold))
            .MoreChoicesText("[grey](Déplacez-vous avec les flèches ↑ ↓)[/]")
            .AddChoices(new[]
            {
                "1. Consulter planning",
                "2. Ajouter consultation",
                "3. Ajouter garde",
                "4. Ajouter indisponibilité",
                "5. Vérifier disponibilité",
                "6. Quitter"
            })
    );

    choix = choix.Substring(0, 1);

    switch (choix)
    {
        case "1": // Consultation du planning principal.//
            AnsiConsole.Clear();

            string nomMedecin =
                FakeDatabase.PlanningPrincipal.User.Prenom
                + " "
                + FakeDatabase.PlanningPrincipal.User.Nom;

            AnsiConsole.Write(
                new Rule("[bold]Planning de " + nomMedecin + "[/]")
                    .Centered()
            );

            var infosPlanning = new Markup(
                "[bold]Médecin :[/] " + nomMedecin +
                "\n[bold]Note :[/] " + FakeDatabase.PlanningPrincipal.NoteProfessionnelle
            );

            var planningPanel = new Panel(
                Align.Center(infosPlanning)
            )
            .Header("[bold]Informations du planning[/]", Justify.Center);

            AnsiConsole.Write(Align.Center(planningPanel));

            Console.WriteLine();

            FakeDatabase.PlanningPrincipal.AfficherPlanning();

            Console.WriteLine();

            var infosEffectifs = new Markup(
                "[bold]Médecins :[/] " + FakeDatabase.Medecins.Count +
                "\n[bold]Internes :[/] " + FakeDatabase.Internes.Count +
                "\n[bold]Seniors :[/] " + FakeDatabase.Seniors.Count
            );

            var effectifsPanel = new Panel(
                Align.Center(infosEffectifs)
            )
            .Header("[bold]Effectifs médicaux[/]", Justify.Center);

            AnsiConsole.Write(Align.Center(effectifsPanel));

            Console.WriteLine();
            AnsiConsole.MarkupLine("[grey]Appuyez sur une touche pour revenir au menu...[/]");
            Console.ReadKey();

            break;

        case "2": // Ajout d'une consultation via la factory.//
            AnsiConsole.Clear();

            AnsiConsole.Write(
                new Rule("[bold]Ajouter une consultation[/]")
                    .Centered()
            );

            var consultationPanel = new Panel(new Markup(
                "[grey]Tapez 0 à tout moment pour revenir au menu.[/]"
            ))
            .Header("[bold]Nouvelle consultation[/]", Justify.Center);

            AnsiConsole.Write(Align.Center(consultationPanel));

            Console.WriteLine();

            if (!SaisirDate("Date de consultation (format jj/mm/aaaa) : ", out DateTime dateConsultation))
            {
                break;
            }

            if (!SaisirHeure("Heure de début : ", out int heureDebut))
            {
                break;
            }

            if (!SaisirHeure("Heure de fin : ", out int heureFin))
            {
                break;
            }

            if (!SaisirTexte("Motif : ", out string motif))
            {
                break;
            }

            if (!SaisirTexte("Patient référent : ", out string patientReferent))
            {
                break;
            }

            Creneau nouvelleConsultation = factory.CreerCreneau(
                "consultation",
                dateConsultation,
                heureDebut,
                heureFin,
                motif,
                patientReferent
            );

            FakeDatabase.PlanningPrincipal.AjouterCreneau(nouvelleConsultation);

            Console.WriteLine();
            AnsiConsole.MarkupLine("[green]Consultation ajoutée avec succès.[/]");
            Console.WriteLine();
            AnsiConsole.MarkupLine("[grey]Appuyez sur une touche pour revenir au menu...[/]");
            Console.ReadKey();

            break;

        case "3": // Ajout d'une garde via la factory.//
            AnsiConsole.Clear();

            AnsiConsole.Write(
                new Rule("[bold]Ajouter une garde[/]")
                    .Centered()
            );

            var gardePanel = new Panel(new Markup(
                "[grey]Tapez 0 à tout moment pour revenir au menu.[/]"
            ))
            .Header("[bold]Nouvelle garde[/]", Justify.Center);

            AnsiConsole.Write(Align.Center(gardePanel));

            Console.WriteLine();

            if (!SaisirDate("Date de garde (format jj/mm/aaaa) : ", out DateTime dateGarde))
            {
                break;
            }

            if (!SaisirHeure("Heure de début : ", out int heureDebutG))
            {
                break;
            }

            if (!SaisirHeure("Heure de fin : ", out int heureFinG))
            {
                break;
            }

            if (!SaisirTexte("Type de garde (Jour/Nuit) : ", out string typeGarde))
            {
                break;
            }

            Creneau nouvelleGarde = factory.CreerCreneau(
                "garde",
                dateGarde,
                heureDebutG,
                heureFinG,
                typeGarde
            );

            FakeDatabase.PlanningPrincipal.AjouterCreneau(nouvelleGarde);

            Console.WriteLine();
            AnsiConsole.MarkupLine("[green]Garde ajoutée avec succès.[/]");
            Console.WriteLine();
            AnsiConsole.MarkupLine("[grey]Appuyez sur une touche pour revenir au menu...[/]");
            Console.ReadKey();

            break;

        case "4": // Ajout d'une indisponibilité via la factory.//
            AnsiConsole.Clear();

            AnsiConsole.Write(
                new Rule("[bold]Ajouter une indisponibilité[/]")
                    .Centered()
            );

            var indisponibilitePanel = new Panel(new Markup(
                "[grey]Tapez 0 à tout moment pour revenir au menu.[/]"
            ))
            .Header("[bold]Nouvelle indisponibilité[/]", Justify.Center);

            AnsiConsole.Write(Align.Center(indisponibilitePanel));

            Console.WriteLine();

            if (!SaisirDate("Date de l'indisponibilité (format jj/mm/aaaa) : ", out DateTime dateIndispo))
            {
                break;
            }

            if (!SaisirHeure("Heure de début : ", out int heureDebutI))
            {
                break;
            }

            if (!SaisirHeure("Heure de fin : ", out int heureFinI))
            {
                break;
            }

            if (!SaisirTexte("Raison : ", out string raison))
            {
                break;
            }

            Creneau nouvelleIndisponibilite = factory.CreerCreneau(
                "indisponibilite",
                dateIndispo,
                heureDebutI,
                heureFinI,
                raison
            );

            FakeDatabase.PlanningPrincipal.AjouterCreneau(nouvelleIndisponibilite);

            Console.WriteLine();
            AnsiConsole.MarkupLine("[green]Indisponibilité ajoutée avec succès.[/]");
            Console.WriteLine();
            AnsiConsole.MarkupLine("[grey]Appuyez sur une touche pour revenir au menu...[/]");
            Console.ReadKey();

            break;

        case "5": // Vérification des conflits de créneaux.//
            AnsiConsole.Clear();

            AnsiConsole.Write(
                new Rule("[bold]Vérifier disponibilité[/]")
                    .Centered()
            );

            var disponibilitePanel = new Panel(new Markup(
                "[grey]Tapez 0 à tout moment pour revenir au menu.[/]"
            ))
            .Header("[bold]Recherche de disponibilité[/]", Justify.Center);

            AnsiConsole.Write(Align.Center(disponibilitePanel));

            Console.WriteLine();

            if (!SaisirDate("Date à vérifier (format jj/mm/aaaa) : ", out DateTime dateVerif))
            {
                break;
            }

            if (!SaisirHeure("Heure de début : ", out int heureDebutVerif))
            {
                break;
            }

            if (!SaisirHeure("Heure de fin : ", out int heureFinVerif))
            {
                break;
            }

            bool disponible = FakeDatabase.PlanningPrincipal.VerifierDisponibilite(
                dateVerif,
                heureDebutVerif,
                heureFinVerif
            );

            Console.WriteLine();

            if (disponible)
            {
                AnsiConsole.MarkupLine("[green]Le médecin est disponible sur ce créneau.[/]");
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Le médecin n'est pas disponible sur ce créneau.[/]");
            }

            Console.WriteLine();
            AnsiConsole.MarkupLine("[grey]Appuyez sur une touche pour revenir au menu...[/]");
            Console.ReadKey();

            break;

        case "6": // Fermeture de l'application.//
            continuer = false;
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[bold]Fermeture de MediPlanning...[/]");
            break;

        default:
            AnsiConsole.MarkupLine("[red]Choix invalide.[/]");
            Console.ReadKey();
            break;
    }
}