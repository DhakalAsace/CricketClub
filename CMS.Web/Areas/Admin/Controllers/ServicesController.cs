using AutoMapper;
using CMS.Core.Dto;
using CMS.Core.Entity;
using CMS.Core.Repository.Interface;
using CMS.Core.Service.Interface;
using CMS.Web.Areas.Core.FilterModel;
using CMS.Web.Areas.Core.Models;
using CMS.Web.Areas.Core.ViewModels;
using CMS.Web.Helpers;
using CMS.Web.LEPagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("admin")]
    [Route("admin/services")]
    public class ServicesController : Controller
    {
        private readonly ServicesService _servicesService;
        private readonly ServicesRepository _servicesRepo;
        private readonly ServicesCategoryRepository _servicesCategoryRepo;
        private readonly PaginatedMetaService _paginatedMetaService;
        private IMapper _mapper;
        private FileHelper _fileHelper;
        public ServicesController(ServicesCategoryRepository servicesCategoryRepo, FileHelper fileHelper, IMapper mapper, ServicesService servicesService, ServicesRepository servicesRepo, PaginatedMetaService paginatedMetaService)
        {
            _servicesService = servicesService;
            _servicesRepo = servicesRepo;
            _paginatedMetaService = paginatedMetaService;
            _mapper = mapper;
            _fileHelper = fileHelper;
            _servicesCategoryRepo = servicesCategoryRepo;
        }
        [Route("")]
        [Route("index")]
        public IActionResult Index(ServicesFilter filter = null)
        {
            try
            {
                var services = _servicesRepo.getQueryable();
                if(!string.IsNullOrEmpty(filter.title))
                {
                    services = services.Where(a => a.title.Contains(filter.title));
                }
                ViewBag.pagerInfo = _paginatedMetaService.GetMetaData(services.Count(), filter.page, filter.number_of_rows);
                services = services.Skip(filter.number_of_rows * (filter.page - 1)).Take(filter.number_of_rows);
                var service = services.ToList();
                var serviceIndexVM = getViewModelFrom(service);
                return View(serviceIndexVM);

            }
            catch (Exception ex)
            {

                AlertHelper.setMessage(this, ex.Message, messageType.error);
                return Redirect("/admin");
            }
        }
        [HttpPost]
        [Route("new")]
        public IActionResult add()
        {
            try
            {
                ServicesModel servicesModel = new ServicesModel();
                var servicesCategories = _servicesCategoryRepo.getQueryable().ToList();
                ViewBag.categories = new SelectList(servicesCategories, "service_category_id", "title");
                return View(servicesModel);
            }
            catch (Exception ex)
            {
                AlertHelper.setMessage(this, ex.Message, messageType.error);
                return RedirectToAction("index");

            }
        }
        [HttpGet]
        [Route("new")]
        public IActionResult add (ServicesModel model, IFormFile file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ServicesDto servicesDto = new ServicesDto();
                    servicesDto.title = model.title;
                    if (file != null)
                    {
                        servicesDto.image_name = _fileHelper.saveFileAndGetFileName(file, model.title);
                    }
                    servicesDto.description = model.description;
                    servicesDto.service_category_id = model.service_category_id;
                    servicesDto.is_enabled = model.is_enabled;
                    _servicesService.Save(servicesDto);
                    AlertHelper.setMessage(this, "Service saved successfully.", messageType.success);
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {

                AlertHelper.setMessage(this, ex.Message, messageType.error);

            }
            var servicesCategories = _servicesCategoryRepo.getQueryable().ToList();
            ViewBag.categories = new SelectList(servicesCategories, "service_category_id", "title");
            return View(model);
        }
        [HttpGet]
        [Route("edit/service_id")]
        public IActionResult edit (long service_id)
        {
            try
            {
                var servicesCategories = _servicesCategoryRepo.getQueryable().ToList();
                ViewBag.categories = new SelectList(servicesCategories, "service_category_id", "name");
                Services services = _servicesRepo.getById(service_id);
                ServicesModel servicesModel = _mapper.Map<ServicesModel>(services);
                return View(servicesModel);
            }
            catch (Exception ex)
            {

                AlertHelper.setMessage(this, ex.Message, messageType.error);
                return RedirectToAction("index");

            }
        }
        [HttpPost]
        [Route("edit")]
        public IActionResult edit (ServicesModel model, IFormFile file)
        {
            try
            {
if (ModelState.IsValid)
                {
                    ServicesDto servicesDto = new ServicesDto();
                    servicesDto.service_id = model.service_id;
                    servicesDto.title = model.title;
                    if(file !=null)
                    {
                        servicesDto.image_name = _fileHelper.saveFileAndGetFileName(file, model.title);
                    }
                    servicesDto.description = model.description;
                    servicesDto.service_category_id = model.service_category_id;
                    servicesDto.is_enabled = model.is_enabled;
                    _servicesService.update(servicesDto);
                    return RedirectToAction("index");
                }
            }
            catch (Exception ex)
            {

                AlertHelper.setMessage(this, ex.Message, messageType.error);

            }
            var servicesCategories = _servicesCategoryRepo.getQueryable().ToList();
            ViewBag.categories = new SelectList(servicesCategories, " service_category_id", "title");
            return View(model);
        }
        [HttpGet]
        [Route("enable/{service_id}")]
        public IActionResult enable (long service_id)
        {
            try
            {
                _servicesService.enable(service_id);
                AlertHelper.setMessage(this, "Service enabled successfully", messageType.success); 

            }
            catch (Exception ex)
            {

                AlertHelper.setMessage(this, ex.Message, messageType.error);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [Route("disable/service_id")]
        public IActionResult disable (long service_id)
        {
            try
            {
                _servicesService.disable(service_id);
                AlertHelper.setMessage(this, "Page disabled successfully.", messageType.success);
            }
            catch (Exception ex)
            {

                AlertHelper.setMessage(this, ex.Message, messageType.error);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [Route("delete/service_id")]
        public IActionResult delete(long service_id)
        {
            try
            {
                _servicesService.delete(service_id);
                AlertHelper.setMessage(this, "Service deleted successfully.", messageType.success);
            }
            catch (Exception ex)
            {

                AlertHelper.setMessage(this, ex.Message, messageType.error);

            }
            return RedirectToAction(nameof(Index));
        }
        private object getViewModelFrom(List<Services> services)
        {
            ServicesIndexViewModel vm = new ServicesIndexViewModel();
            vm.service_details = new List<ServicesDetailModel>();
            foreach (var service in services)
            {
                var servicesDetail = _mapper.Map<ServicesDetailModel>(service);
                servicesDetail.service_category_name = service.service_category.title;
                vm.service_details.Add(servicesDetail);
            }

            return vm;
        }
    }
}
