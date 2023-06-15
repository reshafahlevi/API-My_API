using Microsoft.AspNetCore.Mvc;
using My_API.Additional;
using My_API.Connection;
using My_API.Models;
using My_API.Services;

namespace My_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HistorySignInController : ControllerBase
	{
		#region Property
		private readonly ApplicationDBContext DBContext;
		private readonly ILogger<HistorySignInController> Logger;
		//private readonly IRepository_HistorySignIn IRep_HistorySignIn;
		//private readonly Services_HistorySignIn Services_HistorySignIn;

		public HistorySignInController(ILogger<HistorySignInController> logger, ApplicationDBContext dbcontext)
		{
			Logger = logger;
			DBContext = dbcontext;
		}
		#endregion

		#region API
		//[HttpGet(Name = "List"), Produces("application/json")]
		[HttpGet, Route("List"), Produces("application/json")]
		public async Task<IQueryable> GetAll()
		{
			var HistorySignIn = new Services_HistorySignIn(DBContext);
			var Data = await HistorySignIn.GetAll_HistorySignIn();
			return Data;
		}

		//[HttpPost(Name = "AddData"), Produces("application/json")]
		[HttpPost, Route("AddData"), Produces("application/json")]
		public async Task<HistorySignIn> AddData(Login Payload)
		{
			var HistorySignIn = new Services_HistorySignIn(DBContext);
			var Data = await HistorySignIn.AddData_HistorySignIn(Payload);
			return Data;
		}
		#endregion
	}
}
