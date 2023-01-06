using CMS.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Core.Service.Interface
{
    public interface ServicesCategoryService
    {
        void Save(ServicesCategoryDto servicesCategoryDto);
        void delete(long service_category_id);
        void update(ServicesCategoryDto servicesCategoryDto);
        void enable(long service_category_id);
        void disable(long service_category_id);
    }
}
