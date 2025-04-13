using System;
using System.Collections.Generic;

namespace Agenda_Raphael_Jupiter.DB;

public partial class Contact
{
    public int Idcontacts { get; set; }

    public string Nom { get; set; } = null!;

    public string? Prenom { get; set; }

    public string? Telephone { get; set; }

    public string? Email { get; set; }
}
