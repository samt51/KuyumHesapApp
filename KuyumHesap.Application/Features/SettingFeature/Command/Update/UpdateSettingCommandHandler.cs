using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Domain.Entities;
using MediatR;
using KuyumHesap.Application.Common.Models;

namespace KuyumHesap.Application.Features.SettingFeature.Command.Update
{
    public class UpdateSettingCommandHandler : BaseHandler, IRequestHandler<UpdateSettingCommandRequest, ResponseDto<UpdateSettingCommandResponse>>
    {
        public UpdateSettingCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<UpdateSettingCommandResponse>> Handle(UpdateSettingCommandRequest request, CancellationToken cancellationToken)
        {
            var repo = unitOfWork.GetWriteRepository<Setting>();
            
            foreach (var item in request.Settings)
            {
                var setting = await unitOfWork.GetReadRepository<Setting>().GetAsync(x => x.Id == item.Id && !x.IsDeleted);
                if (setting != null)
                {
                    setting.Value = item.Value;
                    setting.ModifyDate = DateTime.Now;
                    await repo.UpdateAsync(setting);
                }
            }

            await unitOfWork.SaveAsync();

            return new ResponseDto<UpdateSettingCommandResponse>().Success(new UpdateSettingCommandResponse
            {
                Success = true,
                Message = "Ayarlar başarıyla güncellendi."
            });
        }
    }
}
