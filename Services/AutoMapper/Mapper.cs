using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
 public static class MapperProfile
  {
  // public static IMapper EntityMapper { get; set; }

    public static destination Map<source,destination>(IMapper mapper, source s)  where source : class where destination : class
    {
      return mapper.Map<source, destination>(s);
    }

    public static List<destination> MapList<source, destination>(IMapper mapper, List<source> s) where source : class where destination : class
    {
      List<destination> dest = new List<destination>();
      foreach (var item in s)
      {
        dest.Add(mapper.Map<source, destination>(item));
      }
      return dest;
    }
  }
}
