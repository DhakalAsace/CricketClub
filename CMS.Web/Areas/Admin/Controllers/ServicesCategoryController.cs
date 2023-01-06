using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CMS.Core.Dto;
using CMS.Core.Entity;
using CMS.Core.Repository.Interface;
using CMS.Core.Service.Interface;
using CMS.Web.Areas.Admin.FilterModel;
using CMS.Web.Areas.Admin.ViewModels;
using CMS.Web.Areas.Core.Models;
using CMS.Web.Controllers;
using CMS.Web.Helpers;
using CMS.Web.LEPagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Web.Areas.Admin.Controllers
{ 
    [Authorize]
    [Area("admin")]
    [Route("admin/services-category")]
    public class ServicesCategoryController :Controller
    {
        private readonly ServicesCategoryService _servicesCategoryService;
        private readonly ServicesCategoryRepository _servicesCategoryRepo;
        private readonly PaginatedMetaService _paginatedMetaService;
        private readonly IMapper _mapper;
        public ServicesCategoryController(IMapper mapper, ServicesCategoryService servicesCategoryService,ServicesCategoryRepository servicesCategoryRepo, PaginatedMetaService paginatedMetaService )
        {
            _servicesCategoryService = servicesCategoryService;
            _servicesCategoryRepo = servicesCategoryRepo;
            _paginatedMetaService = paginatedMetaService;
            _mapper = mapper;
        }
        [Route("")]
        [Route ("index")]
        public IActionResult Index(ServicesCategoryFilter filter = null)
        {
            try
            {
                var servicesCategories = _servicesCategoryRepo.getQueryable();
                if(!string.IsNullOrWhiteSpace(filter.title))
                {
                    servicesCategories = servicesCategories.Where(a => a.title.Contains(filter.title));
                }
                ViewBag.pagerInfo = _paginatedMetaService.GetMetaData(servicesCategories.Count(), filter.page, filter.number_of_rows);
                servicesCategories = servicesCategories.Skip(filter.number_of_rows * (filter.page - 1)).Take(filter.number_of_rows);
                var servicesCat = servicesCategories.ToList();
                var servicesCategoriesIndexVM = getViewModelFrom(servicesCat);
                return View(servicesCategoriesIndexVM);
            }
            catch (Exception ex)
            {
                AlertHelper.setMessage(this, ex.Message, messageType.error);
                return Redirect("/admin");
            }

        }
        [HttpGet]
        [Route("new")]
        public IActionResult  add()
        {
            try
            {
                ServicesCategoryModel servicesCategoryModel = new ServicesCategoryModel();
                return View(servicesCategoryModel);
            }
            catch (Exception ex)
            {
                AlertHelper.setMessage(this, ex.Message, messageType.error);
                return RedirectToAction("index");
            }
        }
        [HttpPost]
        [Route("new")]
        public IActionResult add (ServicesCategoryModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ServicesCategoryDto servicesCategoryDto = new ServicesCategoryDto()
                    {
                        title = model.title,
                        is_enabled = model.is_enabled,
                    };
                    _servicesCategoryService.Save(servicesCategoryDto);
                    AlertHelper.setMessage(this, "Service Category saved sucessfully.", messageType.success);
                    return RedirectToAction("index");
                }
            }
            catch (Exception ex)
            {

                AlertHelper.setMessage(this, ex.Message, messageType.error);
            }
            return View(model);
        }

        [HttpGet]
        [Route("edit/{service_category_id}")]
        public IActionResult edit (long service_category_id)
        {

            try
            {
                ServicesCategory servicesCategory = _servicesCategoryRepo.getById(service_category_id);
                ServicesCategoryModel servicesCategoryModel = _mapper.Map<ServicesCategoryModel>(servicesCategory);
                return View(servicesCategoryModel);
            }
            catch (Exception ex)
            {

                AlertHelper.setMessage(this, ex.Message, messageType.error);
                return RedirectToAction("index");
            }
        }
        [HttpPost]
        [Route("edit")]
        public IActionResult edit (ServicesCategoryModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    ServicesCategoryDto servicesCategoryDto = new ServicesCategoryDto()
                    {
                        service_category_id = model.service_category_id,
                        title = model.title,
                    };
                    _servicesCategoryService.update(servicesCategoryDto);
                    return RedirectToAction("index");
                }
            }
            catch (Exception ex)
            {

                AlertHelper.setMessage(this, ex.Message, messageType.error);
            }
            return View(model);
        }
        [HttpGet]
        [Route("enable/{service_category_id}")]
        public IActionResult enable (long service_category_id)
        {
            try
            {
                _servicesCategoryService.enable(service_category_id);
                AlertHelper.setMessage(this, "Service Category enabled successfully.", messageType.success);
            }
            catch (Exception ex)
            {

                AlertHelper.setMessage(this, ex.Message, messageType.error);

            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [Route("disable/{service_category_id}")]
        public IActionResult disable(long service_category_id)
        {
            try
            {
                _servicesCategoryService.disable(service_category_id);
                AlertHelper.setMessage(this, "Service Category disabled sucessfully.", messageType.success);
            }
            catch (Exception ex)
            {

                AlertHelper.setMessage(this, ex.Message, messageType.error);

            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [Route("delete/{service_category_id}")]
        public IActionResult delete(long service_catgory_id)
        {
            try
            {
                _servicesCategoryService.delete(service_catgory_id);
                AlertHelper.setMessage(this, "Page Category deleted successfully.", messageType.success);

            }
            catch (Exception ex)
            {

                AlertHelper.setMessage(this, ex.Message, messageType.error);
            }
            return RedirectToAction(nameof(Index));
        }



        private ServicesCategoryIndexViewModel getViewModelFrom(List<ServicesCategory> servicesCategories)
        {
            ServicesCategoryIndexViewModel vm = new ServicesCategoryIndexViewModel();
            vm.service_category_details = new List<ServicesCategoryDetailModel>();
            foreach (var servicesCategory in servicesCategories)
            {
                var servicesCategoryDetail = _mapper.Map<ServicesCategoryDetailModel>(servicesCategory);
                vm.service_category_details.Add(servicesCategoryDetail);
            }
            return vm;
        }
    }


}
