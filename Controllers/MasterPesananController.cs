using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_API.Connection;
using My_API.Interface;
using My_API.Services;

namespace My_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MasterPesananController : ControllerBase
	{
		#region Property
		private readonly ApplicationDBContext DBContext;
		private readonly ILogger<MasterPesananController> Logger;
		//private readonly IRepository_MasterPesanan IRep_MasterPesanan;
		//private readonly Services_MasterPesanan Services_MasterPesanan;

		public MasterPesananController(ILogger<MasterPesananController> logger, ApplicationDBContext dbcontext)
		{
			Logger = logger;
			DBContext = dbcontext;
		}
		#endregion

		#region API
		//[HttpGet(Name = "ListMasterPesanan"), Produces("application/json")]
		[HttpGet, Route("List"), Produces("application/json")]
		public async Task<IQueryable> GetAll()
		{
			var MasterPesanan = new Services_MasterPesanan(DBContext);
			var Data = await MasterPesanan.GetAll_MasterPesanan();
			return Data;
		}
		#endregion
	}
}
