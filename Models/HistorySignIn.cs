using System;
using System.Collections.Generic;

namespace My_API.Models;

public partial class HistorySignIn
{
    public long Id { get; set; }

    public long? Nik { get; set; }

    public DateTime? LastLogged { get; set; }
}
