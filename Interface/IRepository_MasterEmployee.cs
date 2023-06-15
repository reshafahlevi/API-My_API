using My_API.Additional;
using My_API.Models;

namespace My_API.Interface
{
	public interface IRepository_MasterEmployee
	{
		Task<IQueryable> GetAll_MasterEmployee();
		Task<List<MasterEmployee>> FindEmployeeByUserName(Login ObjectPayload);
	}
}
