using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer
{
 public class Transactions
  {
    public int Id { get; set; }
    public int StockId { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    public string TransactionType { get; set; }
    public string StockName { get; set; }
  }
}
