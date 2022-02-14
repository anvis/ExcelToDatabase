using System;

namespace DomainEntity
{
  public class MutualFundHoldings_DL
  {
    public string StockName { get; set; }

    public double Mcap { get; set; }

    public string Sector { get; set; }

    public double? MutualFundHoldings { get; set; }

    public double? ClosePrice { get; set; }
  }
}
  