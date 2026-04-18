namespace KuyumHesap.Application.Common.Models.Dtos
{
    public class GenerateTokenRequest(int id, string userName, int roleId, string companyCode, string branchCode)
    {
        public int Id { get; set; } = id;
        public string UserName { get; set; } = userName;
        public int RoleId { get; set; } = roleId;
        public string CompanyCode { get; set; } = companyCode;
        public string BranchCode { get; set; } = branchCode;
    }
}
