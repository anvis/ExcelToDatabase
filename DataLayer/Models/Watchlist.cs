using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class Watchlist
    {
        public Watchlist()
        {
            WatchListStocks = new HashSet<WatchListStocks>();
        }

        public int Id { get; set; }
        public string WatchListName { get; set; }

        public virtual ICollection<WatchListStocks> WatchListStocks { get; set; }
    }
}
