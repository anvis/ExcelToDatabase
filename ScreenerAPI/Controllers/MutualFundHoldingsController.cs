using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Services;
using Utility;

namespace ScreenerAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MutualFundHoldingsController : ControllerBase
  {

    private IMutualFundHoldingsService _mutualFundHoldingsService;
    private readonly IOptions<MarketCapitalization> _capitalization;

    public MutualFundHoldingsController(IMutualFundHoldingsService mutualFundHoldings, IOptions<MarketCapitalization> mCap)
    {
      _capitalization = mCap;
      _mutualFundHoldingsService = mutualFundHoldings;
      Setutility();
    }

    private void Setutility() // Anvi move it to landing controller
    {
      Common.LargeCap = _capitalization.Value.LargeCap;
      Common.MidCap = _capitalization.Value.MidCap;
      Common.SmallCap = _capitalization.Value.SmallCap;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
      var rng = new Random();
      return Enumerable.Range(1, 5).Select(index => new WeatherForecast
      {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = rng.Next(-20, 55),
        //  Summary = Summaries[rng.Next(Summaries.Length)]
      })
      .ToArray();
    }

    [HttpGet]
    [Route("MutualFundHoldings")]
    public List<MutualFundHoldings> MutualFundHoldings()
    {
      try
      {
        return _mutualFundHoldingsService.getMutualHoldings();
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }
    }
  }
}