using AutoMapper;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
 public interface IWatchListService
  {
    List<WatchList> GetWatchList();
    WatchList AddWatchList(WatchList watchList);
    List<WatchListStocks> GetWatchListStocks(int watchListId);
    WatchList UpdateWatchList(WatchList watchList);

    List<WatchList> DeleteWatchList(WatchList watchList);

    List<WatchList> DeleteWatchList(int watchListId);

    List<WatchListStocks> SaveWatchListStocks(List<WatchListStocks> WatchListStocks);
  }
}
