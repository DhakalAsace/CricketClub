using CMS.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Core.Service.Interface
{
    public interface PlayerProfileService
    {
        void delete(long player_profile_id);
        void save(PlayerProfileDto playerProfileDto);
        void update(PlayerProfileDto playerProfileDto);
        void enable(long player_profile_id);
        void disable(long player_profile_id);

    }
}
