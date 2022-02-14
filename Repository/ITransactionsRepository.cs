using DomainEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
public interface ITransactionsRepository
  {
    List<TransactionsDTO> AddTransactions(List<TransactionsDTO> transactionsDTO);
    List<TransactionsDTO> GetTransactions();
    List<TransactionsDTO> DeleteTransactions(List<TransactionsDTO> transactionsDTO);
    List<TransactionsDTO> DeleteTransactionsById(int transactionId);
  }
}
