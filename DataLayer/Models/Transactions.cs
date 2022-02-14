using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class Transactions
    {
        public Transactions()
        {
            WatchListStocks = new HashSet<WatchListStocks>();
        }

        public int Id { get; set; }
        public int StockId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string TransactionType { get; set; }

        public virtual Stock Stock { get; set; }
        public virtual ICollection<WatchListStocks> WatchListStocks { get; set; }
    }
}
