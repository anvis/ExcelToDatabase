using AutoMapper;
using DomainEntity;
using EntityLayer;
using Repository;
using System.Collections.Generic;

namespace Services
{
  public class WatchListService : IWatchListService
  {
    private IMapper _mapper;
    unitofwork uow = new unitofwork();

    public WatchListService(IMapper mapper)
    {
      _mapper = mapper;
    }

    public List<WatchList> GetWatchList()
    {
     // WatchList watchList = new WatchList();  
      IEnumerable<WatchList_DL> watchList_DLs = uow.WatchListRepository.GetWatchLists();      
      List<WatchList> watchlists = new List<WatchList>();
      foreach (var item in watchList_DLs)
      {
        watchlists.Add(_mapper.Map<WatchList_DL, WatchList>(item));
      }
      return watchlists;
    }

    public WatchList AddWatchList(WatchList watchList)
    {
     var watchlist = _mapper.Map<WatchList, WatchList_DL>(watchList);
     var watchlistDTO =  uow.WatchListRepository.AddWatchList(watchlist);
     var watchlistentit = _mapper.Map<WatchList_DL, WatchList>(watchlistDTO);
     return watchlistentit;
    }

    public WatchList UpdateWatchList(WatchList watchList)
    {
      var watchlist = _mapper.Map<WatchList, WatchList_DL>(watchList);
      var watchlistDTO = uow.WatchListRepository.UpdateWatchList(watchlist);
      var watchlistentit = _mapper.Map<WatchList_DL, WatchList>(watchlistDTO);
      return watchlistentit;
    }

    public List<WatchList> DeleteWatchList(WatchList watchList)
    {
      var watchlist = _mapper.Map<WatchList, WatchList_DL>(watchList);
      uow.WatchListRepository.DeleteWatchList(watchlist);
      return this.GetWatchList();
    }

    public List<WatchList> DeleteWatchList(int watchListId)
    {
      uow.WatchListRepository.DeleteWatchList(watchListId);
      return this.GetWatchList();
    }

    public List<WatchListStocks> GetWatchListStocks(int watchListId)
    {
      WatchList watchList = new WatchList();
      List<WatchListStocksDTO>  watchList_DLs = uow.WatchListStocksRepository.GetWatchListStocks(watchListId);
      List<WatchListStocks> watchlists = new List<WatchListStocks>();
      foreach (var item in watchList_DLs)
      {
        watchlists.Add(_mapper.Map<WatchListStocksDTO, WatchListStocks>(item));
      }
      return watchlists;
    }

    public List<WatchListStocks> SaveWatchListStocks(List<WatchListStocks> WatchListStocks)
    {
      List<WatchListStocksDTO> watchListDto = MapperProfile.MapList<WatchListStocks, WatchListStocksDTO>(_mapper, WatchListStocks);
      List<WatchListStocksDTO> watchList_DLs = uow.WatchListStocksRepository.SaveWatchListStocks(watchListDto);
     return  MapperProfile.MapList<WatchListStocksDTO, WatchListStocks>(_mapper, watchList_DLs);
    }
  }
}
