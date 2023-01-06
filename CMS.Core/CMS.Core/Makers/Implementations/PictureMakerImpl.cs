using CMS.Core.Dto;
using CMS.Core.Entity;
using CMS.Core.Makers.Interface;
using CMS.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Core.Makers.Implementations
{
    public class PictureMakerImpl : PictureMaker
    {
        private SlugGenerator _slugGenerator;

        public PictureMakerImpl(SlugGenerator slugGenerator)
        {
            _slugGenerator = slugGenerator;
        }

        public void copy(Picture picture, PictureDto pictureDto)
        {
          
            picture.is_enabled = pictureDto.is_enabled;
            picture.is_slider_image = pictureDto.is_slider_image;
            picture.is_male = pictureDto.is_male;
            picture.is_female = pictureDto.is_female;
            picture.slug = pictureDto.slug;
            picture.picture_id = pictureDto.picture_id;
            picture.title = pictureDto.title;
            if (!string.IsNullOrWhiteSpace(pictureDto.image_name))
            {
                picture.image_name = pictureDto.image_name;
            }
            if (!string.IsNullOrWhiteSpace(pictureDto.image1))
            {
                picture.image1 = pictureDto.image1;
            }
            if (!string.IsNullOrWhiteSpace(pictureDto.image2))
            {
                picture.image2 = pictureDto.image2;
            }
            if (!string.IsNullOrWhiteSpace(pictureDto.image3))
            {
                picture.image3 = pictureDto.image3;
            }
            if (!string.IsNullOrWhiteSpace(pictureDto.image4))
            {
                picture.image4 = pictureDto.image4;
            }
            if (!string.IsNullOrWhiteSpace(pictureDto.image5))
            {
                picture.image5 = pictureDto.image5;
            }
         
        }
    }
}
