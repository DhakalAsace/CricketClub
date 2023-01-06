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
    public class ServicesRepositoryImpl : BaseRepositoryImpl<Services>, ServicesRepository
    {
        private readonly AppDbContext _appDbContext;
        public ServicesRepositoryImpl(AppDbContext context, DetailsEncoder<Services> detailsEncoder, HtmlEncodingClassHelper htmlEncodingClassHelper) : base(context, detailsEncoder, htmlEncodingClassHelper)
        {
            _appDbContext = context;
        }

        public List<Services> getByName(string title)
        {
            return _appDbContext.services.Where(a => a.title == title).ToList();
        }

        public Services getBySlug(string slug)
        {
            return _appDbContext.services.Where(a => a.slug == slug).SingleOrDefault();
        }

      
    }
}
