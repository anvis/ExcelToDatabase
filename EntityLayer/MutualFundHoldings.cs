using System;

namespace EntityLayer
{
  public class MutualFundHoldings
  {
    public string StockName { get; set; }

    public double Mcap { get; set; }

    public string Sector { get; set; }

    public double? MutualFundHoldingsPercentage { get; set; }

    public string McapCategory { get; set; }

    public double? ClosePrice { get; set; }
  }
}
