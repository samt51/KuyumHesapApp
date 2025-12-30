using KuyumHesap.Api.Common.Cont;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Application.Features.TaskItemFeature.Commands.Create;
using KuyumHesap.Application.Features.TaskItemFeature.Commands.Delete;
using KuyumHesap.Application.Features.TaskItemFeature.Commands.Update;
using KuyumHesap.Application.Features.TaskItemFeature.Queries.GetAll;
using KuyumHesap.Application.Features.TaskItemFeature.Queries.GetAllMyTask;
using KuyumHesap.Application.Features.TaskItemFeature.Queries.GetById;
using KuyumHesap.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace KuyumHesap.Api.Controllers.TaskItemCont
{
    public class TaskItemController : BaseController
    {
        private readonly IMediator _mediator;
        public TaskItemController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ResponseDto<List<GetAllTaskItemQueryResponse>>> GetAllAsync(int userId, TaskStateEnum status, CancellationToken token)
        {
            return await _mediator.Send(new GetAllTaskItemQueryRequest { Status = status, UserId = userId }, token);
        }
        [HttpGet("{id}")]
        public async Task<ResponseDto<GetByIdTaskItemQueryResponse>> GetByIdAsync(int id, CancellationToken token)
        {
            return await _mediator.Send(new GetByIdTaskItemQueryRequest { Id = id }, token);
        }
        [HttpPost]
        public async Task<ResponseDto<CreateTaskItemCommandResponse>> CreateAsync(CreateTaskItemCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }
        [HttpPost]
        public async Task<ResponseDto<UpdateTaskItemCommandResponse>> UpdateAsync(UpdateTaskItemCommandRequest request, CancellationToken token)
        {
            return await _mediator.Send(request, token);
        }
        [HttpDelete("{id}")]
        public async Task<ResponseDto<DeleteTaskItemCommandResponse>> DeleteAsync(int id, CancellationToken token)
        {
            return await _mediator.Send(new DeleteTaskItemCommandRequest(id), token);
        }
        [HttpGet]
        public async Task<ResponseDto<List<GetAllMyTaskQueryResponse>>> GetAllMyTaskAsync(CancellationToken token)
        {
            return await _mediator.Send(new GetAllMyTaskQueryRequest(), token);
        }
    }
}
