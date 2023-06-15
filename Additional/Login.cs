using Microsoft.Build.Framework;

namespace My_API.Additional
{
	public partial class Login
	{
		[Required]
		public string Username { get; set; }
		[Required]
		public string Password { get; set; }
		[Required]
		public string HakAkses { get; set; }
	}

	public partial class ReturnLogin
	{
		public long getStatus { get; set; }
		public string Username { get; set; }
	}

	public partial class PayloadLogin
	{
		public long getStatus { get; set; }
		public string Username { get; set; }
	}
}
