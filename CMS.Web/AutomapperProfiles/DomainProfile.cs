using AutoMapper;
using CMS.Core.Entity;
using CMS.Web.Areas.Core.ViewModels;
using CMS.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.AutomapperProfiles
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<GalleryImage, GalleryImageDetail>();
            CreateMap<GalleryImageDetail, GalleryImage>();

            CreateMap<PlayerProfile, ViewModels.PlayersDetail>();
            CreateMap<ViewModels.PlayersDetail, PlayerProfile>();

            CreateMap<PlayersIndexViewModel, PlayerProfile>();
            CreateMap<PlayerProfile, PlayersIndexViewModel>();

        }
    }
}
