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
    public class StockFundamentalsController : ControllerBase
    {
    private IStockFundamentalsService _stockFundamentalsService;

    public StockFundamentalsController(IStockFundamentalsService mutualFundHoldings)
    {
   //   _capitalization = mCap;
      _stockFundamentalsService = mutualFundHoldings;
    //  Setutility();
    }

    [HttpGet]
    [Route("Fundamentals")]
    public List<SectorwiseStocks> MutualFundHoldings()
    {
      try
      {
        return _stockFundamentalsService.GetStockFundamentals();
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }
    }
  }
}