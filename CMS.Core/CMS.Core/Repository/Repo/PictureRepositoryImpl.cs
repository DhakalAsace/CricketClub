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
    public class PictureRepositoryImpl : BaseRepositoryImpl<Picture>, PictureRepository
    {
   
            private readonly AppDbContext _appDbContext;

            public PictureRepositoryImpl(AppDbContext context, DetailsEncoder<Picture> detailsEncoder, HtmlEncodingClassHelper htmlEncodingClassHelper) : base(context, detailsEncoder, htmlEncodingClassHelper)
            {
                _appDbContext = context;
            }

            public Picture getBySlug(string slug)
             {
            return _appDbContext.pictures.Where(a => a.slug == slug).SingleOrDefault();
             }
        public List<Picture> getByName(string title)
        {
            return _appDbContext.pictures.Where(a => a.title == title).ToList();
        }

       

    }
}
