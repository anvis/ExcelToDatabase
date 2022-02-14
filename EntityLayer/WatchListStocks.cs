using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer
{
  public class WatchListStocks
  {
    public int Id { get; set; }

    //[Range(0, 99)]
    public int WatchListId { get; set; }
    public int StockId { get; set; }
    public int TransactionId { get; set; }
    public decimal Quantity { get; set; }
    public Double Price { get; set; }
    public String TransactionType { get; set; }
    public string StockName { get; set; }
    public string WatchListName { get; set; }
  }
}
