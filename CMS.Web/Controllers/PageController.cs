﻿using AutoMapper;
using CMS.Core.Repository.Interface;
using CMS.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CMS.Web.Controllers
{
    [Route("page")]
    public class PageController :Controller
    {
        private readonly PageRepository _pageRepo;
        private readonly SetupRepository _setupRepo;
        private IMapper _mapper;
        public PageController(PageRepository pageRepo,IMapper mapper, SetupRepository setupRepo)
        {
            _pageRepo = pageRepo;
            _mapper = mapper;
            _setupRepo = setupRepo;
        }

        [HttpGet]
        [Route("{slug}")]
        public IActionResult Index(string slug)
        {
            var setupValues = _setupRepo.getQueryable().ToList();
            ViewBag.setup = setupValues;


            var page = _pageRepo.getBySlug(slug);
            if (page == null)
            {
                return View(new PageDetail());
            }
            var pageDetail = _mapper.Map<PageDetail>(page);
            return View(pageDetail);
        }

       
    }
}