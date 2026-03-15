using PicPaySimplificado.Domain.Entities;

namespace PicPaySimplificado.Domain.Repositories
{
    public interface ITransactionRepository
    {
        Task Save(Transaction transaction);
    }
}
