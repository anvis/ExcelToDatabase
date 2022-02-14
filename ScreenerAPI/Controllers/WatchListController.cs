using AutoMapper;
using DomainEntity;
using EntityLayer;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;

namespace ScreenerAPI.Controllers
{
  [Route("api/[controller]")]
    [ApiController]
    public class WatchListController : ControllerBase
    {
    private IWatchListService _watchListService;
    private IMapper _mapper;

    public WatchListController(IWatchListService watchListService, IMapper mapper)
    {
      _watchListService = watchListService;
      _mapper = mapper;
      //MapperProfile.EntityMapper = mapper;
    }

    [HttpGet]
    [Route("WatchList")]
    public List<WatchList> WatchList()
    {
      try
      {
        return _watchListService.GetWatchList();
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }
    }

    [HttpPost]
    [Route("WatchList")]
    public WatchList WatchList(WatchList watchList)
    {
      try
      {
       return _watchListService.AddWatchList(watchList);
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }
    }

    [HttpPut]
    [Route("WatchList")]
    public WatchList UpdateWatchList(WatchList watchList)
    {
      try
      {
        return _watchListService.UpdateWatchList(watchList);
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }
    }

    [HttpDelete]
    [Route("WatchList")]
    public List<WatchList> DeleteWatchList(WatchList watchList)
    {
      try
      {
        return _watchListService.DeleteWatchList(watchList);
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }
    }

    [HttpDelete]
    [Route("WatchList/{watchListId}")]
    public List<WatchList> DeleteWatchList(int watchListId)
    {
      try
      {
        return _watchListService.DeleteWatchList(watchListId);
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }
    }

    [HttpGet]
    [Route("WatchListStocks/{watchListId}")]
    public List<WatchListStocks> WatchListStocks(int watchListId)
    {
      try
      {
        return _watchListService.GetWatchListStocks(watchListId);
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }
    }

    [HttpPost]
    [Route("WatchListStocks")]
    public List<WatchListStocks> SaveWatchListStocks(List<WatchListStocks> watchListStocks)
    {
      try
      {
        return _watchListService.SaveWatchListStocks(watchListStocks);
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }
    }

  }
}