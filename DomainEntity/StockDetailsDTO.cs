using System;
using System.Collections.Generic;
using System.Text;

namespace DomainEntity
{
 public class StockDetailsDTO
  {
    public int StockId { get; set; }
    public string StockName { get; set; }

    public string Sector { get; set; }
    public double? ClosePrice { get; set; }
  }
}
