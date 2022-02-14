using DataLayer.Models;
using DomainEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
public interface ITransactionService
  {
    List<EntityLayer.Transactions> GetTransactions();
    IEnumerable<EntityLayer.Transactions> AddTransactions(List<EntityLayer.Transactions> transactions);
    IEnumerable<EntityLayer.Transactions> DeleteTransactions(List<EntityLayer.Transactions> transactions);
    IEnumerable<EntityLayer.Transactions> DeleteTransactions(int transactionId);
  }
}
