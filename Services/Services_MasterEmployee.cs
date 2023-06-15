using Microsoft.EntityFrameworkCore;
using My_API.Additional;
using My_API.Connection;
using My_API.Interface;
using My_API.Models;

namespace My_API.Services
{
	public class Services_MasterEmployee : IRepository_MasterEmployee
	{
		#region Get Connection Database
		//static IConfiguration AppSettingJSON = (new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build());
		//public static string GetConnection = AppSettingJSON.GetSection("ConnectionStrings").GetValue<string>("DefaultConnection");
		//public static string ConnectionStringDataBase = GetConnection;
		public static ApplicationDBContext DBContext;

		public Services_MasterEmployee(ApplicationDBContext applicationDBContext)
		{
			DBContext = applicationDBContext;
		}
		#endregion

		#region Business Logic
		public async Task<IQueryable> GetAll_MasterEmployee()
		{
			try
			{
				var Data = DBContext.MasterEmployees.OrderBy(x => x.Id).AsNoTracking().AsQueryable();
				return Data;
			}
			catch (NullReferenceException ErrorNullReference)
			{
				Console.WriteLine(ErrorNullReference.Message);
				throw;
			}
			catch (Exception ErrorException)
			{
				Console.WriteLine(ErrorException.Message);
				throw new ApplicationException(ErrorException.Message);
			}

			finally
			{
			}
		}


		public async Task<List<MasterEmployee>> FindEmployeeByUserName(Login ObjectPayload)
		{
			try
			{
				var Data = await DBContext.MasterEmployees
						   .AsNoTracking()
						   .Where(x => x.UsernameLogin == ObjectPayload.Username && x.PasswordLogin == ObjectPayload.Password && x.HakAkses == ObjectPayload.HakAkses)
						   .Select(x => new MasterEmployee
						   { 
								UsernameLogin = x.UsernameLogin,
								PasswordLogin = x.PasswordLogin,
								HakAkses = x.HakAkses,
								IsActive = x.IsActive
						   })
						   .Distinct().ToListAsync();
				return Data;
			}
			catch (NullReferenceException ErrorNullReference)
			{
				Console.WriteLine(ErrorNullReference.Message);
				throw;
			}
			catch (Exception ErrorException)
			{
				Console.WriteLine(ErrorException.Message);
				throw new ApplicationException(ErrorException.Message);
			}

			finally
			{
			}
		}
		#endregion
	}
}
