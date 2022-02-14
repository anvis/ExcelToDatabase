using EntityLayer;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Services
{
 public class StockFundamentalsService : IStockFundamentalsService
  {
   //  private IStockFundamentalsRepository _stockFundamentalsRepository;
    unitofwork uow = new unitofwork();

    public StockFundamentalsService()
    {
     // _stockFundamentalsRepository = new StockFundamentalsRepository();
    }

    public List<SectorwiseStocks> GetStockFundamentals()
    {
      var stockFundamentals = uow.StockFundamentalsRepository.GetStockFundamentals();

      List<SectorwiseStocks> sector = new List<SectorwiseStocks>();

      //  foreach (var item in stockFundamentals)
      //  {
      //    sector.Add(new SectorwiseStocks { SectorName = item.Stock.Sector });
      //  }

      //  var groupedCustomerList = sector
      //.GroupBy(u => u.SectorName)
      //.Select(grp => grp.ToList())
      //.ToList();

      var sectorwiseList = stockFundamentals
    .GroupBy(u => (u.Stock.Sector))
    .Select(grp => grp.ToList())
    .ToList();

      foreach (var item in sectorwiseList)
      {
        SectorwiseStocks sectorwiseStocks = new SectorwiseStocks();
        sectorwiseStocks.SectorName = item.First().Stock.Sector;

        var mcaprwiseList = item
        .GroupBy(u => (u.Stock.McapCategory))
        .Select(grp => grp.ToList())
        .ToList();

        List<MCapStocks> mCapStocksList = new List<MCapStocks>();
        foreach (var mcap in mcaprwiseList)
        {
          //MCapStocks mCapStocks1 = new MCapStocks();
          //mCapStocks1.MCapCategory = mcap.First().Stock.McapCategory;
          //StockInfo stockInfo = new StockInfo();

          MCapStocks mCapStocks = new MCapStocks();
          var mcapCategory = mcap.First().Stock.McapCategory;
          List<StockInfo> stockInfoList = new List<StockInfo>();
          //stockInfo.StockName = stock.
          foreach (var stock in mcap)
          {
            StockInfo stockInfo = new StockInfo();
            stockInfo.Sector = stock.Stock.Sector;
            stockInfo.StockName = stock.Stock.StockName;
            stockInfo.ClosePrice = stock.Stock.ClosePrice;
            stockInfo.StockFundamentals = new StockFundamentals
            {
              AsserTurnOverRatio = stock.Fundamanetals.AsserTurnOverRatio,
              DebtToEquity = stock.Fundamanetals.DebtToEquity,
              Ebit = stock.Fundamanetals.Ebit,
              Eps = stock.Fundamanetals.Eps,
              Pbv = stock.Fundamanetals.Pbv,
              Peg = stock.Fundamanetals.Peg,
              Peratio = stock.Fundamanetals.Peratio,
              Roa = stock.Fundamanetals.Roa,
              Roce = stock.Fundamanetals.Roce,
              Roi = stock.Fundamanetals.Roi
            };
            stockInfoList.Add(stockInfo);            
          }
          //mCapStocksList.Add(new MCapStocks
          //{
          //  MCapCategory = mcapCategory,
          //  Stocks = stockInfoList
          //});
          mCapStocks.MCapCategory = mcapCategory;
          mCapStocks.Stocks = stockInfoList;
          mCapStocksList.Add(mCapStocks);
        }
        sectorwiseStocks.MCapStocks = mCapStocksList;
        sector.Add(sectorwiseStocks);
      }

      //List<MutualFundHoldings> mutualFundHoldings = new List<MutualFundHoldings>();
      //string mCapCategory = "Null";

      //foreach (var item in holdings) // anvi here we are duplicating the loops remove them.
      //{
      //  mCapCategory = Utility.GetMcapCategory(item.Mcap);
      //  mutualFundHoldings.Add(new MutualFundHoldings
      //  {
      //    StockName = item.StockName,
      //    MutualFundHoldingsPercentage = item.MutualFundHoldings,
      //    Sector = item.Sector,
      //    Mcap = item.Mcap,
      //    McapCategory = mCapCategory
      //  });

      //}

      return sector;
    }
  }
}
