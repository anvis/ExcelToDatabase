using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class WatchListStocks
    {
        public int Id { get; set; }
        public int WatchListId { get; set; }
        public int StockId { get; set; }
        public int TransactionId { get; set; }

        public virtual Stock Stock { get; set; }
        public virtual Transactions Transaction { get; set; }
        public virtual Watchlist WatchList { get; set; }
    }
}
