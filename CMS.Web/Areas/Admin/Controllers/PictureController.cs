using AutoMapper;
using CMS.Core.Dto;
using CMS.Core.Entity;
using CMS.Core.Repository.Interface;
using CMS.Core.Service.Interface;
using CMS.Web.Areas.Admin.FilterModel;
using CMS.Web.Areas.Admin.ViewModels;
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
using System.Threading.Tasks;

namespace CMS.Web.Areas.Admin.Controllers
{
    [Authorize]
    [Area("admin")]
    [Route("admin/picture")]
    public class PictureController : Controller
    {
        private readonly PictureRepository _pictureRepository;
        private readonly PictureService _pictureService;
        private readonly IMapper _mapper;
        private readonly FileHelper _fileHelper;
        private readonly PaginatedMetaService _paginatedMetaService;
        public PictureController(PictureRepository pictureRepository, PictureService pictureService, PaginatedMetaService paginatedMetaService, IMapper mapper, FileHelper fileHelper)
        {
            _pictureRepository = pictureRepository;
            _pictureService = pictureService;
            _mapper = mapper;
            _fileHelper = fileHelper;
            _paginatedMetaService = paginatedMetaService;
        }
        [Route("")]
        [Route("index")]
        public IActionResult Index(PictureFilter filter = null)
        {
            try
            {
                var picture = _pictureRepository.getQueryable();
                if (!string.IsNullOrWhiteSpace(filter.title))
                {
                    picture = picture.Where(a => a.title.Contains(filter.title));
                }
                ViewBag.pagerInfo = _paginatedMetaService.GetMetaData(picture.Count(), filter.page, filter.number_of_rows);
                picture = picture.Skip(filter.number_of_rows * (filter.page - 1)).Take(filter.number_of_rows);
                var pictures = picture.ToList();
                var pictureIndexVM = getViewModelFrom(pictures);
                return View(pictureIndexVM);
            }
            catch (Exception ex)
            {
                AlertHelper.setMessage(this, ex.Message, messageType.error);
                return Redirect("index");
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
        public IActionResult add(PictureModel pictureModel, IFormFile file = null, IFormFile fileOne = null, IFormFile fileTwo = null, IFormFile fileThree = null, IFormFile fileFour = null, IFormFile fileFive = null)
        {
            try
            {
                PictureDto dto = new PictureDto();
                dto.image_name = pictureModel.image_name;
                dto.title = pictureModel.title;
                dto.is_enabled = pictureModel.is_enabled;
                dto.is_male = pictureModel.is_male;
                dto.is_female = pictureModel.is_female;
                dto.is_slider_image = pictureModel.is_slider_image;
                dto.picture_id = pictureModel.picture_id;
                dto.slug = pictureModel.slug;

                if (file != null)
                {
                    string fileName = pictureModel.title;
                    pictureModel.image_name = _fileHelper.saveImageAndGetFileName(file, fileName);
                    dto.image_name = pictureModel.image_name;
                }
                if (fileOne != null)
                {
                    string fileNameOne = pictureModel.title;
                    pictureModel.image1 = _fileHelper.saveImageAndGetFileName(fileOne, fileNameOne);
                    dto.image1 = pictureModel.image1;
                }
                if (fileTwo != null)
                {
                    string fileNameTwo = pictureModel.title;
                    pictureModel.image2 = _fileHelper.saveImageAndGetFileName(fileTwo, fileNameTwo);
                    dto.image2 = pictureModel.image2;
                }
                if (fileThree != null)
                {
                    string fileNameThree = pictureModel.title;
                    pictureModel.image3 = _fileHelper.saveImageAndGetFileName(fileThree, fileNameThree);
                    dto.image3 = pictureModel.image3;
                }
                if (fileFour != null)
                {
                    string fileNameFour = pictureModel.title;
                    pictureModel.image4 = _fileHelper.saveImageAndGetFileName(fileFour, fileNameFour);
                    dto.image4 = pictureModel.image4;
                }
                if (fileFive != null)
                {
                    string fileNameFive = pictureModel.title;
                    pictureModel.image5 = _fileHelper.saveImageAndGetFileName(fileFive, fileNameFive);
                    dto.image5 = pictureModel.image5;
                }
                _pictureService.save(dto);
                AlertHelper.setMessage(this, " Picture Saved Successfully", messageType.success);
                return RedirectToAction("index");


            }
            catch (Exception ex)
            {

                AlertHelper.setMessage(this, ex.Message, messageType.error);
            }
            
            var owner = _pictureRepository.getQueryable().ToList();
            return View(pictureModel);

        }
        [HttpGet]
        [Route("edit/{picture_id}")]
        public IActionResult edit(long picture_id)
        {
         
            try
            {
                Picture picture = _pictureRepository.getById(picture_id);
                PictureModel pictureModel = _mapper.Map<PictureModel>(picture);
                var owner = _pictureRepository.getQueryable().ToList();
                ViewBag.categories = new SelectList(owner, "picture_id", "name");
                return View(pictureModel);
            }
            catch (Exception ex)
            {
                AlertHelper.setMessage(this, ex.Message, messageType.error);
                return RedirectToAction("index");
            }

        }
        [HttpPost]
        [Route("edit")]
        public IActionResult edit(PictureModel pictureModel, IFormFile file = null, IFormFile fileOne = null, IFormFile fileTwo = null, IFormFile fileThree = null, IFormFile fileFour = null, IFormFile fileFive = null)
        {
            try
            {
                PictureDto dto = new PictureDto();
                dto.title = pictureModel.title;
                dto.is_enabled = pictureModel.is_enabled;
                dto.is_male = pictureModel.is_male;
                dto.is_female = pictureModel.is_female;
                dto.is_slider_image = pictureModel.is_slider_image;
                dto.picture_id = pictureModel.picture_id;
                dto.slug = pictureModel.slug;
                if (ModelState.IsValid)
                {
                    if (file != null)
                    {
                        string fileName = pictureModel.title;
                        pictureModel.image_name = _fileHelper.saveImageAndGetFileName(file, fileName);
                        dto.image_name = pictureModel.image_name;

                    }
                    if (fileOne != null)
                    {
                        string fileNameOne = pictureModel.title;
                        pictureModel.image1 = _fileHelper.saveImageAndGetFileName(fileOne, fileNameOne);
                        dto.image1 = pictureModel.image1;
                    }
                    if (fileTwo != null)
                    {
                        string fileNameTwo = pictureModel.title;
                        pictureModel.image2 = _fileHelper.saveImageAndGetFileName(fileTwo, fileNameTwo);
                        dto.image2 = pictureModel.image2;
                    }
                    if (fileThree != null)
                    {
                        string fileNameThree = pictureModel.title;
                        pictureModel.image3 = _fileHelper.saveImageAndGetFileName(fileThree, fileNameThree);
                        dto.image3 = pictureModel.image3;
                    }
                    if (fileFour != null)
                    {
                        string fileNameFour = pictureModel.title;
                        pictureModel.image4 = _fileHelper.saveImageAndGetFileName(fileFour, fileNameFour);
                        dto.image4 = pictureModel.image4;
                    }
                    if (fileFive != null)
                    {
                        string fileNameFive = pictureModel.title;
                        pictureModel.image5 = _fileHelper.saveImageAndGetFileName(fileFive, fileNameFive);
                        dto.image5 = pictureModel.image5;
                    }
                    _pictureService.update(dto);
                    AlertHelper.setMessage(this, "Picture updated successfully", messageType.success);
                    return RedirectToAction("index");

                }
            }
            catch (Exception ex)
            {

                AlertHelper.setMessage(this, ex.Message, messageType.error);
            }
            var owner = _pictureRepository.getQueryable().ToList();
            ViewBag.categories = new SelectList(owner, "picture_id", "name");
            return View(pictureModel);

        }
        [HttpGet]
        [Route("delete/{picture_id}")]
        public IActionResult delete(long picture_id)
        {
            try
            {
                _pictureService.delete(picture_id);
                AlertHelper.setMessage(this, "Picture deleted successfully.", messageType.success);


            }
            catch (Exception ex)
            {

                AlertHelper.setMessage(this, ex.Message, messageType.error);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [Route("enable/{Picture_id}")]
        public IActionResult enable(long picture_id)
        {
            try
            {
                _pictureService.enable(picture_id);
                AlertHelper.setMessage(this, "Picture enabled successfully.", messageType.success);
            }
            catch (Exception ex)
            {
                AlertHelper.setMessage(this, ex.Message, messageType.error);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [Route("disable/{Picture_id}")]
        public IActionResult disable(long picture_id)
        {
            try
            {
                _pictureService.disable(picture_id);
                AlertHelper.setMessage(this, "Picture disabled successfully.", messageType.success);
            }
            catch (Exception ex)
            {
                AlertHelper.setMessage(this, ex.Message, messageType.error);
            }
            return RedirectToAction(nameof(Index));
        }
        private object getViewModelFrom(List<CMS.Core.Entity.Picture> pictures)
        {
            PictureIndexViewModel vm = new PictureIndexViewModel();
            vm.picture_details = new List<PictureDetailModel>();
            foreach (var picture in pictures)
            {
                var pictureDetail = _mapper.Map<PictureDetailModel>(picture);
                vm.picture_details.Add(pictureDetail);
            }

            return vm;
        }
        [HttpGet]
        [Route("make-slider/{Picture_id}")]
        public IActionResult makeSlider(long picture_id)
        {
            try
            {
                _pictureService.makeSliderImage(picture_id);
                AlertHelper.setMessage(this, "Image set to Home image slider successfully.", messageType.success);
            }
            catch (Exception ex)
            {
                AlertHelper.setMessage(this, ex.Message, messageType.error);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [Route("unmake-slider/{Picture_id}")]
        public IActionResult unmakeSlider(long picture_id)
        {
            try
            {
                _pictureService.removeFromSliderImage(picture_id);
                AlertHelper.setMessage(this, "Image removed from Home slider image successfully.", messageType.success);
            }
            catch (Exception ex)
            {
                AlertHelper.setMessage(this, ex.Message, messageType.error);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("makemale/{Picture_id}")]
        public IActionResult makemale(long picture_id)
        {
            try
            {
                _pictureService.makemale(picture_id);
                AlertHelper.setMessage(this, "Image set to male successfully.", messageType.success);
            }
            catch (Exception ex)
            {
                AlertHelper.setMessage(this, ex.Message, messageType.error);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [Route("unmakemale/{Picture_id}")]
        public IActionResult unmakemale(long picture_id)
        {
            try
            {
                _pictureService.unmakemale(picture_id);
                AlertHelper.setMessage(this, "Image removed from male successfully.", messageType.success);
            }
            catch (Exception ex)
            {
                AlertHelper.setMessage(this, ex.Message, messageType.error);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [Route("makefemale/{Picture_id}")]
        public IActionResult makefemale(long picture_id)
        {
            try
            {
                _pictureService.makefemale(picture_id);
                AlertHelper.setMessage(this, "Image set to female successfully.", messageType.success);
            }
            catch (Exception ex)
            {
                AlertHelper.setMessage(this, ex.Message, messageType.error);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [Route("unmakefemale/{Picture_id}")]
        public IActionResult unmakefemale(long picture_id)
        {
            try
            {
                _pictureService.unmakefemale(picture_id);
                AlertHelper.setMessage(this, "Image removed from female successfully.", messageType.success);
            }
            catch (Exception ex)
            {
                AlertHelper.setMessage(this, ex.Message, messageType.error);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
