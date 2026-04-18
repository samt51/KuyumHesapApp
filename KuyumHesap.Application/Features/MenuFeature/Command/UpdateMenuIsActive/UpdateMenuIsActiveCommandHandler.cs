using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities;
using MediatR;

namespace KuyumHesap.Application.Features.MenuFeature.Command.UpdateMenuIsActive
{
    public class UpdateMenuIsActiveCommandHandler : BaseHandler, IRequestHandler<UpdateMenuIsActiveCommandRequest, ResponseDto<UpdateMenuIsActiveCommandResponse>>
    {
        public UpdateMenuIsActiveCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<UpdateMenuIsActiveCommandResponse>> Handle(UpdateMenuIsActiveCommandRequest request, CancellationToken cancellationToken)
        {
            var listData = new List<Menu>();
            var data = await unitOfWork.GetReadRepository<Menu>().GetAsync(c => !c.IsDeleted && c.Id == request.Id);

            var parentData = await unitOfWork.GetReadRepository<Menu>().GetAllAsync(c => !c.IsDeleted && c.ParentId == request.Id);

            data.IsActive = request.IsActive;

            listData.Add(data);


            foreach (var item in parentData)
            {
                item.IsActive = request.IsActive;

                listData.Add(item);
            }





            await unitOfWork.OpenTransactionAsync(cancellationToken);

            unitOfWork.GetWriteRepository<Menu>().UpdateRange(listData, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            await unitOfWork.CommitAsync(cancellationToken);

            return new ResponseDto<UpdateMenuIsActiveCommandResponse>().Success();
        }
    }
}
