using CMS.Core.Dto;
using CMS.Core.Entity;
using CMS.Core.Makers.Interface;
using CMS.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Core.Makers.Implementations
{
    public class ServicesMakerImpl : ServicesMaker
    {
        private readonly SlugGenerator _slugGenerator;
        public ServicesMakerImpl(SlugGenerator slugGenerator)
        {
            _slugGenerator = slugGenerator;
        }

        public void copy(ref Services service, ServicesDto service_dto)
        {
            service.service_id = service_dto.service_id;
            service.service_category_id = service_dto.service_category_id;
            service.title = service_dto.title.Trim();
            service.description = service_dto.description.Trim();
            if (!string.IsNullOrWhiteSpace(service_dto.image_name))
            {
                service.image_name = service_dto.image_name;
            }
            service.is_enabled = service_dto.is_enabled;
            service.slug = _slugGenerator.generate(service_dto.title);






        }
    }
}
