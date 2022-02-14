using DomainEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
 public interface IOwnerShipRepository 
  {
   // IEnumerable<OwnerShipRepository> GetAll();

    IList<MutualFundHoldings_DL> GetMutualFundHoldings();
  }
}
