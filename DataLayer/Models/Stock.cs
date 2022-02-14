using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class Stock
    {
        public Stock()
        {
            Fundamanetals = new HashSet<Fundamanetals>();
            StockOwnerShip = new HashSet<StockOwnerShip>();
            Transactions = new HashSet<Transactions>();
            WatchListStocks = new HashSet<WatchListStocks>();
        }

        public int Id { get; set; }
        public string StockName { get; set; }
        public string Sector { get; set; }
        public double Mcap { get; set; }
        public double? ClosePrice { get; set; }
        public string McapCategory { get; set; }

        public virtual ICollection<Fundamanetals> Fundamanetals { get; set; }
        public virtual ICollection<StockOwnerShip> StockOwnerShip { get; set; }
        public virtual ICollection<Transactions> Transactions { get; set; }
        public virtual ICollection<WatchListStocks> WatchListStocks { get; set; }
    }
}
