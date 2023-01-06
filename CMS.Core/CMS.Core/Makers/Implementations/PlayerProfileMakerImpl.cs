using CMS.Core.Dto;
using CMS.Core.Entity;
using CMS.Core.Makers.Interface;
using CMS.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Core.Makers.Implementations
{
    public class PlayerProfileMakerImpl : PlayerProfileMaker
    {
        public readonly SlugGenerator _slugGenerator;
        public PlayerProfileMakerImpl(SlugGenerator slugGenerator)
        {
            _slugGenerator = slugGenerator;
        }

        public void copy(PlayerProfile playerProfile, PlayerProfileDto playerProfileDto)
        {
            playerProfile.birth_place = playerProfileDto.birth_place;
            playerProfile.carrier_info = playerProfileDto.carrier_info;
            playerProfile.contact = playerProfileDto.contact;
            playerProfile.description = playerProfileDto.description;
            playerProfile.is_enabled = playerProfileDto.is_enabled;
            playerProfile.name = playerProfileDto.name;
            playerProfile.player_profile_id = playerProfileDto.player_profile_id;
            playerProfile.role = playerProfileDto.role;
            playerProfile.playerProfile = playerProfileDto.playerProfile;
            playerProfile.status = playerProfileDto.status;
            playerProfile.image = playerProfileDto.image;
            playerProfile.height = playerProfileDto.height;
            playerProfile.fb_url = playerProfileDto.fb_url;
            playerProfile.web_url = playerProfileDto.web_url;
            playerProfile.youtube_url = playerProfileDto.youtube_url;
            playerProfile.slug = playerProfileDto.slug;

            playerProfile.slug = _slugGenerator.generate(playerProfileDto.name);

        }
    }
}
