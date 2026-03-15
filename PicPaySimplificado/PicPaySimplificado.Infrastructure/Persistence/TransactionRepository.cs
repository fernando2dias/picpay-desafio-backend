using PicPaySimplificado.Domain.Entities;
using PicPaySimplificado.Domain.Repositories;

namespace PicPaySimplificado.Infrastructure.Persistence
{
    public class TransactionRepository : ITransactionRepository
    {
        public Task Save(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
