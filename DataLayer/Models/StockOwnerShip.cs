using System;
using System.Collections.Generic;

namespace DataLayer.Models
{
    public partial class StockOwnerShip
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public double? MutualFundHoldings { get; set; }
        public double? ThreeMnthsMutualFundHoldings { get; set; }
        public double? SixMnthsMutualFundHoldings { get; set; }
        public double? PromoterHoldings { get; set; }
        public double? ThreeMnthsPromoterHoldings { get; set; }
        public double? SixMnthsPromoterHoldings { get; set; }
        public double? Fiiholdings { get; set; }
        public double? ThreeMnthsFiiholdings { get; set; }
        public double? SixMnthsFiiholdings { get; set; }
        public double? Diiholdings { get; set; }
        public double? ThreeMnthsDiiholdings { get; set; }
        public double? SixMnthsDiiholdings { get; set; }
        public double? PledgedPromoterHoldings { get; set; }

        public virtual Stock Stock { get; set; }
    }
}
