using EntityLayer;
using Microsoft.Extensions.Configuration;
using Repository;
using System;
using System.Collections.Generic;
using Utility;

namespace Services
{
  public class MutualFundHoldingsService : IMutualFundHoldingsService
  {
    // private IOwnerShipRepository _OwnerShipRepository;
    unitofwork uow = new unitofwork();
    public MutualFundHoldingsService()
    {
      //_OwnerShipRepository = new OwnerShipRepository();
    }

    public List<MutualFundHoldings> getMutualHoldings()
    {
      var holdings = uow.OwnerShipRepository.GetMutualFundHoldings();
      List<MutualFundHoldings> mutualFundHoldings = new List<MutualFundHoldings>();
      string mCapCategory = "Null";

      foreach (var item in holdings) // anvi here we are duplicating the loops remove them.
      {
        mCapCategory = Common.GetMcapCategory(item.Mcap);
        mutualFundHoldings.Add(new MutualFundHoldings
        {
          StockName = item.StockName,
          MutualFundHoldingsPercentage = item.MutualFundHoldings,
          Sector = item.Sector,
          Mcap = item.Mcap,
          McapCategory = mCapCategory,
           ClosePrice = item.ClosePrice          
        });

      }
      return mutualFundHoldings;
    }
  }
}
