using System;
using System.Collections.Generic;

namespace Agenda_Raphael_Jupiter.DB;

public partial class Utilisateur
{
    public int Idutilisateurs { get; set; }

    public string Nom { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Mdp { get; set; } = null!;
}
