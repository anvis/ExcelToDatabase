using AutoMapper;
using DataLayer.Models;
using DomainEntity;

namespace Repository
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {

    }

    public void EnableMapping()
    {
      CreateMap<Watchlist, WatchList_DL>().ReverseMap();
    }
  }
}
