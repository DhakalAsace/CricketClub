using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using AutoMapper;
using CMS.Core.Enums;
using CMS.Core.Repository.Interface;
using CMS.Core.Service.Interface;
using CMS.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Web.Controllers
{
    [Route("players")]
    public class PlayersController : Controller
    {
        public readonly PlayerProfileRepository _playersRepository;
        public readonly PictureRepository _pictureRepository;
        public readonly PlayerProfileService _playersService;
        private readonly SetupRepository _setupRepo;
        private readonly IMapper _mapper;

        public PlayersController(PictureRepository pictureRepository,PlayerProfileRepository playerProfileRepository, PlayerProfileService playerProfileService, SetupRepository setupRepository, IMapper mapper)
        {
            _playersRepository = playerProfileRepository;
            _pictureRepository = pictureRepository;
            _playersService = playerProfileService;
            _setupRepo = setupRepository;
            _mapper = mapper;
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index(CMS.Core.Enums.Role role)
        {
            var players = _playersRepository.getAll(); 
            PlayersIndexViewModel vm = new PlayersIndexViewModel();
            vm.players = new List<PlayersDetail>();
            var playerlist = new PlayersDetail();

            foreach (var product in players)
            {
                var data = _mapper.Map<PlayersDetail>(product);
                vm.players.Add(data);
            }
            return View(vm);
        }
      
 

        [HttpGet]
        [Route("player-detail/{name}")]
        //public IActionResult playerCategory(CMS.Core.Enums.Role role)
        //{
        //    var players = _playersRepository.getAll();
        //    if (players == null)
        //    {
        //        return View(new ProductDetail());
        //    }
        //    PlayersIndexViewModel vm = new PlayersIndexViewModel();
        //    vm.players = new List<PlayersDetail>();
        //    var playerlist = new PlayersDetail();

        //    foreach (var product in players)
        //    {
        //        var data = _mapper.Map<PlayersDetail>(product);
        //        vm.players.Add(data);
        //    }
        //    return View(vm);
        //}

        public IActionResult playerCategory(string name)
        {
            var player = new List<Core.Entity.PlayerProfile>();
            if(name == "Male")
            {
                 player = _playersRepository.getQueryable().Where(a => a.playerProfile == PlayerProfile.Male).ToList();

            }
            if (name == "Female")
            {
                player = _playersRepository.getQueryable().Where(a => a.playerProfile == PlayerProfile.Female).ToList();

            }

            if (name == "Male")
            {
                var Image = _pictureRepository.getQueryable().Where(g => g.is_slider_image == true && g.is_enabled == true && g.is_male == true).ToList();
                ViewBag.Images = Image;
            }

            if (name == "Female")
            {
                var Image = _pictureRepository.getQueryable().Where(g => g.is_slider_image == true && g.is_enabled == true && g.is_female == true).ToList();
                ViewBag.Images = Image;
            }
            PlayersIndexViewModel vm = new PlayersIndexViewModel();
            vm.players = new List<PlayersDetail>();
            foreach (var spec in player)
            {
                var detail = _mapper.Map<PlayersDetail>(spec);
                vm.players.Add(detail);
            }
            return View(vm);

        }


        [HttpGet]
        [Route("detail/{slug}")]
        public IActionResult detail(string slug)
        {
            var setupValues = _setupRepo.getQueryable().ToList();
            ViewBag.setup = setupValues;
            var players = _playersRepository.getQueryable().Where(a => a.is_enabled == true);
            ViewBag.Players = players;

            var playersDetail = _playersRepository.getBySlug(slug);
            return View(playersDetail);
        }

    }
}










