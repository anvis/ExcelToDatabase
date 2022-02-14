using System;
using System.Collections.Generic;
using System.Text;

namespace DomainEntity
{
public class MCapStocks_DL
  {
    public string MCapCategory { get; set; }

    public List<StockInfo_DL> Stocks { get; set; }
  }
}
