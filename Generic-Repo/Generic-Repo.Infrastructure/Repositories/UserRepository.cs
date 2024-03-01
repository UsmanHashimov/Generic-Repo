using Generic_Repo.Application.Abstractions.IRepositories;
using Generic_Repo.Domain.Entities.Models;
using Generic_Repo.Infrastructure.Persistence;

namespace Generic_Repo.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDBContext context)
            : base(context)
        {

        }
    }
}
