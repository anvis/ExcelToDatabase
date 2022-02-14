using DataLayer.Models;
using DomainEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Repository
{
 internal class TransactionsRepository : BaseRepository<Transactions>, ITransactionsRepository
  {
    public TransactionsRepository()
    {     
    }

    private Transactions TransactionMap(TransactionsDTO transactionsDTO)
    {
      Transactions transactions = new Transactions();

      transactions.Price = transactionsDTO.Price;
      transactions.Quantity = transactionsDTO.Quantity;
      transactions.StockId = transactionsDTO.StockId;
      transactions.TransactionType = transactionsDTO.TransactionType;

      return transactions;
    }

    private List<Transactions> TransactionListMap(List<TransactionsDTO> transactionsDTO)
    {
      List<Transactions> transactions = null;
      foreach (var transaction in transactionsDTO)
      {
        transactions.Add(new Transactions
        {
          Price = transaction.Price,
          Quantity = transaction.Quantity,
          StockId = transaction.StockId,
          TransactionType = transaction.TransactionType
        });        
      }

      return transactions;
    }

    public List<TransactionsDTO> AddTransactions(List<TransactionsDTO> transactionsDTO)
    {
      Transactions transactions = null;
      foreach (var transaction in transactionsDTO)
      {
        transactions = TransactionMap(transaction);
        Repository.Insert(transactions);
      }   
      Repository.SaveAllChanges();
      return  this.GetTransactions();     
    }

    public List<TransactionsDTO> DeleteTransactions(List<TransactionsDTO> transactionsDTO)
    {
      Transactions transactions = null;
      foreach (var transaction in transactionsDTO)
      {
        transactions = TransactionMap(transaction);
        Repository.Delete(transactions);
      }
      Repository.SaveAllChanges();
      return this.GetTransactions();
    }

    public List<TransactionsDTO> DeleteTransactionsById(int transactionId)
    {
       Repository.Delete(transactionId);
      Repository.SaveAllChanges();
      return this.GetTransactions();
    }

    public List<TransactionsDTO> GetTransactions()
    {
      using (var ctx = base.Context)
      {
        var data = from transaction in ctx.Transactions
                    select new {  transaction.Stock.StockName,  transaction };

        List<TransactionsDTO> transactionsDTOList = new List<TransactionsDTO>();

        foreach (var item in data)
        {
          transactionsDTOList.Add(new TransactionsDTO {
            Id = item.transaction.Id,
            Price = item.transaction.Price,
            Quantity = item.transaction.Quantity,
            StockId = item.transaction.StockId,
            TransactionType = item.transaction.TransactionType,
            StockName = item.StockName
          });
        }

        return transactionsDTOList;
      }
    }
  }
}
