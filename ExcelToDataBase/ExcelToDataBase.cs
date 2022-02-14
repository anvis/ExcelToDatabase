using DataLayer.Models;
using System;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelToDataBase
{
 public static class ExcelToDataBase
  {
    public static DataSet ExcelToDataSet(string path)
    {
      Excel.Application objXL = null;
      Excel.Workbook objWB = null;
      DataSet ds = new DataSet();
      try
      {
        objXL = new Excel.Application();
        objWB = objXL.Workbooks.Open(path);
        foreach (Excel.Worksheet objSHT in objWB.Worksheets)
        {
          int rows = objSHT.UsedRange.Rows.Count;
          int cols = objSHT.UsedRange.Columns.Count;
          DataTable dt = new DataTable();
          int noofrow = 1;
          for (int c = 1; c <= cols; c++)
          {
            var sno = (Excel.Range)objSHT.Cells[1, c];
            string colname = sno.Value2.ToString();
            dt.Columns.Add(colname);
            noofrow = 2;
          }
          for (int r = noofrow; r <= rows; r++)
          {
            DataRow dr = dt.NewRow();
            for (int c = 1; c <= cols; c++)
            {
              var sno = (Excel.Range)objSHT.Cells[r, c];
              string colvalue = sno.Value2.ToString();
              dr[c - 1] = colvalue;
            }
            dt.Rows.Add(dr);
          }
          ds.Tables.Add(dt);
        }
        objWB.Close();
        objXL.Quit();
        return ds;
      }
      catch (Exception ex)
      {
        objWB.Saved = true;
        objWB.Close();
        objXL.Quit();
      }
      return null;
    }
  }
}
