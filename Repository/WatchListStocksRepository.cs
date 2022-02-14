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
  internal class WatchListStocksRepository : BaseRepository<WatchListStocks>, IWatchListStocksRepository
  {
    public List<WatchListStocksDTO> SaveWatchListStocks(List<WatchListStocksDTO> watchListStocksDTOs)
    {

      List<WatchListStocks> watchlistStocks = new List<WatchListStocks>();

      foreach (var item in watchListStocksDTOs)
      {
        var watchListStocks = new WatchListStocks { StockId = item.StockId, TransactionId = item.TransactionId, WatchListId = item.WatchListId };
        Repository.Insert(watchListStocks);
      }
      Repository.SaveAllChanges();
      return watchListStocksDTOs;   // anvi get latest id for all reords and send.
    }

    public List<WatchListStocksDTO> GetWatchListStocks(int watchListId)
    {
      List<WatchListStocksDTO> WatchListStocksDTO = null;
      using (var ctx = base.Context)
      {
        WatchListStocksDTO = (from transactions in ctx.Transactions
                              join watchListStocks in ctx.WatchListStocks on transactions.Id equals watchListStocks.TransactionId
                              join stock in ctx.Stock on watchListStocks.StockId equals stock.Id
                              join watchlist in ctx.Watchlist on watchListStocks.WatchListId equals watchlist.Id
                              where watchlist.Id == watchListId
                              select new WatchListStocksDTO
                              {
                                Quantity = transactions.Quantity,
                                Price = transactions.Price,
                                TransactionType = transactions.TransactionType,
                                StockName = stock.StockName,
                                WatchListName = watchlist.WatchListName,
                                WatchListId = watchlist.Id,
                                StockId = stock.Id,
                                TransactionId = transactions.Id,
                                Id = watchListStocks.Id
                              }).ToList();
      }

      return WatchListStocksDTO;
    }
  }
}
