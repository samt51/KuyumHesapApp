using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.TaskItemFeature.Queries.GetAll;
using KuyumHesap.Domain.Entities;
using KuyumHesap.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KuyumHesap.Application.Features.TaskItemFeature.Queries.GetAllMyTask
{
    public class GetAllMyTaskQueryHandler : BaseHandler, IRequestHandler<GetAllMyTaskQueryRequest, ResponseDto<List<GetAllMyTaskQueryResponse>>>
    {
        public GetAllMyTaskQueryHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<List<GetAllMyTaskQueryResponse>>> Handle(GetAllMyTaskQueryRequest request, CancellationToken cancellationToken)
        {
            int userId = 0;

            Expression<Func<TaskItem, bool>> predicate = g =>
               (userId > 0
                   || g.AssignedToUserId == userId
                   || g.AssignedByUserId == userId);


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

            var response = mapper.Map<GetAllMyTaskQueryResponse,TaskItem>(data);

            return new ResponseDto<List<GetAllMyTaskQueryResponse>>().Success(response);
        }
    }
}

