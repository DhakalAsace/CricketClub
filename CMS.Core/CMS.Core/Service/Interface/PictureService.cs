using CMS.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Core.Service.Interface
{
    public interface PictureService
    {
        void delete(long picture_id);
        void save(PictureDto pictureDto);
        void update(PictureDto pictureDto);
        void enable(long picture_id);
        void disable(long picture_id);
        void makemale(long picture_id);
        void unmakemale(long picture_id);
        void makefemale(long picture_id);
        void unmakefemale(long picture_id);
        void makeSliderImage(long picture_id);
        void removeFromSliderImage(long picture_id);
    }
}
