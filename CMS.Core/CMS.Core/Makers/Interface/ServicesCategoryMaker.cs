using CMS.Core.Dto;
using CMS.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Core.Makers.Interface
{
   public interface ServicesCategoryMaker
    {
        void copy(ServicesCategory service_category, ServicesCategoryDto service_category_dto);
    }
}
