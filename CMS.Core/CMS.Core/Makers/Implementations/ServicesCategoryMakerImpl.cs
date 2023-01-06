using CMS.Core.Dto;
using CMS.Core.Entity;
using CMS.Core.Makers.Interface;
using CMS.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Core.Makers.Implementations
{
    public class ServicesCategoryMakerImpl : ServicesCategoryMaker
    {
        private readonly SlugGenerator _slugGenerator;
        
         public ServicesCategoryMakerImpl(SlugGenerator slugGenerator)
        {
            _slugGenerator = slugGenerator;
        }

        public void copy(ServicesCategory service_category, ServicesCategoryDto service_category_dto)
        {
            service_category.service_category_id = service_category_dto.service_category_id;
            service_category.title = service_category_dto.title.Trim();
            service_category.is_enabled = service_category_dto.is_enabled;
            service_category.slug = _slugGenerator.generate(service_category_dto.title);
        }
    }
    
}
