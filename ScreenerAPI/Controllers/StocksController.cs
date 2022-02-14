using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ScreenerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
    private IStockService _stockService;

    public StocksController(IStockService stockService)
    {
      _stockService = stockService;
    }

    [HttpGet]
    [Route("Stocks")]
    public List<StockDetails> GetStocks()
    {
      try
      {
        return _stockService.GetStocks();
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }
    }

    [HttpGet]
    [Route("Sectors")]
    public List<Sectors> GetSectors()
    {
      try
      {
        return _stockService.GetSectors();
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }
    }

  }
}