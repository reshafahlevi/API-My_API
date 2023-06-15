using System;
using System.Collections.Generic;

namespace My_API.Models;

public partial class MasterEmployee
{
    public long Id { get; set; }

    public long Nik { get; set; }

    public string? NamaLengkap { get; set; }

    public string? NamaPanggilan { get; set; }

    public string? TempatLahir { get; set; }

    public DateTime? TanggalLahir { get; set; }

    public string? JenisKelamin { get; set; }

    public string? AlamatLengkap { get; set; }

    public string? AlamatDomisili { get; set; }

    public string? NomerTelepon { get; set; }

    public string? Email1 { get; set; }

    public string? Email2 { get; set; }

    public string? Jabatan { get; set; }

    public string UsernameLogin { get; set; } = null!;

    public string PasswordLogin { get; set; } = null!;

    public string HakAkses { get; set; } = null!;

    public bool? IsActive { get; set; }

    public virtual ICollection<MasterTransaksi> MasterTransaksis { get; set; } = new List<MasterTransaksi>();
}
