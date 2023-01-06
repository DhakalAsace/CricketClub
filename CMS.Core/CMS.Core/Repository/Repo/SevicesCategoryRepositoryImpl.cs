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
    class SevicesCategoryRepositoryImpl : BaseRepositoryImpl<ServicesCategory>, ServicesCategoryRepository
    {
        private readonly AppDbContext _appDbContext;
        public SevicesCategoryRepositoryImpl(AppDbContext context, DetailsEncoder<ServicesCategory>detailsEncoder, HtmlEncodingClassHelper htmlEncodingClassHelper) : base(context, detailsEncoder, htmlEncodingClassHelper)
        {
            _appDbContext = context;
        }

        public ServicesCategory getByName(string name)
        {
            return _appDbContext.service_categories.Where(a => a.title ==name ).SingleOrDefault();
        }
    }
}
