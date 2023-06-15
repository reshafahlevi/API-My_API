namespace My_API.Interface
{
	public interface IRepository_MasterTransaksi
	{
		Task<IQueryable> GetAll_MasterTransaksi();
	}
}
