using System;
using System.Collections.Generic;

namespace Agenda_Raphael_Jupiter.DB;

public partial class ReseauxSociaux
{
    public int Id { get; set; }

    public string Plateforme { get; set; } = null!;

    public string? LienProfil { get; set; }

    public int? UtilisateurId { get; set; }
}
