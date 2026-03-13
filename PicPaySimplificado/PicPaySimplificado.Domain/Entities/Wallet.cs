namespace PicPaySimplificado.Domain.Entities
{
    public class Wallet
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public decimal Balance { get; private set; }

        protected Wallet() { }
        public Wallet(Guid userId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            Balance = 0;
        }

        public void Debit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("O valor deve ser maior que zero.");
            if (Balance < amount)
                throw new InvalidOperationException("Saldo insuficiente.");
            Balance -= amount;
        }

        public void Credit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("O valor deve ser maior que zero.");
            Balance += amount;
        }
    }
}
