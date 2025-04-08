using System;
using System.Collections.Generic;

namespace Agenda_Raphael_Jupiter.DB;

public partial class TodoList
{
    public int IdtodoList { get; set; }

    public string Tache { get; set; } = null!;

    public string? Statut { get; set; }

    public DateTime? DateLimite { get; set; }

    public int UtilisateurId { get; set; }
}
