using AutoMapper;
using KuyumHesap.Application.Common.Models.Dtos;
using KuyumHesap.Application.Common.Models.Dtos.ResponseDtos;
using KuyumHesap.Application.Features.AccountFeature.Command.Update;
using KuyumHesap.Application.Features.AccountFeature.Queries.CheckSoftDuplicate;
using KuyumHesap.Application.Features.AccountFeature.Queries.GetAll;
using KuyumHesap.Application.Features.AccountFeature.Queries.GetById;
using KuyumHesap.Application.Features.AccountTypeFeature.Queries.GetAll;
using KuyumHesap.Application.Features.AccountTypeFeature.Queries.GetById;
using KuyumHesap.Application.Features.BarcodeFeature.Queries.GetPacker;
using KuyumHesap.Application.Features.BarcodeFeature.Queries.GetProductType;
using KuyumHesap.Application.Features.BarcodeFeature.Queries.GetStock;
using KuyumHesap.Application.Features.BarcodeFeature.Queries.GetStockType;
using KuyumHesap.Application.Features.BarcodeHeaderFeature.Dtos;
using KuyumHesap.Application.Features.BarcodeHeaderFeature.Queries.GetById;
using KuyumHesap.Application.Features.CurrecyFeature.Queries.GetAll;
using KuyumHesap.Application.Features.ExchangeFeature.Dtos;
using KuyumHesap.Application.Features.ExchangeFeature.Queries.GetAll;
using KuyumHesap.Application.Features.ExchangeFeature.Queries.GetById;
using KuyumHesap.Application.Features.MovementFeature.Queries.GetAll;
using KuyumHesap.Application.Features.MovementFeature.Queries.GetById;
using KuyumHesap.Application.Features.ProductTypeFeature.Queries.GetAll;
using KuyumHesap.Application.Features.ProductTypeFeature.Queries.GetById;
using KuyumHesap.Application.Features.ReceiptFeature.Queries.GetAll.Dtos;
using KuyumHesap.Application.Features.ReceiptFeature.Queries.GetById;
using KuyumHesap.Application.Features.StockFeature.Commands.Create;
using KuyumHesap.Application.Features.StockFeature.Commands.Update;
using KuyumHesap.Application.Features.StockFeature.Queries.GetAll;
using KuyumHesap.Application.Features.StockFeature.Queries.GetById;
using KuyumHesap.Application.Features.StockGroupFeature.Queries.GetAll;
using KuyumHesap.Application.Features.StockGroupFeature.Queries.GetById;
using KuyumHesap.Application.Features.StockTypeFeature.Queries.GetAll;
using KuyumHesap.Application.Features.StockTypeFeature.Queries.GetById;
using KuyumHesap.Application.Features.TaskItemFeature.Queries.GetAll;
using KuyumHesap.Application.Features.TaskItemFeature.Queries.GetAllMyTask;
using KuyumHesap.Application.Features.TaskItemFeature.Queries.GetById;
using KuyumHesap.Application.Features.UserFeature.Dtos;
using KuyumHesap.Application.Features.UserFeature.Queries.GetAll;
using KuyumHesap.Application.Features.UserFeature.Queries.GetById;
using KuyumHesap.Domain.Entities;

