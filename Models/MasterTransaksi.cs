using System;
using System.Collections.Generic;

namespace My_API.Models;

public partial class MasterTransaksi
{
    public long Id { get; set; }

    public string KodeTransaksi { get; set; } = null!;

    public string KodePemesanan { get; set; } = null!;

    public string KodeMenu { get; set; } = null!;

    public string NamaPesanan { get; set; } = null!;

    public long JumlahPesanan { get; set; }

    public decimal TotalPembayaran { get; set; }

    public long Nik { get; set; }

    public virtual MasterMenu KodeMenuNavigation { get; set; } = null!;

    public virtual MasterPesanan KodePemesananNavigation { get; set; } = null!;

    public virtual MasterEmployee NikNavigation { get; set; } = null!;
}
