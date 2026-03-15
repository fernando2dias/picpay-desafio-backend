namespace PicPaySimplificado.Application.UseCases.Transfer
{
    public class TransferCommand
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public decimal Amount { get; set; }
    }
}
