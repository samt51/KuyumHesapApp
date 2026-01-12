using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Common.Models.Dtos;
using KuyumHesap.Domain.Entities;
using KuyumHesap.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KuyumHesap.Application.Features.TaskItemFeature.Queries.GetAllMyTask
{
    public class GetAllMyTaskQueryHandler : BaseHandler, IRequestHandler<GetAllMyTaskQueryRequest, ResponseDto<GetAllMyTaskQueryResponse>>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GetAllMyTaskQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ResponseDto<GetAllMyTaskQueryResponse>> Handle(
        GetAllMyTaskQueryRequest request,
        CancellationToken cancellationToken)
        {
            var userIdStr = _httpContextAccessor.HttpContext?.User?
                .FindFirst("Id")?.Value;

            int.TryParse(userIdStr, out var userId);



            Expression<Func<TaskItem, bool>> predicate = g =>
    g.AssignedToUserId == userId || g.AssignedByUserId == userId;


            Func<IQueryable<TaskItem>, IOrderedQueryable<TaskItem>> orderBy = q =>
                q.OrderBy(g =>
                        g.Priority == PriorityEnum.Acil ? 1 :
                        g.Priority == PriorityEnum.Yüksek ? 2 :
                        g.Priority == PriorityEnum.Normal ? 3 :
                        g.Priority == PriorityEnum.Düsük ? 4 : 99)
                 .ThenByDescending(g => g.CreatedAt);

            // ✅ 4) DB’den çek
            var entities = await unitOfWork.GetReadRepository<TaskItem>()
                .GetAllAsync(
                    predicate: predicate,
                    include: q => q
                        .Include(x => x.AssignedByUser)
                        .Include(x => x.AssignedToUser),
                    orderBy: orderBy
                );

            // ✅ 5) Düz liste DTO
            var all = mapper.Map<GetAllMyTaskQueryResponseDto, TaskItem>(entities);


            var today = DateTime.UtcNow.Date;
            var sevenDaysLater = today.AddDays(7);

            all = all
                .Where(x => x.DueDate.HasValue && x.Status != "Tamamlandı")
                .ToList();

            var past = all
                .Where(x => x.DueDate!.Value.Date < today)
                .ToList();

            var current = all
                .Where(x => x.DueDate!.Value.Date == today)
                .ToList();

            var future = all
                .Where(x => x.DueDate!.Value.Date <= sevenDaysLater)
                .ToList();


            var response = new GetAllMyTaskQueryResponse
            {
                PastMissions = past,
                CurrentMissions = current,
                FutureMissions = future
            };

            return new ResponseDto<GetAllMyTaskQueryResponse>().Success(response);
        }
    }
}

