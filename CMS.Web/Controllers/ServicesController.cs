using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CMS.Core.Repository.Interface;
using CMS.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Web.Controllers
{
    [Route ("services")]
    public class ServicesController : Controller
    {
        private readonly ServicesRepository _servicesRepo;
        private readonly SetupRepository _setupRepo;
        private IMapper _mapper;
        public ServicesController(ServicesRepository servicesRepo, IMapper mapper, SetupRepository setupRepo)
        {
            _servicesRepo = servicesRepo;
            _mapper = mapper;
            _setupRepo = setupRepo;
        }
        [HttpGet]
        [Route("{slug}")]
        public IActionResult Index( string slug)
        {
            var setupValues = _setupRepo.getQueryable().ToList();
            ViewBag.setup = setupValues;

            var services = _servicesRepo.getBySlug(slug);
            if (services == null)
            {
                return View(new ServicesDetail());
            }
            var servicesDetail = _mapper.Map<ServicesDetail>(services);
            return View(servicesDetail);
        }
    
    }
}