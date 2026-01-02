using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using KuyumHesap.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KuyumHesap.Application.Features.TaskItemFeature.Queries.GetAll
{
    public class GetAllTaskItemQueryHandler : BaseHandler, IRequestHandler<GetAllTaskItemQueryRequest, ResponseDto<List<GetAllTaskItemQueryResponse>>>
    {
        public GetAllTaskItemQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetAllTaskItemQueryResponse>>> Handle(
     GetAllTaskItemQueryRequest request,
     CancellationToken cancellationToken)
        {

            Expression<Func<TaskItem, bool>> predicate = g =>
                (request.UserId > 0
                    || g.AssignedToUserId == request.UserId
                    || g.AssignedByUserId == request.UserId);


            Func<IQueryable<TaskItem>, IOrderedQueryable<TaskItem>> orderBy = q =>
                q.OrderBy(g =>
                        g.Priority == PriorityEnum.Acil ? 4 :
                        g.Priority == PriorityEnum.Yüksek ? 3 :
                        g.Priority == PriorityEnum.Normal ? 2 :
                        g.Priority == PriorityEnum.Düsük ? 1 : 0)
                 .ThenByDescending(g => g.CreatedAt);


            var data = await unitOfWork.GetReadRepository<TaskItem>()
                .GetAllAsync(
                    predicate: predicate,
                    include: q => q
                        .Include(x => x.AssignedByUser)
                        .Include(x => x.AssignedToUser),
                    orderBy: orderBy
                );

            var response = mapper.Map<GetAllTaskItemQueryResponse, TaskItem>(data);

            return new ResponseDto<List<GetAllTaskItemQueryResponse>>().Success(response);
        }
    }
}
