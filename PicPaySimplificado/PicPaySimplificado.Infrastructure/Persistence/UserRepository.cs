using PicPaySimplificado.Domain.Entities;
using PicPaySimplificado.Domain.Enums;
using PicPaySimplificado.Domain.Repositories;

namespace PicPaySimplificado.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        public Task<User> GetByIdAsync(Guid userId)
        {
            if (userId.ToString() == "a01b96d6-43df-4896-b014-6c16eda10ae9")
            {
                return Task.FromResult(User.Create("John Doe", "12345678900", "fernando@motta.com", UserType.Common));
            }
            else
            {
                return Task.FromResult(User.Create("Loja", "12345678900", "loja@motta.com", UserType.Store));
            }

        }

        
    }
}
