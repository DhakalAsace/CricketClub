using CMS.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Core.Repository.Interface
{
    public interface ServicesCategoryRepository
    {
        void insert(ServicesCategory servicesCategory);
        void update(ServicesCategory services);
        void delete(ServicesCategory services);
        List<ServicesCategory> getAll();
        ServicesCategory getById(long service_category_id);
        ServicesCategory getByName(string name);
        System.Linq.IQueryable<ServicesCategory> getQueryable();
    }
}
