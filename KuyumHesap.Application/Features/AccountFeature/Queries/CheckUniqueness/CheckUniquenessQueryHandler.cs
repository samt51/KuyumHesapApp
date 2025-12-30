using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;
using System.Linq.Expressions;

namespace KuyumHesap.Application.Features.AccountFeature.Queries.CheckUniqueness
{
    public class CheckUniquenessQueryHandler : BaseHandler, IRequestHandler<CheckUniquenessQueryRequest, ResponseDto<CheckUniquenessQueryResponse>>
    {
        public CheckUniquenessQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<CheckUniquenessQueryResponse>> Handle(
     CheckUniquenessQueryRequest request,
     CancellationToken cancellationToken)
        {
            var type = request.Type?.Trim().ToLowerInvariant();
            var value = request.Value?.Trim();

            if (string.IsNullOrWhiteSpace(type) || string.IsNullOrWhiteSpace(value))
                return new ResponseDto<CheckUniquenessQueryResponse>().Fail("Type veya Value boş olamaz.");

            var currentId = request.CurrentId;


            Expression<Func<Account, bool>> predicate = type switch
            {
                "nationalidnumber" => x => !x.IsDeleted
                                          && x.NationalIdNumber == value
                                          && (currentId == null || x.Id != currentId),

                "mobilephone" => x => !x.IsDeleted
                                      && x.MobilePhone == value
                                      && (currentId == null || x.Id != currentId),

                "taxnumber" => x => !x.IsDeleted
                                    && x.TaxNumber == value
                                    && (currentId == null || x.Id != currentId),

                _ => null!
            };

            if (predicate is null)
                return new ResponseDto<CheckUniquenessQueryResponse>().Fail("Geçersiz type.");

            // Çakışma var mı?
            var any = await unitOfWork
                .GetReadRepository<Account>().FindAsync(predicate);



            var response = new CheckUniquenessQueryResponse
            {
                isUnique = any == null ? false : true,
                AccountName = any == null ? string.Empty : any.AccountName
            };

            return new ResponseDto<CheckUniquenessQueryResponse>().Success(response);
        }

    }
}
