using DataLayer.Models;
using System;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelToDataBase
{
  public class ImportOwnerShip
  {      

    public static void DataSetToDatabase(DataSet ds)
    {
      ScreenerContext sc = new ScreenerContext();

      foreach (DataRow row in ds.Tables[0].Rows)
      {        
        StockOwnerShip stockOwnerShip = new StockOwnerShip();
        stockOwnerShip.MutualFundHoldings = Convert.ToDouble(row["MutualFundHoldings"]);
        stockOwnerShip.ThreeMnthsMutualFundHoldings = Convert.ToDouble(row["ThreeMnthsMutualFundHoldings"]);
        stockOwnerShip.SixMnthsMutualFundHoldings = Convert.ToDouble(row["SixMnthsMutualFundHoldings"]);

        stockOwnerShip.Fiiholdings = Convert.ToDouble(row["Fiiholdings"]);
        stockOwnerShip.SixMnthsFiiholdings = Convert.ToDouble(row["SixMnthsFiiholdings"]);
        stockOwnerShip.ThreeMnthsFiiholdings = Convert.ToDouble(row["ThreeMnthsFiiholdings"]);

        stockOwnerShip.Diiholdings = Convert.ToDouble(row["Diiholdings"]);
        stockOwnerShip.ThreeMnthsDiiholdings = Convert.ToDouble(row["ThreeMnthsDiiholdings"]);
        stockOwnerShip.SixMnthsDiiholdings = Convert.ToDouble(row["SixMnthsDiiholdings"]);

        stockOwnerShip.PromoterHoldings = Convert.ToDouble(row["PromoterHoldings"]);       
        stockOwnerShip.ThreeMnthsPromoterHoldings = Convert.ToDouble(row["ThreeMnthsPromoterHoldings"]);
        stockOwnerShip.SixMnthsPromoterHoldings = Convert.ToDouble(row["SixMnthsPromoterHoldings"]);

        stockOwnerShip.PledgedPromoterHoldings = Convert.ToDouble(row["PledgedPromoterHoldings"]);
        
        sc.StockOwnerShip.Add(stockOwnerShip);
      }
      sc.SaveChanges();
    }
  }
}
