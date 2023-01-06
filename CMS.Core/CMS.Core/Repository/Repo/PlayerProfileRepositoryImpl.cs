using CMS.Core.Data;
using CMS.Core.Entity;
using CMS.Core.Helper;
using CMS.Core.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.Core.Repository.Repo
{
    public class PlayerProfileRepositoryImpl : BaseRepositoryImpl<PlayerProfile>, PlayerProfileRepository
    {
        private readonly AppDbContext _appDbContext;
        public PlayerProfileRepositoryImpl ( AppDbContext context, DetailsEncoder<PlayerProfile> detailsEncoder, HtmlEncodingClassHelper htmlEncodingClassHelper) : base(context,detailsEncoder,htmlEncodingClassHelper)
        {
            _appDbContext = context;
        }
        public PlayerProfile getBySlug(string slug)
        {
            return _appDbContext.playerProfiles.Where(a => a.slug == slug).SingleOrDefault();
        }
        public List<PlayerProfile> getByName(string name)
        {
            return _appDbContext.playerProfiles.Where(a => a.name == name).ToList();
        }

     
    }
}
