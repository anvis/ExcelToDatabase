using System;
using System.Collections.Generic;
using System.Text;

namespace DomainEntity
{
 public class WatchListStocksDTO
  {
    public int Id { get; set; }
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
