using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer
{
 public class StockInfo
  {
    public string StockName { get; set; }

    public string Mcap { get; set; }

    public string Sector { get; set; }

    public double? ClosePrice { get; set; }

    public StockFundamentals StockFundamentals { get; set; }
  }
}
