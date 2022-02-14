using AutoMapper;
using DomainEntity;
using EntityLayer;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
  public class StockService : IStockService
  {
    unitofwork uow = new unitofwork();
    private IMapper _mapper;

    public StockService(IMapper mapper)
    {
      _mapper = mapper;
    }
    public List<StockDetails> GetStocks()
    {
      List<StockDetailsDTO> stockDetailsDTOs = uow.StockRepository.GetStocks();
      return MapperProfile.MapList<StockDetailsDTO, StockDetails>(_mapper, stockDetailsDTOs);
    }

    public List<Sectors> GetSectors()
    {
      List<SectorsDTO> sectorDTOs = uow.StockRepository.GetSectors();
      return MapperProfile.MapList<SectorsDTO, Sectors>(_mapper, sectorDTOs);
    }
  }
}
