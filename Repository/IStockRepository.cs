using DomainEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
 public interface IStockRepository
  {
    List<StockDetailsDTO> GetStocks();

    List<SectorsDTO> GetSectors();
  }
}
