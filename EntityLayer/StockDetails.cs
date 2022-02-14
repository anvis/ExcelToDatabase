using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer
{
  public class StockDetails
  {
    public int StockId { get; set; }
    public string StockName { get; set; }
    public float ClosePrice { get; set; }
    public string Sector { get; set; }
  }
}
