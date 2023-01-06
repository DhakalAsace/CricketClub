using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Core.Repository.Interface;
using CMS.Web.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("admin")]
    [Route("admin")]
    public class HomeController : Controller
    {
        private readonly NoticeRepository _noticeRepo;
      
        private readonly PageRepository _pageRepo;
        private readonly SetupRepository _setupRepo;

        public HomeController(NoticeRepository noticeRepo, PageRepository pageRepo, SetupRepository setupRepo)
        {
            _noticeRepo = noticeRepo;
            _pageRepo = pageRepo;
            _setupRepo = setupRepo;
        }

        [Route("")]
        public IActionResult Index()
        {
            HomeIndexViewModel homeIndexVM = new HomeIndexViewModel();
            homeIndexVM.active_notices_count = _noticeRepo.getQueryable().Where(a => a.notice_expiry_date >= DateTime.Now).Count();

            homeIndexVM.pages_count = _pageRepo.getQueryable().Count();

            var setup = _setupRepo.getQueryable().Where(a => a.key == Models.SetupKeys.getOrganisationNameKey).SingleOrDefault();
            var address = _setupRepo.getQueryable().Where(a => a.key == Models.SetupKeys.getAddressKey).SingleOrDefault();

            homeIndexVM.company_name = setup?.value;
            homeIndexVM.address = address?.value;
            return View(homeIndexVM);
        }
    }
}