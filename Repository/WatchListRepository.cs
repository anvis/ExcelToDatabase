using AutoMapper;
using DataLayer.Models;
using DomainEntity;
using RepositoryCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Utility;

namespace Repository
{
internal class WatchListRepository : BaseRepository<Watchlist>, IWatchListRepository
  {
    public WatchListRepository()
    {  
    }

    public IEnumerable<WatchList_DL> GetWatchLists()
    {
      var watchListList = Repository.GetAll();
      List<WatchList_DL> watchList_DLs = new List<WatchList_DL>();
      foreach (var watchlist in watchListList)
      {
        watchList_DLs.Add(new WatchList_DL { Id = watchlist.Id, WatchListName = watchlist.WatchListName });
      }
      return watchList_DLs;
    }

    public WatchList_DL AddWatchList(WatchList_DL watchlistDL)
    {
      Watchlist watchlist = null;
      watchlist = new Watchlist { WatchListName = watchlistDL.WatchListName };

      Repository.Insert(watchlist);
      Repository.SaveAllChanges();
      watchlistDL.Id = watchlist.Id;
      return watchlistDL;
    }

    public WatchList_DL UpdateWatchList(WatchList_DL watchlistDL)
    {
      Watchlist watchlist = null;
      watchlist = new Watchlist { Id = watchlistDL.Id, WatchListName = watchlistDL.WatchListName };

      Repository.Update(watchlist);
      Repository.SaveAllChanges();
      watchlistDL.Id = watchlist.Id;
      return watchlistDL;
    }
      
    public void DeleteWatchList(WatchList_DL watchlistDL)
    {
      Watchlist watchlist = null;
      watchlist = new Watchlist { Id = watchlistDL.Id, WatchListName = watchlistDL.WatchListName };

      Repository.Delete(watchlist);
      Repository.SaveAllChanges();      
    }

    public void DeleteWatchList(int watchlistId)
    {
      Repository.Delete(watchlistId);
      Repository.SaveAllChanges();
    }
  }
}
