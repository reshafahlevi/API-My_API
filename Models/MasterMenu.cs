using System;
using System.Collections.Generic;

namespace My_API.Models;

public partial class MasterMenu
{
    public long Id { get; set; }

    public string KodeMenu { get; set; } = null!;

    public string? NamaMenu { get; set; }

    public string? JenisMenu { get; set; }

    public decimal? HargaSatuan { get; set; }

    public virtual ICollection<MasterPesanan> MasterPesanans { get; set; } = new List<MasterPesanan>();

    public virtual ICollection<MasterTransaksi> MasterTransaksis { get; set; } = new List<MasterTransaksi>();
}
