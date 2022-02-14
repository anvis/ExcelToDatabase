using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
  public class RepositoryInstance<K>
        where K : class, new()
  {
    public static K GetInstance()
    {
      K objK;

      objK = new K();

      return objK;
    }
  }
}
