using AutoMapper;
using CMS.Core.Dto;
using CMS.Core.Entity;
using CMS.Web.Areas.Core.Models;
using CMS.Web.Areas.Admin.ViewModels;
using CMS.Web.Areas.Core.ViewModels;
using CMS.Web.ViewModels;

namespace CMS.Web.Areas.Core.AutomapperProfiles
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {

            CreateMap<OutletModel, OutletDto>();
            CreateMap<OutletDto, Outlet>();
            CreateMap<Outlet, OutletModel>();

            CreateMap<FranchiseModels, FranchiseModelDto>();
            CreateMap<FranchiseModelDto, FranchiseModel>();
            CreateMap<FranchiseModel, FranchiseModels>();


            CreateMap<GalleryModel, GalleryDto>();
            CreateMap<GalleryDto, Gallery>();
            CreateMap<Gallery, GalleryModel>();

            CreateMap<NoticeDto, Notice>();

            CreateMap<PageCategoryModel, PageCategoryDto>();
            CreateMap<PageCategoryDto, PageCategoryModel>();
            CreateMap<PageCategoryDetailModel, PageCategory>();
            CreateMap<PageCategory, PageCategoryDetailModel>();

            CreateMap<PageDto, PageModel>();
            CreateMap<PageDto, Page>();
            CreateMap<PageModel, Page>();
            CreateMap<PageDetailModel, Page>();
            CreateMap<Page, PageDetailModel>();




            CreateMap<ServicesCategoryModel, ServicesCategoryDto>();
            CreateMap<ServicesCategoryDto, ServicesCategoryModel>();
            CreateMap<ServicesCategoryDetailModel, ServicesCategory>();
            CreateMap<ServicesCategory, ServicesCategoryDetailModel>();

            CreateMap<ServicesDto, ServicesModel>();
            CreateMap<ServicesDto, Services>();
            CreateMap<ServicesModel, Services>();
            CreateMap<ServicesDetailModel, Services>();
            CreateMap<Services, ServicesDetailModel>();

            CreateMap<Web.ViewModels.PageDetail, Page>();
            CreateMap<Page, Web.ViewModels.PageDetail>();

            CreateMap<TestimonialDto, Testimonial>();

            CreateMap<ReceivedEmailDto, ReceivedEmail>();

            CreateMap<EventDto, Event>();
            CreateMap<Event, EventDto>();

            CreateMap<DetailsDto, Details>();
            CreateMap<Details, DetailsDto>();


            CreateMap<Details, DetailsModel>();
            CreateMap<DetailsModel, Details>();

            CreateMap<DetailsDetailModel, Details>();
            CreateMap<Details, DetailsDetailModel>();

            CreateMap<Event, EventModel>();
            CreateMap<EventModel, Event>();

            CreateMap<EventDetailModel, Event>();
            CreateMap<Event, EventDetailModel>();

            CreateMap<Blog, BlogDto>();
            CreateMap<BlogDto, Blog>();

            CreateMap<ViewModels.BlogDetailModel, Blog>();
            CreateMap<Blog, ViewModels.BlogDetailModel>();

            CreateMap<BlogCommentDetailModel, BlogComment>();
            CreateMap<BlogComment, BlogCommentDetailModel>();

            CreateMap<GalleryImageDetailModel, GalleryImage>();
            CreateMap<GalleryImage, GalleryImageDetailModel>();

            CreateMap<PictureDetailModel, Picture>();
            CreateMap<Picture, PictureDetailModel>();



            CreateMap<GalleryImage, Gallery>();
            CreateMap<Gallery, GalleryImage>();

            CreateMap<GalleryDetailModel, Gallery>();
            CreateMap<Gallery, GalleryDetailModel>();

            CreateMap<BlogCommentDetailModel, BlogComment>();
            CreateMap<BlogComment, BlogCommentDetailModel>();

            CreateMap<VideoDetails, Video>();
            CreateMap<Video, VideoDetails>();


            CreateMap<EnquiryDetailModel, Enquiry>();
            CreateMap<Enquiry, EnquiryDetailModel>();

            CreateMap<PlayerProfile, PlayerProfileDto>();
            CreateMap<PlayerProfileDto, PlayerProfile>();
        }
    }
}
