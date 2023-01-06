﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CMS.Web.Models;
using CMS.Core.Repository.Interface;
using AutoMapper;
using CMS.Web.ViewModels;
using CMS.Core.Dto;
using CMS.Core.Service.Interface;
using CMS.Core.Exceptions;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Localization;
using CMS.Core.Entity;
using CMS.Web.Helpers;
using CMS.Web.FilterModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CMS.Web.Controllers
{

    public class HomeController : BaseController
    {
        private readonly BlogRepository _blogRepo;
        private readonly EventRepository _eventRepo;
        private readonly GalleryImageRepository _galleryRepo;
        private readonly NoticeRepository _noticeRepo;
        private readonly PageRepository _pageRepo;
        private readonly SetupRepository _setupRepo;
        private readonly TestimonialRepository _testimonialRepo;
        private readonly EmailSenderService _emailSenderService;
        private readonly IMapper _mapper;
        private readonly VideoRepository _videoRepository;
        private readonly ServicesRepository _servicesRepository;
        private readonly EnquiryRepository _enquiryRepository;
        private readonly EnquiryService _enquiryService;
        private readonly PlayerProfileRepository _playerProfileRepository;

        public HomeController(PlayerProfileRepository playerProfileRepository, EnquiryService enquiryService, EnquiryRepository enquiryRepository,ServicesRepository servicesRepository, GalleryImageRepository galleryRepo, NoticeRepository noticeRepo, PageRepository pageRepo, IMapper mapper, SetupRepository setupRepo, EmailSenderService emailSenderService, TestimonialRepository testimonialRepo, BlogRepository blogRepo, EventRepository eventRepo, VideoRepository videoRepository)
        {
            _playerProfileRepository = playerProfileRepository;
            _galleryRepo = galleryRepo;
            _noticeRepo = noticeRepo;
            _pageRepo = pageRepo;
            _mapper = mapper;
            _setupRepo = setupRepo;
            _testimonialRepo = testimonialRepo;
            _emailSenderService = emailSenderService;
            _blogRepo = blogRepo;
            _eventRepo = eventRepo;
            _videoRepository = videoRepository;
            _servicesRepository = servicesRepository;
            _enquiryRepository = enquiryRepository;
            _enquiryService = enquiryService;
        }
    
        public IActionResult Index(EnquiryModel model,HomeFilter filter)
        {



            //if (!string.IsNullOrWhiteSpace(filter.address))
            //{
            //    shop = _specialitiesRepository.getQueryable().Where(a => a.address == filter.address).ToList();
            //}


            var homeImage = _galleryRepo.getQueryable().Where(g => g.is_slider_image == true && g.is_enabled == true).ToList();
            ViewBag.sliderImages = homeImage;

            var gallerys = _galleryRepo.getQueryable().Where(ga => ga.is_enabled == true).Take(4).ToList();
            ViewBag.gallery = gallerys;
           


            var serviceValue = _servicesRepository.getQueryable().Where(a => a.is_enabled == true).ToList().Take(4);
            ViewBag.services = serviceValue;

           
            var players = _playerProfileRepository.getQueryable().Where(a => a.is_enabled == true).ToList().Take(3);
            ViewBag.players = players;

          
            var setupValues = _setupRepo.getQueryable().ToList();
            ViewBag.setup = setupValues;

            var blogValues = _blogRepo.getQueryable().Where(b => b.is_enabled == true).Take(4).ToList();
            ViewBag.blog = blogValues;

            var eventValues = _eventRepo.getQueryable().Where(e => e.is_closed == false && e.event_to_date >= TimeZoneInfo.ConvertTime(DateTime.Now,
                 TimeZoneInfo.FindSystemTimeZoneById("Nepal Standard Time")).Date).Take(4).ToList();
            ViewBag.events = eventValues;
            ViewBag.events12 = eventValues.Take(3);
            var testimonialValues = _testimonialRepo.getQueryable().Where(a => a.is_visible == true).ToList();
            ViewBag.testimonial = testimonialValues;

            var notice = _noticeRepo.getQueryable().Where(n => n.notice_expiry_date.Date >= TimeZoneInfo.ConvertTime(DateTime.Now,
                 TimeZoneInfo.FindSystemTimeZoneById("Nepal Standard Time")).Date && n.is_closed == false).ToList();
            ViewBag.notices = notice;
            ViewBag.notices12 = notice.Take(3);
            var page = _pageRepo.getQueryable().Where(n => n.is_enabled == true && n.is_home_page == true).SingleOrDefault();
            ViewBag.homePage = page;
            var videoValue = _videoRepository.getQueryable().Where(n => n.is_enabled == true && n.is_home_video == true).ToList();
            ViewBag.homeVideo = videoValue;

            var enquiries = _enquiryRepository.getQueryable().Where(a => a.enquiry_id == model.enquiry_id).ToList();

            List<Enquiry> Enquiries = new List<Enquiry>();
            foreach (var comment in enquiries)
            {
                Enquiry enquiry = new Enquiry();
                enquiry.name = comment.name;
                enquiry.description = comment.description;
                enquiry.enquiry_date = comment.enquiry_date;
                enquiry.contact_number = comment.contact_number;
                enquiry.email = comment.email;
                Enquiries.Add(enquiry);
            }
            model.enquiry = Enquiries;
            return View(model);
        }
       
        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        [Route("send-enquiry")]
        public IActionResult sendEnquiry(EnquiryDto dto)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _enquiryService.save(dto);
                    AlertHelper.setMessage(this, "Enquiry saved successfully.", messageType.success);

                    return RedirectToAction("/");
                }
                catch (ArgumentNullException ex)
                {
                    TempData["message"] = "Failed to send email";
                }
                catch (Exception ex)
                {
                    TempData["message"] = ex.Message;
                    return RedirectToAction("/");
                }
            }
            return (IActionResult)View(dto);


        }
    }
}
