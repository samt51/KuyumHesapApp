using KuyumHesap.Application.Common.Models;
using MediatR;

namespace KuyumHesap.Application.Features.ExchangeFeature.Commands.Update
{
    public class UpdateExchangeCommandRequest : IRequest<ResponseDto<UpdateExchangeCommandResponse>>
    {
        public int Id { get; set; }
        /// <summary>
        /// Kurun geçerli olduğu tarih
        /// </summary>
        public DateTime RateDate { get; set; }

        /// <summary>
        /// Döviz kuru kimliği
        /// </summary>
        public int ExchangeRateId { get; set; }

        /// <summary>
        /// Alış kuru
        /// </summary>
        public decimal BuyRate { get; set; }

        /// <summary>
        /// Satış kuru
        /// </summary>
        public decimal SellRate { get; set; }

        /// <summary>
        /// Bir önceki günün kapanış kuru
        /// </summary>
        public decimal? PreviousCloseRate { get; set; }
    }
}
