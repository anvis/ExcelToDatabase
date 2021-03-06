using System;

namespace Utility
{
  public static class Common
  {
    public static string MidCap { get; set; }
    public static string LargeCap { get; set; }
    public static string SmallCap { get; set; }

    public static string GetMcapCategory(double mCap)
    {
      if ((mCap > Convert.ToDouble(MidCap)) && (mCap < Convert.ToDouble(LargeCap)))
        return "Mid Cap";
      else if ((mCap < Convert.ToDouble(MidCap)))
        return "Small Cap";
      else
        return "Large Cap";
    }
  }
}
