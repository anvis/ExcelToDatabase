﻿using DomainEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
 public interface IStockFundamentalsRepository 
  {
    IList<StockFundamentals> GetStockFundamentals();
  }
}
