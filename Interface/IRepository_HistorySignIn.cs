using My_API.Additional;
using My_API.Models;
using static My_API.Additional.Payload;

namespace My_API.Interface
{
	public interface IRepository_HistorySignIn
	{
		Task<IQueryable> GetAll_HistorySignIn();
		Task<HistorySignIn> AddData_HistorySignIn(Login Payload);
	}
}
