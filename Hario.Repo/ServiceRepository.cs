using Hairo.Entities;
using Hairo.Entities.Databases;
using Hario.Contract;

namespace Hario.Repo
{
    public class ServiceRepository : BaseRepository<Service>, IServiceRepository
    {
        public ServiceRepository(HairoDbContext hc) : base(hc) { }
    }
}
