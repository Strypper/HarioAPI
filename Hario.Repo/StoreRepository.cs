using Hairo.Entities;
using Hairo.Entities.Databases;
using Hario.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hario.Repo
{
    public class StoreRepository : BaseRepository<Store>, IStoreRepository
    {
        public StoreRepository(HairoDbContext hc) : base(hc){}
    }
}
