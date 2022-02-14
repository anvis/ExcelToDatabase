using DomainEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
  public interface IWatchListStocksRepository
  {
    List<WatchListStocksDTO> GetWatchListStocks(int watchListId);

    List<WatchListStocksDTO> SaveWatchListStocks(List<WatchListStocksDTO> watchListStocksDTOs);
  }
}
