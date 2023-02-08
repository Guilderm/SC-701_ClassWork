using DAL.Interfaces;
using Entities;

namespace DAL.Repositories;
internal class ShipperRepository : GenericRepository<Shipper>, IShipperRepository
	{
	public ShipperRepository(DBContext DBContex) : base(DBContex)
		{
		}
	}

