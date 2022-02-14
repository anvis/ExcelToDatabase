using DataLayer.Models;
using DomainEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repository
{
   
    internal class StockRepository : BaseRepository<Stock>, IStockRepository
  {
    public List<StockDetailsDTO> GetStocks()
    {
      var stocks = Repository.GetAll();
      List<StockDetailsDTO> stockDetailsDTOs = new List<StockDetailsDTO>();
      foreach (var stock in stocks)
      {
        stockDetailsDTOs.Add(new StockDetailsDTO {  StockId = stock.Id, Sector = stock.Sector,  StockName = stock.StockName, ClosePrice = stock.ClosePrice });
      }
      return stockDetailsDTOs;
    }

    public List<SectorsDTO> GetSectors()
    {
      List<string> sectors = new List<string>();   // anvi look this logic.
      List<SectorsDTO> sectorsList = new List<SectorsDTO>();
      using (var ctx = base.Context)
      {
         sectors = ctx.Stock.Select(d => d.Sector).Distinct().ToList();
      }

      foreach (var sectorName in sectors)
      {
        sectorsList.Add(new SectorsDTO() { SectorName = sectorName });
      }
      return sectorsList;
    }
  }
}
