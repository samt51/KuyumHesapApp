
using AutoMapper;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Common.Models.Dtos;
using KuyumHesap.Application.Common.Models.Dtos.ResponseDtos;
using KuyumHesap.Application.Features.AccountFeature.Command.Create;
using KuyumHesap.Application.Features.AccountFeature.Command.Update;
using KuyumHesap.Application.Features.AccountFeature.Queries.CheckSoftDuplicate;
using KuyumHesap.Application.Features.AccountFeature.Queries.GetAll;
using KuyumHesap.Application.Features.AccountFeature.Queries.GetById;
using KuyumHesap.Application.Features.AccountTypeFeature.Command.Create;
using KuyumHesap.Application.Features.AccountTypeFeature.Queries.GetAll;
using KuyumHesap.Application.Features.AccountTypeFeature.Queries.GetById;
using KuyumHesap.Application.Features.BarcodeFeature.Queries.GetPacker;
using KuyumHesap.Application.Features.BarcodeFeature.Queries.GetProductType;
using KuyumHesap.Application.Features.BarcodeFeature.Queries.GetStock;
using KuyumHesap.Application.Features.BarcodeFeature.Queries.GetStockType;
using KuyumHesap.Application.Features.BarcodeHeaderFeature.Dtos;
using KuyumHesap.Application.Features.BarcodeHeaderFeature.Queries.GetAll;
using KuyumHesap.Application.Features.BarcodeHeaderFeature.Queries.GetById;
using KuyumHesap.Application.Features.CureFeature.Queries.GetUpdatedDailyCure;
using KuyumHesap.Application.Features.CurrecyFeature.Queries.GetAll;
using KuyumHesap.Application.Features.ExchangeFeature.Dtos;
using KuyumHesap.Application.Features.ExchangeFeature.Queries.GetAll;
using KuyumHesap.Application.Features.ExchangeFeature.Queries.GetById;
using KuyumHesap.Application.Features.MovementFeature.Dtos;
using KuyumHesap.Application.Features.MovementFeature.Queries.GetAll;
using KuyumHesap.Application.Features.MovementFeature.Queries.GetById;
using KuyumHesap.Application.Features.ProductTypeFeature.Queries.GetAll;
using KuyumHesap.Application.Features.ProductTypeFeature.Queries.GetById;
using KuyumHesap.Application.Features.ReceiptFeature.Commands.Create;
using KuyumHesap.Application.Features.ReceiptFeature.Commands.Update;
using KuyumHesap.Application.Features.ReceiptFeature.Queries.GetAll;
using KuyumHesap.Application.Features.ReceiptFeature.Queries.GetAll.Dtos;
using KuyumHesap.Application.Features.ReceiptFeature.Queries.GetById;
using KuyumHesap.Application.Features.ReceiptFeature.Queries.GetEkstreByCustomerId;
// Added namespaces for the target response types
using KuyumHesap.Application.Features.ReceiptFeature.Queries.GetReceiptByCustomerIdAndDates;
using KuyumHesap.Application.Features.SettingFeature.Queries.GetAll;
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
using KuyumHesap.Application.Features.UserFeature.Commands.Create;
using KuyumHesap.Application.Features.UserFeature.Commands.Roles.Update;
using KuyumHesap.Application.Features.UserFeature.Dtos;
using KuyumHesap.Application.Features.UserFeature.Queries.GetAll;
using KuyumHesap.Application.Features.UserFeature.Queries.GetById;
using KuyumHesap.Application.Features.UserFeature.Queries.Roles.GetAll;
using KuyumHesap.Application.Features.UserFeature.Queries.Roles.GetById;
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
            // Mapping for creating AccountType from request
            CreateMap<CreateAccountTypeCommandRequest, AccountType>().ReverseMap();
            CreateMap<AccountType, GetAllAccountTypeQueryResponse>().ReverseMap();
            CreateMap<AccountType, GetByIdAccountTypeQueryResponse>().ReverseMap();
            CreateMap<Account, CreateAccountCommandRequest>().ReverseMap();
            CreateMap<Account, GetByIdAccountQueryResponse>().ReverseMap();
            CreateMap<Account, GetAllAccountQueryResponse>().ReverseMap();
            CreateMap<Account, UpdateAccountCommandRequest>().ReverseMap();
            CreateMap<Account, CheckSoftDuplicateQueryResponse>().ReverseMap();
            CreateMap<StockGroup, GetStockGroupQueryResponse>().ReverseMap();
            CreateMap<StockType, GetStockTypeQueryResponse>().ReverseMap();
            CreateMap<Stock, GetStockQueryResponse>().ReverseMap();
            CreateMap<ProductType, GetProductTypeQueryResponse>().ReverseMap();
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
            // Receipt -> GetByIdReceiptQueryResponse mapping removed generic ReverseMap; replaced below with explicit mappings.
            CreateMap<Stock, GetAllStockQueryResponse>()
                    .ForMember(d => d.StockTypeName, opt => opt.MapFrom(s => s.StockType != null ? s.StockType.StockTypeName : string.Empty))
                    .ForMember(d => d.StockGroupName, opt => opt.MapFrom(s => s.StockGroup != null ? s.StockGroup.StockGroupName : string.Empty))
                    .ForMember(d => d.UnitName, opt => opt.MapFrom(s => s.UnitName))
                    .ForMember(d => d.StockUnitId, opt => opt.MapFrom(s => s.StockUnitId))
                    .ForMember(d => d.LaborUnitId, opt => opt.MapFrom(s => s.LaborUnitId))
                    // LaborUnit (string) alınacak: StockType -> Currency -> CurrencyCode
                    .ForMember(d => d.LaborUnit, opt => opt.MapFrom(s => s.StockType != null && s.StockType.Currency != null ? s.StockType.Currency.CurrencyCode : string.Empty))
                    .ForMember(d => d.MillRate, opt => opt.MapFrom(s => s.MillRate))
                    .ForMember(d => d.IsActive, opt => opt.MapFrom(s => s.IsActive));
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




            CreateMap<StockType, StockTypeResponseDto>()
         .ForMember(d => d.stockGroupsResponseDto, opt => opt.MapFrom(s => s.StockGroup))
         .ForMember(d => d.currencyResponseDto, opt => opt.MapFrom(s => s.Currency));

            CreateMap<StockGroup, StockGroupResponseDto>();
            CreateMap<StockGroup, StockGroupsResponseDto>();
            CreateMap<Currency, CurrencyResponseDto>();

            CreateMap<Stock, GetByIdStockQueryResponse>()
