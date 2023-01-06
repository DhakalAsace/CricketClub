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
using CMS.Web.Helpers;
using CMS.Web.LEPagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("admin")]
    [Route("admin/player-profile")]
    public class PlayerProfileController : Controller
    {
        private readonly PlayerProfileRepository _playerProfileRepository;
        private readonly PlayerProfileService _playerProfileService;
        private readonly IMapper _mapper;
        private readonly FileHelper _fileHelper;
        private readonly PaginatedMetaService _paginatedMetaService;

        public PlayerProfileController(PlayerProfileRepository playerProfileRepository, PlayerProfileService playerProfileService, PaginatedMetaService paginatedMetaService, IMapper mapper, FileHelper fileHelper)
        {
            _playerProfileRepository = playerProfileRepository;
            _playerProfileService = playerProfileService;
            _mapper = mapper;
            _fileHelper = fileHelper;
            _paginatedMetaService = paginatedMetaService;



        }
        [Route("")]
        [Route("index")]

        public IActionResult Index(PlayerProfileFilter filter = null)
        {
            try
            {
                var PlayerProfile = _playerProfileRepository.getQueryable();
                if (!string.IsNullOrWhiteSpace(filter.name))
                {
                    PlayerProfile = PlayerProfile.Where(a => a.name.Contains(filter.name));
                }
                ViewBag.pagerInfo = _paginatedMetaService.GetMetaData(PlayerProfile.Count(), filter.page, filter.number_of_rows);
                PlayerProfile = PlayerProfile.Skip(filter.number_of_rows * (filter.page - 1)).Take(filter.number_of_rows);
                return View(PlayerProfile.OrderByDescending(a => a.player_profile_id).ToList());
            }
            catch (Exception ex)
            {
                AlertHelper.setMessage(this, ex.Message, messageType.error);
                return Redirect("/admin");
            }

        }
        [HttpGet]
        [Route("new")]
        public IActionResult add()
        {

            return View();
        }
        [HttpPost]
        [Route("new")]
        public IActionResult add(PlayerProfileDto model, IFormFile file)
        {
            try
            {
                if (file != null)
                {
                    string fileName = model.name;
                    model.image = _fileHelper.saveImageAndGetFileName(file, fileName);

                }
                _playerProfileService.save(model);
                AlertHelper.setMessage(this, " Player Saved Successfully", messageType.success);
                return RedirectToAction("index");

            }
            catch (Exception ex)
            {

                AlertHelper.setMessage(this, ex.Message, messageType.error);
            }
            return View(model);
        }
        [HttpGet]
        [Route("edit/{player_profile_id}")]
        public IActionResult edit(long player_profile_id)
        {
            try
            {
                var PlayerProfile = _playerProfileRepository.getById(player_profile_id);
                PlayerProfileDto dto = _mapper.Map<PlayerProfileDto>(PlayerProfile);
                return View(dto);
            }
            catch (Exception ex)
            {


                AlertHelper.setMessage(this, ex.Message, messageType.error);
                return RedirectToAction("index");
            }
        }
        [HttpPost]
        [Route("edit")]
        public IActionResult edit(PlayerProfileDto playerProfileDto, IFormFile file)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (file != null)
                    {
                        string fileName = playerProfileDto.name;
                        playerProfileDto.image = _fileHelper.saveImageAndGetFileName(file, fileName);

                    }

                    _playerProfileService.update(playerProfileDto);
                    AlertHelper.setMessage(this, "Player updated successfully", messageType.success);
                    return RedirectToAction("index");

                }
            }
            catch (Exception ex)
            {

                AlertHelper.setMessage(this, ex.Message, messageType.error);
            }
            return View(playerProfileDto);
        }

        [HttpGet]
        [Route("delete/{player_profile_id}")]
        public IActionResult delete(long player_profile_id)
        {
            try
            {
                _playerProfileService.delete(player_profile_id);
                AlertHelper.setMessage(this, "Player deleted successfully.", messageType.success);


            }
            catch (Exception ex)
            {

                AlertHelper.setMessage(this, ex.Message, messageType.error);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [Route("enable/{player_profile_id}")]
        public IActionResult enable(long player_profile_id)
        {
            try
            {
                _playerProfileService.enable(player_profile_id);
                AlertHelper.setMessage(this, "Profile enabled successfully.", messageType.success);
            }
            catch (Exception ex)
            {
                AlertHelper.setMessage(this, ex.Message, messageType.error);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("disable/{player_profile_id}")]
        public IActionResult disable(long player_profile_id)
        {
            try
            {
                _playerProfileService.disable(player_profile_id);
                AlertHelper.setMessage(this, "Profile disabled successfully.", messageType.success);
            }
            catch (Exception ex)
            {
                AlertHelper.setMessage(this, ex.Message, messageType.error);
            }
            return RedirectToAction(nameof(Index));
        }


    }
} 



