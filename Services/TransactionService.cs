using AutoMapper;
using DomainEntity;
using EntityLayer;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
  public class TransactionService : ITransactionService
  {
    private IMapper _mapper;
    unitofwork uow = new unitofwork();

    public TransactionService(IMapper mapper)
    {
      _mapper = mapper;
    }

    public List<EntityLayer.Transactions> GetTransactions()
    {
      throw new Exception();

     // Transactions watchList = new Transactions();
      IEnumerable<TransactionsDTO> transactionsDTO = uow.TransactionsRepository.GetTransactions();
      List<EntityLayer.Transactions> transactions = new List<EntityLayer.Transactions>();
      foreach (var item in transactionsDTO)
      {
        transactions.Add(_mapper.Map<TransactionsDTO, EntityLayer.Transactions>(item));
      }
      return transactions;
    }

    public IEnumerable<EntityLayer.Transactions> AddTransactions(List<EntityLayer.Transactions> transactions)
    {
      List<TransactionsDTO> transactionsDTOList = new List<TransactionsDTO>();
      foreach (var transaction in transactions)
      {
        transactionsDTOList.Add(_mapper.Map<EntityLayer.Transactions, TransactionsDTO>(transaction));
      }
      transactionsDTOList = uow.TransactionsRepository.AddTransactions(transactionsDTOList);
      List<EntityLayer.Transactions> transactionsList = new List<EntityLayer.Transactions>();
      foreach (var transaction in transactionsDTOList)
      {
        transactionsList.Add(_mapper.Map<TransactionsDTO, EntityLayer.Transactions>(transaction));
      }
      return transactionsList;
    }

    public IEnumerable<EntityLayer.Transactions> DeleteTransactions(List<EntityLayer.Transactions> transactions)
    {     
      List<TransactionsDTO> transactionsDTOList = MapperProfile.MapList<EntityLayer.Transactions, TransactionsDTO>(_mapper, transactions);
      transactionsDTOList = uow.TransactionsRepository.DeleteTransactions(transactionsDTOList);
      List<EntityLayer.Transactions> transactionsList = new List<EntityLayer.Transactions>();
      foreach (var transaction in transactionsDTOList)
      {
        transactionsList.Add(_mapper.Map<TransactionsDTO, EntityLayer.Transactions>(transaction));
      }
      return transactionsList;
    }

    public IEnumerable<EntityLayer.Transactions> DeleteTransactions(int transactionId)
    {
      List<TransactionsDTO> transactionsDTOList = null;
      transactionsDTOList = uow.TransactionsRepository.DeleteTransactionsById(transactionId);
      List<EntityLayer.Transactions> transactionsList = new List<EntityLayer.Transactions>();
      foreach (var transaction in transactionsDTOList)
      {
        transactionsList.Add(_mapper.Map<TransactionsDTO, EntityLayer.Transactions>(transaction));
      }
      return transactionsList;
    }


  }
}
