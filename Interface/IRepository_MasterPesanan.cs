namespace My_API.Interface
{
	public interface IRepository_MasterPesanan
	{
		Task<IQueryable> GetAll_MasterPesanan();
	}
}
