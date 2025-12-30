using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KuyumHesap.Application.Features.TaskItemFeature.Queries.GetById
{
    public class GetByIdTaskItemQueryHandler : BaseHandler, IRequestHandler<GetByIdTaskItemQueryRequest, ResponseDto<GetByIdTaskItemQueryResponse>>
    {
        public GetByIdTaskItemQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<GetByIdTaskItemQueryResponse>> Handle(
      GetByIdTaskItemQueryRequest request,
      CancellationToken cancellationToken)
        {
            var data = await unitOfWork.GetReadRepository<TaskItem>()
                .GetAsync(
                    predicate: g => g.Id == request.Id,
                    include: q => q
                        .Include(x => x.Users)
                        .Include(x => x.AssignedToUser)
                );

            var response = mapper.Map<GetByIdTaskItemQueryResponse, TaskItem>(data);

            return new ResponseDto<GetByIdTaskItemQueryResponse>().Success(response);
        }

    }
}
