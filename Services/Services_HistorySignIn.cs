using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_API.Additional;
using My_API.Connection;
using My_API.Interface;
using My_API.Models;
using static My_API.Additional.Payload;

namespace My_API.Services
{

	public class Services_HistorySignIn : IRepository_HistorySignIn
	{
		#region Get Connection Database
		//static IConfiguration AppSettingJSON = (new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build());
		//public static string GetConnection = AppSettingJSON.GetSection("ConnectionStrings").GetValue<string>("DefaultConnection");
		//public static string ConnectionStringDataBase = GetConnection;
		public static ApplicationDBContext DBContext;

		public Services_HistorySignIn(ApplicationDBContext applicationDBContext)
		{
			DBContext = applicationDBContext;
		}
		#endregion

		#region Business Logic
		public async Task<IQueryable> GetAll_HistorySignIn()
		{
			try
			{
				var Data = DBContext.HistorySignIns.OrderBy(x => x.Id).AsNoTracking().AsQueryable();
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

		public async Task<HistorySignIn> AddData_HistorySignIn(Login Payload)
		{
			try
			{
				#region Get Data And Insert To Table HistorySignIn
				var Data = await DBContext.MasterEmployees.Where(x => x.UsernameLogin == Payload.Username && x.HakAkses == Payload.HakAkses).FirstOrDefaultAsync();
				DBContext.Database.BeginTransaction();
				var TempInsert = new HistorySignIn
				{
					Nik = Data.Nik,
					LastLogged = DateTime.Now
				};
				DBContext.Add(TempInsert);
				DBContext.Database.CommitTransaction();
				DBContext.SaveChanges();
				#endregion

				return TempInsert;
			}
			catch (NullReferenceException ErrorNullReference)
			{
				DBContext.Database.RollbackTransaction();
				Console.WriteLine(ErrorNullReference.Message);
				throw;
			}
			catch (Exception ErrorException)
			{
				DBContext.Database.RollbackTransaction();
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
