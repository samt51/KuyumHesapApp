namespace KuyumHesap.Application.Features.ReceiptFeature.Commands.Create
{
    public class CreateReceiptCommandResponse 
    {
        public int Id { get; set; }
        public string ReceiptNumber { get; set; } = string.Empty;
    }
}
