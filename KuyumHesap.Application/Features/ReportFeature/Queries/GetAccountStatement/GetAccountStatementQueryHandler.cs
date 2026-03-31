using KuyumHesap.Application.Common.Abstractions;
using KuyumHesap.Application.Common.Abstractions.Mapper;
using KuyumHesap.Application.Common.Abstractions.SqlViewAndFuncQuery;
using KuyumHesap.Application.Common.Abstractions.UnitOfWorks;
using KuyumHesap.Application.Common.Models;
using KuyumHesap.Domain.Entities.VwModels;
using MediatR;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetAccountStatement
{
    public class GetAccountStatementQueryHandler : BaseHandler, IRequestHandler<GetAccountStatementQueryRequest, ResponseDto<GetAccountStatementQueryResponse>>
    {
        private readonly IAccountStatementQuery _accountStatementQuery;
        public GetAccountStatementQueryHandler(IAccountStatementQuery accountStatementQuery, IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _accountStatementQuery = accountStatementQuery;
        }

        public async Task<ResponseDto<GetAccountStatementQueryResponse>> Handle(
     GetAccountStatementQueryRequest request,
     CancellationToken cancellationToken)
        {
            var responseDto = new GetAccountStatementQueryResponse();
            var baslangic = request.StartDate.Date;
            var bitis = request.FinishDate.Date.AddDays(1).AddTicks(-1);

            var q = await unitOfWork.GetReadRepository<EkstreSatirViewModel>().GetAllAsync();


            var devreden = q
                .Where(x => x.HesapID == request.AccountId && x.Tarih < baslangic)
                .GroupBy(x => x.BakiyeBirimi)
                .Select(g => new EkstreBakiyeViewModel
                {
                    DovizKodu = g.Key,
                    Bakiye = g.Sum(x => x.GirisMi ? x.BakiyeEtkiMiktari : -x.BakiyeEtkiMiktari)
                })
                .ToList();


            responseDto.DevredenBakiyeler = devreden;



            var geciciDevreden = q
                .Where(x => x.HesapID == request.AccountId && x.Tarih >= request.StartDate.Date && x.Tarih <= request.FinishDate.Date)
                .OrderBy(x => x.Tarih)
                .OrderBy(x => x.HareketID)
                .Select(g => new EkstreSatirViewModel
                {
                    StokAdi = g.StokAdi,
                    SonBakiye = g.SonBakiye,
                    Tarih = g.Tarih,
                    StokID = g.StokID,
                    Miktar = g.Miktar,
                    Islem = g.Islem,
                    Iscilik = g.Iscilik,
                    IscBrm = g.IscBrm,
                    IscAdet = g.IscAdet,
                    Aciklama = g.Aciklama,
                    Birim = g.Birim,
                    BakiyeBirimi = g.BakiyeBirimi,
                    BakiyeEtkiMiktari = g.BakiyeEtkiMiktari,
                    EskiBakiye = g.EskiBakiye,
                    FisID = g.FisID,
                    GirisMi = g.GirisMi,
                    HareketID = g.HareketID,
                    HareketTipID = g.HareketTipID,
                    HesapID = g.HesapID,
                    KarsilikBirim = g.KarsilikBirim,
                    KarsilikKuru = g.KarsilikKuru,
                    KarsilikMiktar = g.KarsilikMiktar,
                    Kur = g.Kur,
                    Milyem = g.Milyem,
                    Mutabakat = g.Mutabakat,
                    Tutar_BPBR = g.Tutar_BPBR,
                    UrunHasDegeri = g.UrunHasDegeri,
                    ToplamIscilik = g.ToplamIscilik,
                    IscDahil = g.IscDahil,
                    KarsiHareketID = g.KarsiHareketID
                })
                .ToList();

            responseDto.Hareketler = geciciDevreden;



            return new ResponseDto<GetAccountStatementQueryResponse>().Success(responseDto);
        }

    }
}
