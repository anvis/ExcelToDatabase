using ExcelToDataBase;
using Repository;
using System;
using System.Data;

namespace ImportData
{
  class Program
  {
    static void Main(string[] args)
    {
      //DataSet ds= ImportOwnerShip.ExcelToDataSet(@"C:\temp\one.xlsx");
      //ImportOwnerShip.DataSetToDatabase(ds);
      Console.WriteLine("Hello World!");
      OwnerShipRepository osr = new OwnerShipRepository();
      osr.GetMutualFundHoldings();
      Console.ReadLine();
    }
  }
}