.ForMember(d => d.groupResponseDto, opt => opt.MapFrom(s => s.StockGroup));
            CreateMap<Stock, GetByIdStockQueryResponse>()
.ForMember(d => d.stockTypeResponseDto, opt => opt.MapFrom(s => s.StockType));

            CreateMap<BarcodeHeader, GetAllBarcodeHeaderQueryResponse>()
.ForMember(d => d.barcodeDetails, opt => opt.MapFrom(s => s.BarcodeDetails));

            CreateMap<BarcodeDetail, BarcodeDetailResponseDto>().ReverseMap();

            //            CreateMap<BarcodeHeader, GetByIdBarcodeHeaderQueryResponse>()
            //.ForMember(d => d.barcodedetails, opt => opt.MapFrom(s => s.BarcodeDetails));

            // Receipt mappings
            CreateMap<Receipt, CreateReceiptCommandRequest>().ReverseMap();

            // Map UpdateReceiptCommandRequest -> Receipt but ignore Movements here because movements
            // are handled explicitly in the update handler to avoid EF tracking issues.
            CreateMap<UpdateReceiptCommandRequest, Receipt>()
                .ForMember(d => d.Movements, opt => opt.Ignore())
                .ReverseMap();

            // Explicit mapping between DTO.MovementId and entity.Id to preserve incoming IDs on update
            CreateMap<CreateMovementReceiptRequestDto, Movements>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.MovementId))
                .ReverseMap()
                .ForMember(d => d.MovementId, opt => opt.MapFrom(s => s.Id));

            CreateMap<Movements, Movements>().ReverseMap();

            // Movements -> GetMovementByCustomerIdResponse (existing)
            CreateMap<Movements, GetMovementByCustomerIdResponse>()
                    .ForMember(d => d.TransactionCode, opt => opt.MapFrom(s => s.TransactionType != null ? s.TransactionType.TransactionCode : null))
                    .ForMember(d => d.TransactionName, opt => opt.MapFrom(s => s.TransactionType != null ? s.TransactionType.TransactionName : null))
                    .ForMember(d => d.AccountName, opt => opt.MapFrom(s => s.Account != null ? s.Account.AccountName : null))
                    .ForMember(d => d.AccountTypeId, opt => opt.MapFrom(s => s.Account != null ? s.Account.AccountTypeId : 0))
                    .ForMember(d => d.AccountTypeName, opt => opt.MapFrom(s => s.Account != null && s.Account.AccountType != null ? s.Account.AccountType.AccountTypeName : null))
                    .ForMember(d => d.ForeignCurrencyCode, opt => opt.NullSubstitute(string.Empty))
                    .ForMember(d => d.CounterCurrencyCode, opt => opt.NullSubstitute(string.Empty))
                    .ReverseMap();

            // Receipt -> GetAllReceiptQueryResponse
            CreateMap<Receipt, GetAllReceiptQueryResponse>()
                .ForMember(d => d.AccountName, opt => opt.MapFrom(s => s.Account != null ? s.Account.AccountName : null))
                .ForMember(d => d.AccountTypeId, opt => opt.MapFrom(s => s.Account != null ? s.Account.AccountTypeId : 0))
                .ForMember(d => d.AccountTypeName, opt => opt.MapFrom(s => s.Account != null && s.Account.AccountType != null ? s.Account.AccountType.AccountTypeName : null))
                // map Movements to GetAllReceiptMovementDto if property exists on response
                .ForMember(d => d.Movements, opt => opt.MapFrom(s => s.Movements))
                .ReverseMap();

            // Receipt -> GetByIdReceiptQueryResponse (explicit)
            CreateMap<Receipt, GetByIdReceiptQueryResponse>()
                .ForMember(d => d.AccountName, opt => opt.MapFrom(s => s.Account != null ? s.Account.AccountName : null))
                .ForMember(d => d.AccountTypeId, opt => opt.MapFrom(s => s.Account != null ? s.Account.AccountTypeId : 0))
                .ForMember(d => d.AccountTypeName, opt => opt.MapFrom(s => s.Account != null && s.Account.AccountType != null ? s.Account.AccountType.AccountTypeName : null))
                .ForMember(d => d.Movements, opt => opt.MapFrom(s => s.Movements));

            // Receipt -> GetReceiptByCustomerIdAndDatesResponse
            CreateMap<Receipt, GetReceiptByCustomerIdAndDatesResponse>()
                .ForMember(d => d.AccountName, opt => opt.MapFrom(s => s.Account != null ? s.Account.AccountName : null))
                .ForMember(d => d.AccountTypeId, opt => opt.MapFrom(s => s.Account != null ? s.Account.AccountTypeId : 0))
                .ForMember(d => d.AccountTypeName, opt => opt.MapFrom(s => s.Account != null && s.Account.AccountType != null ? s.Account.AccountType.AccountTypeName : null))
                .ForMember(d => d.Movements, opt => opt.MapFrom(s => s.Movements))
                .ReverseMap();

            CreateMap<GetUpdatedDailyCureResponse, DailyCureDataDto.Data>().ReverseMap();
            CreateMap<Setting, GetAllSettingQueryResponse>().ReverseMap();

            CreateMap<GetAllRolesQueryResponse, Roles>().ReverseMap();

            CreateMap<GetByIdRolesQueryResponse, Roles>().ReverseMap();

            CreateMap<UpdateRolesCommandRequest, Roles>().ReverseMap();
            CreateMap<CreateUserCommandRequest, Roles>().ReverseMap();
        }
    }
}