namespace KuyumHesap.Persistence.Common.Concrete.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Stock, CreateStockCommandRequest>().ReverseMap();
            CreateMap<Stock, UpdateStockCommandRequest>().ReverseMap();


            CreateMap<Currency, CurrencyResponseDto>().ReverseMap();
            CreateMap<StockGroup, StockGroupResponseDto>().ReverseMap();
            CreateMap<AccountType, GetAllAccountTypeQueryResponse>().ReverseMap();
            CreateMap<AccountType, GetByIdAccountTypeQueryResponse>().ReverseMap();
            CreateMap<Account, GetByIdAccountQueryResponse>().ReverseMap();
            CreateMap<Account, GetAllAccountQueryResponse>().ReverseMap();
            CreateMap<Account, UpdateAccountCommandRequest>().ReverseMap();
            CreateMap<Account, CheckSoftDuplicateQueryResponse>().ReverseMap();
            CreateMap<StockGroup, GetStockGroupQueryResponse>().ReverseMap();
            CreateMap<StockType, GetStockTypeQueryResponse>().ReverseMap();
            CreateMap<Stock, GetStockQueryResponse>().ReverseMap();
            CreateMap<ProductType, GetProductTypeQueryResponse>().ReverseMap();
            CreateMap<Account, GetPackerQueryResponse>().ReverseMap();
            CreateMap<BarcodeDetail, BarcodeDetailResponseDto>().ReverseMap();
            CreateMap<BarcodeHeader, GetByIdBarcodeHeaderQueryResponse>().ReverseMap();
            CreateMap<Currency, GetAllExchangeQueryResponse>().ReverseMap();
            CreateMap<MovementType, GetAllMovementTypeQueryResponse>().ReverseMap();
            CreateMap<MovementType, GetByIdMovementTypeQueryResponse>().ReverseMap();
            CreateMap<ProductType, GetAllProductTypeQueryResponse>().ReverseMap();
            CreateMap<ProductType, GetByIdProductTypeQueryResponse>().ReverseMap();
            CreateMap<Movements, GetAllReceiptMovementDto>().ReverseMap();
            CreateMap<Receipt, GetByIdReceiptQueryResponse>().ReverseMap();
            CreateMap<Stock, GetAllStockQueryResponse>().ReverseMap();
            CreateMap<Stock, GetByIdStockQueryResponse>().ReverseMap();
            CreateMap<StockGroup, GetAllStockGroupQueryResponse>().ReverseMap();
            CreateMap<StockGroup, GetByIdStockGroupQueryResponse>().ReverseMap();
            CreateMap<StockType, GetAllStockTypeQueryResponse>().ReverseMap();
            CreateMap<StockType, GetAllStockTypeQueryResponse>()
        .ForMember(d => d.Currency, opt => opt.MapFrom(s => s.Currency));
            CreateMap<StockType, GetAllStockTypeQueryResponse>()
.ForMember(d => d.StockGroup, opt => opt.MapFrom(s => s.StockGroup));

            CreateMap<StockType, GetByIdStockTypeQueryResponse>().ReverseMap();
            CreateMap<TaskItem, GetAllTaskItemQueryResponse>().ReverseMap();
            CreateMap<TaskItem, GetAllMyTaskQueryResponse>().ReverseMap();
            CreateMap<TaskItem, GetByIdTaskItemQueryResponse>().ReverseMap();
            CreateMap<Users, UserResponseDto>().ReverseMap();
            CreateMap<TaskItem, GetAllMyTaskQueryResponseDto>().ReverseMap();
            CreateMap<Currency, ExchangeForCurrencyResponseDto>().ReverseMap();

            CreateMap<ExchangeRate, GetAllExchangeQueryResponse>()
          .ForMember(d => d.CurrencyDto, opt => opt.MapFrom(s => s.Currency));

            CreateMap<Currency, ExchangeForCurrencyResponseDto>();

            CreateMap<ExchangeRate, GetByIdExchangeQueryResponse>()
   .ForMember(d => d.CurrencyDto, opt => opt.MapFrom(s => s.Currency));

            CreateMap<Currency, GetAllCurrencyQueryResponse>();

            CreateMap<Users, GetByIdUserQueryResponse>().ReverseMap();
            CreateMap<Roles, RoleResponseDto>().ReverseMap();

            CreateMap<Users, GetAllUserQueryResponse>().ReverseMap();

            CreateMap<Users, GetAllUserQueryResponse>()
.ForMember(d => d.RoleResponse, opt => opt.MapFrom(s => s.Role));

            CreateMap<Users, GetByIdUserQueryResponse>()
.ForMember(d => d.RoleResponseDto, opt => opt.MapFrom(s => s.Role));

            // Stock -> Response
            CreateMap<Stock, GetAllStockQueryResponse>()
                .ForMember(d => d.stockTypeResponseDto, opt => opt.MapFrom(s => s.StockType))
                .ForMember(d => d.groupResponseDto, opt => opt.MapFrom(s => s.StockGroup));

            // StockType -> StockTypeResponseDto
            CreateMap<StockType, StockTypeResponseDto>()
         .ForMember(d => d.stockGroupsResponseDto, opt => opt.MapFrom(s => s.StockGroup))
         .ForMember(d => d.currencyResponseDto, opt => opt.MapFrom(s => s.Currency));


 
            // Nested
            CreateMap<StockGroup, StockGroupResponseDto>();
            CreateMap<StockGroup, StockGroupsResponseDto>(); // senin DTO’n farklı olduğu için bunu da ekliyorum
            CreateMap<Currency, CurrencyResponseDto>();

            CreateMap<Stock, GetByIdStockQueryResponse>()
.ForMember(d => d.groupResponseDto, opt => opt.MapFrom(s => s.StockGroup));
            CreateMap<Stock, GetByIdStockQueryResponse>()
.ForMember(d => d.stockTypeResponseDto, opt => opt.MapFrom(s => s.StockType));
        }
    }
}
