using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.ReceiptFeature.Queries.GetAll.Dtos;
using KuyumHesap.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Application.Features.ReceiptFeature.Queries.GetAll
{
    public class GetAllReceiptQueryHandler : BaseHandler, IRequestHandler<GetAllReceiptQueryRequest, ResponseDto<List<GetAllReceiptQueryResponse>>>
    {
        public GetAllReceiptQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetAllReceiptQueryResponse>>> Handle(
       GetAllReceiptQueryRequest request,
       CancellationToken cancellationToken)
        {
            var receipts = await unitOfWork
                .GetReadRepository<Receipt>()
                .GetAllAsync(
                    x => !x.IsDeleted,
                    include: q => q.Include(r => r.Movements),
                    orderBy: q => q.OrderByDescending(r => r.ReceiptDate)
                );

            var rsp = new List<GetAllReceiptQueryResponse>();

            foreach (var item in receipts)
            {
                rsp.Add(new GetAllReceiptQueryResponse
                {
                    Id = item.Id,
                    ReceiptNumber = item.ReceiptNumber,
                    ReceiptDate = item.ReceiptDate,
                    CurrentAccountId = item.CurrentAccountId,
                    EmployeeId = item.EmployeeId,
                    Description = item.Description,
                    IsCustomerReceipt = item.IsCustomerReceipt,

                    // Eğer response içinde hareketler de lazım ise:
                    Movements = mapper.Map< GetAllReceiptMovementDto ,
                    Movements >(item.Movements)
                });
            }

            return new ResponseDto<List<GetAllReceiptQueryResponse>>().Success(rsp);
        }

    }
}
