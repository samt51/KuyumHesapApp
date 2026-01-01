using AutoMapper;
using KuyumHesap.Application.Common.Models.Dtos;
using KuyumHesap.Domain.Entities;

namespace KuyumHesap.Persistence.Common.Concrete.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Currency, CurrencyResponseDto>().ReverseMap();
            CreateMap<StockGroup,StockGroupResponseDto>().ReverseMap(); 
        }
    }
}
