using Hairo.Entities.Databases;
using Hairo.Entities.Location;
using Hario.Contract;

namespace Hario.Repo
{
    public class DistrictRepository : BaseRepository<District>, IDistrictRepository
    {
        public DistrictRepository(HairoDbContext hc) : base(hc) { }
    }
}
