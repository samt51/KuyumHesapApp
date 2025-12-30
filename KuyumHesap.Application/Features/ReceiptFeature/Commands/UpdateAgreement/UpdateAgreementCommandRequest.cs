using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.ReceiptFeature.Commands.UpdateAgreement
{
    public class UpdateAgreementCommandRequest : IRequest<ResponseDto<UpdateAgreementCommandResponse>>
    {
        public bool Agreement { get; set; }
        public int Id { get; set; }
    }
}
