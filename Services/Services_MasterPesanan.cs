using Microsoft.EntityFrameworkCore;
using My_API.Connection;
using My_API.Interface;

namespace My_API.Services
{
	public class Services_MasterPesanan : IRepository_MasterPesanan
	{
		#region Get Connection Database
		//static IConfiguration AppSettingJSON = (new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build());
		//public static string GetConnection = AppSettingJSON.GetSection("ConnectionStrings").GetValue<string>("DefaultConnection");
		//public static string ConnectionStringDataBase = GetConnection;
		public static ApplicationDBContext DBContext;

		public Services_MasterPesanan(ApplicationDBContext applicationDBContext)
		{
			DBContext = applicationDBContext;
		}
		#endregion

		#region Business Logic
		public async Task<IQueryable> GetAll_MasterPesanan()
		{
			try
			{
				var Data = DBContext.MasterPesanans.OrderBy(x => x.Id).AsNoTracking().AsQueryable();
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
