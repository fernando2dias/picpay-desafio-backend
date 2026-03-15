using PicPaySimplificado.Domain.Entities;

namespace PicPaySimplificado.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid senderId);
    }
}
