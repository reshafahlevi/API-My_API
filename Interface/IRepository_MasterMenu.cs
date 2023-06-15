using Microsoft.AspNetCore.Mvc;

namespace My_API.Interface
{
	public interface IRepository_MasterMenu
	{
		Task<IQueryable> GetAll_MasterMenu();
	}
}
