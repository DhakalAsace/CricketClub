using AutoMapper;
using CMS.Core.Enums;
using CMS.Core.Dto;
using CMS.Core.Repository.Interface;
using CMS.Core.Service.Interface;
using CMS.Web.Areas.Core.ViewModels;
using CMS.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CMS.Web.Models;
using CMS.Core.Entity;


namespace CMS.Web.ViewComponents
{
    [ViewComponent(Name = "HeaderView")]
    public class HeaderViewComponent : ViewComponent
    {
        public GalleryRepository _galleryRepo { get; set; }
        public NoticeRepository _noticeRepo { get; set; }
        
        public SetupRepository _setupRepo { get; set; }
        public PageCategoryRepository _pageCategoryRepo { get; set; }
        private IMapper _mapper;
        public EnquiryRepository _enquiryRepository { get; set; }
        public EnquiryService _enquiryService { get; set; }
        public PlayerProfileRepository _playerProfileRepository { get; set; }


        public HeaderViewComponent(PlayerProfileRepository playerProfileRepository,  EnquiryService enquiryService, EnquiryRepository enquiryRepository, IMapper mapper, GalleryRepository galleryRepo, NoticeRepository noticeRepo, SetupRepository setupRepo, PageCategoryRepository pageCategoryRepo)
        {
            _galleryRepo = galleryRepo;
            _noticeRepo = noticeRepo;
            _setupRepo = setupRepo;
            _pageCategoryRepo = pageCategoryRepo;
         
            _mapper = mapper;
            _enquiryRepository = enquiryRepository;
            _enquiryService = enquiryService;
            _playerProfileRepository = playerProfileRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           


            var setupValues = _setupRepo.getQueryable().ToList();
            ViewBag.setup = setupValues;

           

            var pageCategory = _pageCategoryRepo.getQueryable().Where(a => a.is_enabled == true).ToList();
            ViewBag.pageCategories = pageCategory;


            List<Core.Enums.PlayerProfile> playerProfileList = Enum.GetValues(typeof(Core.Enums.PlayerProfile)).Cast<Core.Enums.PlayerProfile>().ToList();
            ViewBag.playerProfile = playerProfileList;

           

           
            return View();
        }

       
     

    }
}
