using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class Fundamanetals
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public double? Peratio { get; set; }
        public double? Roce { get; set; }
        public double? Pbv { get; set; }
        public double? Peg { get; set; }
        public double? Roi { get; set; }
        public double? Roa { get; set; }
        public double? DebtToEquity { get; set; }
        public double? AsserTurnOverRatio { get; set; }
        public double? Ebit { get; set; }
        public double? Eps { get; set; }

        public virtual Stock Stock { get; set; }
    }
}
