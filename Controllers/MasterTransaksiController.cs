using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_API.Connection;
using My_API.Interface;
using My_API.Services;

namespace My_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MasterTransaksiController : ControllerBase
	{
		#region Property
		private readonly ApplicationDBContext DBContext;
		private readonly ILogger<MasterTransaksiController> Logger;
		//private readonly IRepository_MasterTransaksi IRep_MasterTransaksi;
		//private readonly Services_MasterTransaksi Services_MasterTransaksi;

		public MasterTransaksiController(ILogger<MasterTransaksiController> logger, ApplicationDBContext dbcontext)
		{
			Logger = logger;
			DBContext = dbcontext;
		}
		#endregion

		#region API
		//[HttpGet(Name = "ListMasterTransaksi"), Produces("application/json")]
		[HttpGet, Route("List"), Produces("application/json")]
		public async Task<IQueryable> GetAll()
		{
			var MasterTransaksi = new Services_MasterTransaksi(DBContext);
			var Data = await MasterTransaksi.GetAll_MasterTransaksi();
			return Data;
		}
		#endregion
	}
}
