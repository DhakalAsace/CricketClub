using CMS.Core.Dto;
using CMS.Core.Entity;
using CMS.Core.Exceptions;
using CMS.Core.Makers.Interface;
using CMS.Core.Repository.Interface;
using CMS.Core.Service.Interface;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;

namespace CMS.Core.Service.Implementation
{
   public  class ServicesServiceImpl:ServicesService
    {
        private readonly ServicesRepository _servicesRepo;
        private readonly ServicesMaker _servicesMaker;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ServicesServiceImpl(ServicesRepository servicesRepository, ServicesMaker servicesMaker, IHostingEnvironment hostingEnvironment)
        {
            _servicesRepo = servicesRepository;
            _servicesMaker = servicesMaker;
            _hostingEnvironment = hostingEnvironment;
        }
        public void Save(ServicesDto servicesDto)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    bool isNameValid = checkNameValidity(servicesDto);
                    if (!isNameValid)
                    {
                        throw new DuplicateItemException("Service with same title already exist.");
                    }
                    Services services = new Services();
                    _servicesMaker.copy(ref services, servicesDto);
                    _servicesRepo.insert(services);
                    tx.Complete();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void delete(long service_id)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    var services = _servicesRepo.getById(service_id);
                    if (services == null)
                    {
                        throw new ItemNotFoundException($"Service Category with id {service_id} doesn't exist.");
                    }
                    string oldImage = services.image_name;
                    _servicesRepo.delete(services);
                    tx.Complete();
                    if (!string.IsNullOrWhiteSpace(oldImage))
                    {
                        deleteImage(oldImage);
                    }
                   

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void deleteImage(string oldImageTwo)
        {
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images/custom");
            if (File.Exists(Path.Combine(filePath, oldImageTwo)))
            {
                File.Delete(Path.Combine(filePath, oldImageTwo));

            }
        }

        public void update(ServicesDto servicesDto)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    var services = _servicesRepo.getById(servicesDto.service_id);
                    if (services == null)
                    {
                        throw new ItemNotFoundException($"Service with id {servicesDto.service_id} doesnot exist.");
                    }
                    bool isNameValid = checkNameValidity(servicesDto);
                    if (!isNameValid)
                    {
                        throw new DuplicateItemException("Service with same name already exist.");
                    }
                    string oldImage = services.image_name;

                    _servicesMaker.copy(ref services, servicesDto);
                    _servicesRepo.update(services);
                    tx.Complete();

                    if (!string.IsNullOrWhiteSpace(servicesDto.image_name))
                    {
                        if (!string.IsNullOrWhiteSpace(oldImage))
                        {
                            deleteImage(oldImage);
                        }
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private bool checkNameValidity(ServicesDto servicesDto)
        {
            List<Services> servicesWithSameName = _servicesRepo.getByName(servicesDto.title.ToLower());
            var servicesWithSameNameInSameCategory = servicesWithSameName.Where(a => a.service_category_id == servicesDto.service_category_id).SingleOrDefault();

            if (servicesWithSameNameInSameCategory == null || servicesWithSameNameInSameCategory.service_id == servicesDto.service_id)
            {
                return true;
            }
            return false;
        }


        public void enable(long service_id)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    var services = _servicesRepo.getById(service_id);
                    if (services == null)
                        throw new ItemNotFoundException($"Service with id {service_id} doesnot exist");
                    services.enable();
                    _servicesRepo.update(services);
                    tx.Complete();

                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void disable(long service_id)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    var services = _servicesRepo.getById(service_id);
                    if(services == null)
                        throw new ItemNotFoundException($"Services with id {service_id} doesnot exist.");
                    services.disable();
                    _servicesRepo.update(services);
                    tx.Complete();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    
}

