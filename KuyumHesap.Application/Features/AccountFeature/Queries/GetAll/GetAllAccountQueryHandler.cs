using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KuyumHesap.Application.Features.AccountFeature.Queries.GetAll
{
    public class GetAllAccountQueryHandler : BaseHandler, IRequestHandler<GetAllAccountQueryRequest, ResponseDto<List<GetAllAccountQueryResponse>>>
    {
        public GetAllAccountQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetAllAccountQueryResponse>>> Handle(GetAllAccountQueryRequest request, CancellationToken cancellationToken)
        {

            Expression<Func<Account, bool>> predicate = x => !x.IsDeleted;

            if (!string.IsNullOrWhiteSpace(request.AccountTypeName))
            {
                var typeName = request.AccountTypeName.Trim();
                predicate = x => x.AccountType.AccountTypeName == typeName;
            }
            var data = await unitOfWork.GetReadRepository<Account>().GetAllAsync(predicate, include: q => q.Include(c => c.AccountType));

            var response = new List<GetAllAccountQueryResponse>();

            foreach (var item in data)
            {
                response.Add(new GetAllAccountQueryResponse
                {
                    AccountId = item.Id,
                    AccountName = item.AccountName,
                    IsActive = item.IsActive,
                    AccountTypeId = item.AccountTypeId,
                    AccountTypeName = item.AccountType?.AccountTypeName ?? string.Empty,
                    Tezgahtar = item.IsCashier
                });
            }

            return new ResponseDto<List<GetAllAccountQueryResponse>>().Success(response);

        }

    }
}
