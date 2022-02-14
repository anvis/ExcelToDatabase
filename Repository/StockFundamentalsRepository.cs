using DataLayer.Models;
using DomainEntity;
using RepositoryCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility;

namespace Repository
{
 internal class StockFundamentalsRepository: BaseRepository<Fundamanetals>, IStockFundamentalsRepository
  {
   // private IRepository<Fundamanetals> _StockFundamentalsRepository;

    public StockFundamentalsRepository()
    {
    //  _StockFundamentalsRepository = new Repository<Fundamanetals>(new ScreenerContext());
    }


    public IList<StockFundamentals> GetStockFundamentals()
    {

      using (var ctx = base.Context)
      {
        var data = (from stock in ctx.Stock
                    join fundamentals in ctx.Fundamanetals 
                        on stock.Id equals fundamentals.StockId select new { stock, fundamentals });

        List<StockFundamentals> stockFundamentals = new List<StockFundamentals>();
       
        foreach (var item in data)
        {
          stockFundamentals.Add(new StockFundamentals { Stock = item.stock, Fundamanetals = item.fundamentals });          
        }

        return stockFundamentals;
    }
    }
  }
}
