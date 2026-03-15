namespace PicPaySimplificado.Domain.Entities
{
    public class Transaction
    {
        public Transaction(Guid senderId, Guid receiverId, decimal amount)
        {
            this.SenderId = senderId;
            this.ReceiverId = receiverId;
            this.Amount = amount;
        }

        public Guid Id { get; private set; }
        public Guid SenderId { get; private set; }
        public Guid ReceiverId { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime CreatedAt { get; private set; }
    }
}
