using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
  public class unitofwork : IDisposable
  {
    private bool disposed = false;
    private WatchListRepository watchlistRepository;
    private StockFundamentalsRepository stockFundamentalsRepository;
    private OwnerShipRepository ownerShipRepository;
    private TransactionsRepository transactionsRepository;
    private WatchListStocksRepository watchListStocksRepository;
    private StockRepository stockRepository;

    public unitofwork()
    { 
    
    }

    public ScreenerContext Context { get; } = new ScreenerContext();

    public IWatchListRepository WatchListRepository
    {
      get
      {
        if (this.watchlistRepository == null)
        {
          this.watchlistRepository = RepositoryInstance<WatchListRepository>.GetInstance();
          watchlistRepository.Repository = new Repository<Watchlist>(Context);
        //  watchlistRepository.Context = context;
        }
        return watchlistRepository;
      }
    }

    public IStockRepository StockRepository
    {
      get
      {
        if (this.stockRepository == null)
        {
          this.stockRepository = RepositoryInstance<StockRepository>.GetInstance();
          stockRepository.Repository = new Repository<Stock>(Context);
          //  watchlistRepository.Context = context;
        }
        return stockRepository;
      }
    }

    public IWatchListStocksRepository WatchListStocksRepository
    {
      get
      {
        if (this.watchListStocksRepository == null)
        {
          this.watchListStocksRepository = RepositoryInstance<WatchListStocksRepository>.GetInstance();
          watchListStocksRepository.Repository = new Repository<WatchListStocks>(Context);
          //  watchlistRepository.Context = context;
        }
        return watchListStocksRepository;
      }
    }

    public IStockFundamentalsRepository StockFundamentalsRepository
    {
      get
      {
        if (this.stockFundamentalsRepository == null)
        {
          this.stockFundamentalsRepository = RepositoryInstance<StockFundamentalsRepository>.GetInstance();
          stockFundamentalsRepository.Repository = new Repository<Fundamanetals>(Context);
         // stockFundamentalsRepository.Context = context;
        }
        return stockFundamentalsRepository;
      }
    }

    public IOwnerShipRepository OwnerShipRepository
    {
      get
      {
        if (this.ownerShipRepository == null)
        {
          this.ownerShipRepository = RepositoryInstance<OwnerShipRepository>.GetInstance();
          ownerShipRepository.Repository = new Repository<OwnerShipRepository>(Context);
          // stockFundamentalsRepository.Context = context;
        }
        return ownerShipRepository;
      }
    }

    public ITransactionsRepository TransactionsRepository
    {
      get
      {
        if (this.transactionsRepository == null)
        {
          this.transactionsRepository = RepositoryInstance<TransactionsRepository>.GetInstance();
          transactionsRepository.Repository = new Repository<Transactions>(Context);
          // stockFundamentalsRepository.Context = context;
        }
        return transactionsRepository;
      }
    }

    public void Save()
    {
      Context.SaveChanges();
    } 

    protected virtual void Dispose(bool disposing)
    {
      if (!this.disposed)
      {
        if (disposing)
        {
          Context.Dispose();
        }
      }
      this.disposed = true;
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }

  }
}
