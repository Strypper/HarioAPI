using Hairo.Entities.Databases;
using Hairo.Entities.Location;
using Hario.Contract;

namespace Hario.Repo
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(HairoDbContext hc) : base(hc) { }
    }
}
