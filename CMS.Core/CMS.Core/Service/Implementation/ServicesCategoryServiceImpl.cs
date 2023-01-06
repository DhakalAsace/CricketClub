using CMS.Core.Dto;
using CMS.Core.Entity;
using CMS.Core.Exceptions;
using CMS.Core.Makers.Interface;
using CMS.Core.Repository.Interface;
using CMS.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace CMS.Core.Service.Implementation
{
    public class ServicesCategoryServiceImpl : ServicesCategoryService
    {
        private readonly ServicesCategoryRepository _servicesCategoryRepo;
   
        private readonly ServicesCategoryMaker _servicesCategoryMaker;
        public ServicesCategoryServiceImpl(ServicesCategoryRepository servicesCategoryRepo, ServicesCategoryMaker servicesCategoryMaker )
        {
            _servicesCategoryRepo = servicesCategoryRepo;
            _servicesCategoryMaker = servicesCategoryMaker;
        }

       

        public void delete(long service_category_id)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    var servicesCategory = _servicesCategoryRepo.getById(service_category_id);
                    if (servicesCategory == null)
                    {
                        throw new ItemNotFoundException($"Service Category with id{service_category_id}doesn't exist.");
                    }

                    if (servicesCategory.hasServices())
                    {
                        throw new ItemUsedException("Service Category has been already assigned to some services. ");

                    }
                    _servicesCategoryRepo.delete(servicesCategory);
                    tx.Complete();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    
        public void Save(ServicesCategoryDto servicesCategoryDto)
        {
            try
            {
        using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
            {
            var servicesCategoryWithSameTitle = _servicesCategoryRepo.getByName(servicesCategoryDto.title);
            if (servicesCategoryWithSameTitle != null)
            {
                throw new DuplicateItemException("Service category with same name already exist.");
            }
            ServicesCategory services_category = new ServicesCategory();
            _servicesCategoryMaker.copy(services_category, servicesCategoryDto);
            _servicesCategoryRepo.insert(services_category);
        }


            }
            catch (Exception)
            {

                throw;
            }
        }

        public void update(ServicesCategoryDto servicesCategoryDto)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    var servicesCategoryId = _servicesCategoryRepo.getById(servicesCategoryDto.service_category_id);
                    if(servicesCategoryId==null)
                    {
                        throw new ItemNotFoundException($"Service Category with id {servicesCategoryDto.service_category_id} doesnot exist.");
                    }
                    var servicesCategoryWithSameTitle = _servicesCategoryRepo.getByName(servicesCategoryDto.title);
                    bool isNameAllowed = servicesCategoryWithSameTitle == null || servicesCategoryWithSameTitle.service_category_id == servicesCategoryDto.service_category_id;
                    if (!isNameAllowed)
                    {
                        throw new DuplicateItemException("Service category with same name already exist.");
                    }
                    _servicesCategoryMaker.copy( servicesCategoryId, servicesCategoryDto);
                    _servicesCategoryRepo.update(servicesCategoryId);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void enable(long service_category_id)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    var servicesCategory = _servicesCategoryRepo.getById(service_category_id);
                    if (servicesCategory == null)
                    {
                        throw new ItemNotFoundException($"Service Category with id {service_category_id} doesnot exist.");
                    }
                    servicesCategory.enable();
                    _servicesCategoryRepo.update(servicesCategory);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void disable(long service_category_id)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    var servicesCategory = _servicesCategoryRepo.getById(service_category_id);
                    if (servicesCategory == null)
                    {
                        throw new ItemNotFoundException($"Service Category with id {service_category_id} doesnot exist.");
                    }
                    servicesCategory.disable();
                    _servicesCategoryRepo.update(servicesCategory);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}