using CMS.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;


namespace CMS.Core.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

       public DbSet<PlayerProfile> playerProfiles { get;set; }
        public DbSet<Services> services { get; set; }
        public DbSet<ServicesCategory> service_categories { get; set; }
        public DbSet<Video> videos { get; set; }
        public DbSet<GalleryImage> gallery_image { get; set; }
        public DbSet<Notice> notices { get; set; }
        public DbSet<Page> pages { get; set; }
        public DbSet<PageCategory> page_categories { get; set; }
        public DbSet<Setup> setup { get; set; }
        public DbSet<Testimonial> testimonials { get; set; }
        public DbSet<ReceivedEmail> received_emails { get; set; }
        public DbSet<Designation> designations { get; set; }
        public DbSet<FranchiseModel> franchiseModels { get; set; }
        public DbSet<Event> events { get; set; }
        public DbSet<Details> details { get; set; }

        public DbSet<Blog> blog { get; set; }
        public DbSet<BlogComment> blog_comment { get; set; }
        public DbSet<EmailSetup> email_setup { get; set; }
        public DbSet<Gallery> gallery { get; set; }
        public DbSet<GalleryImage> gallery_images { get; set; }
        public DbSet<Picture> pictures { get; set; }
        public DbSet<Outlet> outlets { get; set; }
        public DbSet<Enquiry> enquiries { get; set; }
    }
}
