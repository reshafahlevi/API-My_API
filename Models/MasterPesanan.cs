using System;
using System.Collections.Generic;

namespace My_API.Models;

public partial class MasterPesanan
{
    public long Id { get; set; }

    public string KodePemesanan { get; set; } = null!;

    public string KodeMenu { get; set; } = null!;

    public string NamaMenu { get; set; } = null!;

    public string NamaPemesan { get; set; } = null!;

    public long JumlahPesanan { get; set; }

    public decimal? HargaSatuan { get; set; }

    public virtual MasterMenu KodeMenuNavigation { get; set; } = null!;

    public virtual ICollection<MasterTransaksi> MasterTransaksis { get; set; } = new List<MasterTransaksi>();
}
