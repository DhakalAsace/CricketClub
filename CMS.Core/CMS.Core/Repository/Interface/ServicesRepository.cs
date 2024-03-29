﻿using CMS.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.Core.Repository.Interface
{
    public interface ServicesRepository
    {
        void insert(Services services);
        void update(Services services);
        void delete(Services services);
        List<Services> getAll();
        Services getById(long service_id);
        Services getBySlug(string slug);
        List<Services> getByName(string title);
        IQueryable<Services> getQueryable();


    }
}
