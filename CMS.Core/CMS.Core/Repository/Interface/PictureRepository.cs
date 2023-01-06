using CMS.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.Core.Repository.Interface
{
    public interface PictureRepository
    {
        void insert(Picture picture);
        void update(Picture picture);
        void delete(Picture picture);
        List<Picture> getAll();
        List<Picture> getByName(string title);
        Picture getById(long picture_id);
        IQueryable<Picture> getQueryable();
        Picture getBySlug(string slug);

    }
}
