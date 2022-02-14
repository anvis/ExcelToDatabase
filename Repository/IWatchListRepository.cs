using DataLayer.Models;
using DomainEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
 public interface IWatchListRepository 
  {
    IEnumerable<WatchList_DL> GetWatchLists();

    WatchList_DL AddWatchList(WatchList_DL watchlistDL);
    WatchList_DL UpdateWatchList(WatchList_DL watchlistDL);
    void DeleteWatchList(WatchList_DL watchlistDL);
    void DeleteWatchList(int watchlistId);
  }
}
