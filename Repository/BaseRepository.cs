using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryCore;
using System;

namespace Repository
{
 public  class BaseRepository<T> where T : class //, IDisposable
  {
    unitofwork uow = new unitofwork();
    protected BaseRepository()
    { 
    
    }

    private Repository<T> repository { get; set; }

    public Repository<T> Repository { 
      get
      {
        return repository;  
      }
      set
      {
        repository = value;
      }
    }
    
    public ScreenerContext Context
    {
      get
      {
        return uow.Context;
      }
    }
  }

  
}