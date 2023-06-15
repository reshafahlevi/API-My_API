using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_API.Additional;
using My_API.Connection;
using My_API.Interface;
using My_API.Models;
using My_API.Services;

namespace My_API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MasterEmployeeController : ControllerBase
	{
		#region Property
		private readonly ApplicationDBContext DBContext;
		private readonly ILogger<MasterEmployeeController> Logger;
		//private readonly IRepository_MasterEmployee IRep_MasterEmployee;
		//private readonly Services_MasterEmployee Services_MasterEmployee;

		public MasterEmployeeController(ILogger<MasterEmployeeController> logger, ApplicationDBContext dbcontext)
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
			var MasterEmployee = new Services_MasterEmployee(DBContext);
			var Data = await MasterEmployee.GetAll_MasterEmployee();
			return Data;
		}

		//[HttpPost(Name = "FindEmployeeForSignIn"), Produces("application/json")]
		[HttpPost, Route("FindEmployeeForSignIn"), Produces("application/json")]
		public async Task<List<MasterEmployee>> FindEmployeeByUserName(Login ObjectPayload)
		{
			var MasterEmployee = new Services_MasterEmployee(DBContext);
			var Result = await MasterEmployee.FindEmployeeByUserName(ObjectPayload);
			return Result;
		}
		#endregion
	}
}
