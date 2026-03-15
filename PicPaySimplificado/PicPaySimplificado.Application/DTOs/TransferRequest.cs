namespace PicPaySimplificado.Application.DTOs
{
    public class TransferRequest
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public decimal Amount { get; set; }
    }
}
