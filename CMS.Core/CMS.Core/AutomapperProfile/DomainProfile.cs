using AutoMapper;
using CMS.Core.Dto;
using CMS.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Core.AutomapperProfile
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<PlayerProfile, PlayerProfileDto>();
            CreateMap<Outlet, OutletDto>();
            CreateMap<FranchiseModel, FranchiseModelDto>();
            CreateMap<Gallery, GalleryDto>();
            CreateMap<Notice, NoticeDto>();
            CreateMap<PageCategory, PageCategoryDto>();
            CreateMap<PageCategoryDto, PageCategory>();
            CreateMap<Testimonial, TestimonialDto>();
            CreateMap<ReceivedEmail, ReceivedEmailDto>();
            CreateMap<Designation, DesignationDto>();
            CreateMap<Event, EventDto>();
            CreateMap<Details, DetailsDto>();
            CreateMap<Blog, BlogDto>();
            CreateMap<BlogDto, Blog>();
            CreateMap<Video, VideoDto>();
            CreateMap<VideoDto, Video>();
            CreateMap<BlogComment, BlogCommentDto>();
            CreateMap<BlogCommentDto, BlogComment>();
            CreateMap<Services, ServicesDto>();
            CreateMap<ServicesDto, Services>();
            CreateMap<ServicesCategory, ServicesCategoryDto>();
            CreateMap<ServicesCategoryDto, ServicesCategory>();

            CreateMap<Picture, PictureDto>();
            CreateMap<PictureDto, Picture>();

            CreateMap<Enquiry, EnquiryDto>();
            CreateMap<EnquiryDto, Enquiry>();
        }
    }
}
