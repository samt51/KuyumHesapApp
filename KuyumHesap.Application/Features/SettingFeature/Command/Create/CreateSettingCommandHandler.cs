using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Domain.Entities;
using MediatR;
using KuyumHesap.Application.Common.Models;

namespace KuyumHesap.Application.Features.SettingFeature.Command.Create
{
    public class CreateSettingCommandHandler : BaseHandler, IRequestHandler<CreateSettingCommandRequest, ResponseDto<CreateSettingCommandResponse>>
    {
        public CreateSettingCommandHandler(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<ResponseDto<CreateSettingCommandResponse>> Handle(CreateSettingCommandRequest request, CancellationToken cancellationToken)
        {
            var repo = unitOfWork.GetWriteRepository<Setting>();
            var readRepo = unitOfWork.GetReadRepository<Setting>();

            var existing = await readRepo.GetAsync(x => x.Key == request.Key && !x.IsDeleted);
            if (existing != null)
            {
                return new ResponseDto<CreateSettingCommandResponse>().Fail("Bu ayar anahtarı zaten mevcut.");
            }

            var newSetting = new Setting
            {
                Key = request.Key,
                Value = request.Value,
                Description = request.Description,
                CreatedDate = DateTime.Now,
                CreatedByUserId = 1
            };

            await repo.AddAsync(newSetting);
            await unitOfWork.SaveAsync();

            return new ResponseDto<CreateSettingCommandResponse>().Success(new CreateSettingCommandResponse
            {
                Success = true,
                Message = "Ayar başarıyla oluşturuldu."
            });
        }
    }
}
