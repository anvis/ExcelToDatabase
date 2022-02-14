using AutoMapper;
using DomainEntity;
using EntityLayer;

namespace ScreenerAPI
{

  public class MappingProfiles : Profile
  {
    public MappingProfiles()
    {
      CreateMap<WatchList_DL, WatchList>().ReverseMap();
      CreateMap<WatchListStocksDTO, WatchListStocks>().ReverseMap();
      CreateMap<TransactionsDTO, Transactions>().ReverseMap();
      CreateMap<StockDetailsDTO, StockDetails>().ReverseMap();
      CreateMap<SectorsDTO, Sectors>().ReverseMap();
    }
  }
}

