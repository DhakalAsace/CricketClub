using CMS.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.Core.Repository.Interface
{
    public interface PlayerProfileRepository
    {
        void insert(PlayerProfile playerProfile);
        void update(PlayerProfile playerProfile);
        void delete(PlayerProfile playerProfile);
        List<PlayerProfile> getAll();
        List<PlayerProfile> getByName(string name);
        PlayerProfile getById(long player_profile_id);
        IQueryable<PlayerProfile> getQueryable();
        PlayerProfile getBySlug(string slug);
    }
}
