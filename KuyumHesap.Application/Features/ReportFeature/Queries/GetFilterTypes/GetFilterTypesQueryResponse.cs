using KuyumHesap.Application.Features.ReportFeature.Dtos.Enums;

namespace KuyumHesap.Application.Features.ReportFeature.Queries.GetFilterTypes
{
    public class GetFilterTypesQueryResponse
    {
        public FilterEnum FilterEnum { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
    }
}
