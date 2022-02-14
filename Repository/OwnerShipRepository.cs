using DataLayer.Models;
using DomainEntity;
using RepositoryCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
  internal class OwnerShipRepository : BaseRepository<OwnerShipRepository>, IOwnerShipRepository
  {
  //  private IRepository<OwnerShipRepository> _ownershipRepo;

    public OwnerShipRepository()
    {
     // _ownershipRepo = new Repository<OwnerShipRepository>(new ScreenerContext());
    }

    public void Dispose()
    {
     // throw new NotImplementedException();
    }

    //public IEnumerable<OwnerShipRepository> GetAll()
    //{
    //  var x = Repository.GetAll();
    //  return x;
    //}

    public IList<MutualFundHoldings_DL> GetMutualFundHoldings()
    {

      using (var ctx = base.Context)
      {
       var data = (from stockowner in ctx.StockOwnerShip
                      join stock in ctx.Stock
                          on stockowner.StockId equals stock.Id
                      select new  {
                        stock.StockName,
                        stock.Mcap,
                        stock.Sector,
                        stockowner.MutualFundHoldings,
                       stock.ClosePrice});
        List<MutualFundHoldings_DL> holdings = new List<MutualFundHoldings_DL>();
        foreach (var item in data)   // anvi - remove this loop and get the type from query only.
        {
          holdings.Add(new MutualFundHoldings_DL { StockName = item.StockName,
            MutualFundHoldings = item.MutualFundHoldings, Sector = item.Sector, 
            Mcap = item.Mcap, ClosePrice = item.ClosePrice });
        }
        return holdings;
      }
    }
  }
}
    



