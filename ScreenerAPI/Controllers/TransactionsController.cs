using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ScreenerAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TransactionsController : ControllerBase
  {
    private ITransactionService _transactionService;

    public TransactionsController(ITransactionService transactionService, IMapper mapper)
    {
      _transactionService = transactionService;
    }

    [HttpGet]
    [Route("Transactions")]
    public List<EntityLayer.Transactions> GetTtransactions()
    {
      try
      {
        return _transactionService.GetTransactions();
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }
    }

    [HttpPost]
    [Route("Transactions")]
    public List<EntityLayer.Transactions> SaveTransactions(List<EntityLayer.Transactions> transactions)
    {
      try
      {
        return _transactionService.AddTransactions(transactions).ToList();
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }
    }

    [HttpDelete]
    [Route("Transactions")]
    public List<EntityLayer.Transactions> DeleteTransactions(List<EntityLayer.Transactions> transactions)
    {
      try
      {
        return _transactionService.DeleteTransactions(transactions).ToList();
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }
    }

    [HttpDelete]
    [Route("Transactions/{transactionId}")]
    public List<EntityLayer.Transactions> DeleteTransactionsById(int transactionId)
    {
      try
      {
        return _transactionService.DeleteTransactions(transactionId).ToList();
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }
    }
  }
}