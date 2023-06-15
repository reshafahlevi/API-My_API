using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_API.Connection;
using My_API.Interface;
using My_API.Services;

namespace My_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MasterMenuController : ControllerBase
	{
		#region Property
		private readonly ApplicationDBContext DBContext;
		private readonly ILogger<MasterMenuController> Logger;
		//private readonly IRepository_MasterMenu IRep_MasterMenu;
		//private readonly Services_MasterMenu Services_MasterMenu;

		public MasterMenuController(ILogger<MasterMenuController> logger, ApplicationDBContext dbcontext)
		{
			Logger = logger;
			DBContext = dbcontext;
		}
		#endregion

		#region API
		//[HttpGet(Name = "ListMasterMenu"), Produces("application/json")]
		[HttpGet, Route("List"), Produces("application/json")]
		public async Task<IQueryable> GetAll()
		{
			var MasterMenu = new Services_MasterMenu(DBContext);
			var Data = await MasterMenu.GetAll_MasterMenu();
			return Data;
		}
		#endregion
	}
}
