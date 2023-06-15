using My_API.Models;

namespace My_API.Additional
{
	public partial class Payload
    {

		public class PayloadAddHistorySignIn
		{
			//public long Id { get; set; }

			//public long? Nik { get; set; }

			public string UsernameLogin { get; set; }
			public DateTime? LastLogged { get; set; }
		}

		public class PayloadAddMasterMenu
        {
            public long Id { get; set; }

            public string KodeMenu { get; set; } = null!;

            public string? NamaMenu { get; set; }

            public string? JenisMenu { get; set; }

            public decimal? HargaSatuan { get; set; }
        }

        public class PayloadUpdateMasterMenu
        {
            public long Id { get; set; }

            public string KodeMenu { get; set; } = null!;

            public string? NamaMenu { get; set; }

            public string? JenisMenu { get; set; }

            public decimal? HargaSatuan { get; set; }

            public virtual ICollection<MasterPesanan> MasterPesanans { get; set; } = new List<MasterPesanan>();

            public virtual ICollection<MasterTransaksi> MasterTransaksis { get; set; } = new List<MasterTransaksi>();
        }
    }
}

