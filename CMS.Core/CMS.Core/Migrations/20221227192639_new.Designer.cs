﻿// <auto-generated />
using System;
using CMS.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CMS.Core.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221227192639_new")]
    partial class @new
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CMS.Core.Entity.Blog", b =>
                {
                    b.Property<long>("blog_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("artical_by")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("description")
                        .HasMaxLength(50000);

                    b.Property<string>("image_name")
                        .HasMaxLength(100);

                    b.Property<bool>("is_enabled");

                    b.Property<DateTime>("posted_on");

                    b.Property<string>("slug")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("blog_id");

                    b.ToTable("blog");
                });

            modelBuilder.Entity("CMS.Core.Entity.BlogComment", b =>
                {
                    b.Property<long>("blog_comment_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("blogComment");

                    b.Property<long>("blog_id");

                    b.Property<string>("comment_by")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("comment_date");

                    b.Property<string>("comments")
                        .IsRequired()
                        .HasMaxLength(5000);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.HasKey("blog_comment_id");

                    b.HasIndex("blogComment");

                    b.HasIndex("blog_id");

                    b.ToTable("blog_comment");
                });

            modelBuilder.Entity("CMS.Core.Entity.Designation", b =>
                {
                    b.Property<long>("Designation_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("position")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Designation_id");

                    b.ToTable("designations");
                });

            modelBuilder.Entity("CMS.Core.Entity.Details", b =>
                {
                    b.Property<long>("details_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("value0");

                    b.Property<long>("value1");

                    b.Property<long>("value2");

                    b.Property<long>("value3");

                    b.Property<long>("value4");

                    b.HasKey("details_id");

                    b.ToTable("details");
                });

            modelBuilder.Entity("CMS.Core.Entity.EmailSetup", b =>
                {
                    b.Property<long>("email_setup_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email");

                    b.Property<string>("host");

                    b.Property<string>("password")
                        .IsRequired();

                    b.Property<string>("port");

                    b.HasKey("email_setup_id");

                    b.ToTable("email_setup");
                });

            modelBuilder.Entity("CMS.Core.Entity.Enquiry", b =>
                {
                    b.Property<long>("enquiry_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address")
                        .HasMaxLength(100);

                    b.Property<string>("contact_number")
                        .HasMaxLength(50);

                    b.Property<string>("description")
                        .HasMaxLength(5000);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<DateTime>("enquiry_date");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("enquiry_id");

                    b.ToTable("enquiries");
                });

            modelBuilder.Entity("CMS.Core.Entity.Event", b =>
                {
                    b.Property<long>("event_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .IsRequired();

                    b.Property<DateTime>("event_from_date");

                    b.Property<DateTime>("event_to_date");

                    b.Property<string>("file_name")
                        .HasMaxLength(70);

                    b.Property<string>("image_name")
                        .HasMaxLength(70);

                    b.Property<bool>("is_closed");

                    b.Property<string>("slug")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.Property<string>("time")
                        .HasMaxLength(200);

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("venue")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("event_id");

                    b.ToTable("events");
                });

            modelBuilder.Entity("CMS.Core.Entity.FranchiseModel", b =>
                {
                    b.Property<long>("franchise_model_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .IsRequired();

                    b.Property<string>("file_name");

                    b.Property<bool>("is_enabled");

                    b.Property<string>("slug")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("franchise_model_id");

                    b.ToTable("franchiseModels");
                });

            modelBuilder.Entity("CMS.Core.Entity.Gallery", b =>
                {
                    b.Property<long>("gallery_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("_description");

                    b.Property<string>("description");

                    b.Property<bool>("is_active");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("gallery_id");

                    b.ToTable("gallery");
                });

            modelBuilder.Entity("CMS.Core.Entity.GalleryImage", b =>
                {
                    b.Property<long>("gallery_image_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description");

                    b.Property<long>("gallery_id");

                    b.Property<string>("image_name")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.Property<bool>("is_default");

                    b.Property<bool>("is_enabled");

                    b.Property<bool>("is_slider_image");

                    b.Property<string>("title")
                        .HasMaxLength(70);

                    b.HasKey("gallery_image_id");

                    b.HasIndex("gallery_id");

                    b.ToTable("GalleryImage");
                });

            modelBuilder.Entity("CMS.Core.Entity.Notice", b =>
                {
                    b.Property<long>("notice_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description");

                    b.Property<string>("image_name")
                        .HasMaxLength(70);

                    b.Property<bool>("is_closed");

                    b.Property<DateTime>("notice_date");

                    b.Property<DateTime>("notice_expiry_date");

                    b.Property<string>("slug")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("notice_id");

                    b.ToTable("notices");
                });

            modelBuilder.Entity("CMS.Core.Entity.Outlet", b =>
                {
                    b.Property<long>("outlet_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address");

                    b.Property<string>("description")
                        .IsRequired();

                    b.Property<string>("file_name");

                    b.Property<bool>("is_enabled");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("outlet_id");

                    b.ToTable("outlets");
                });

            modelBuilder.Entity("CMS.Core.Entity.Page", b =>
                {
                    b.Property<long>("page_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description");

                    b.Property<string>("image_name")
                        .HasMaxLength(70);

                    b.Property<bool>("is_enabled");

                    b.Property<bool>("is_home_page");

                    b.Property<long>("page_category_id");

                    b.Property<string>("slug")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("page_id");

                    b.HasIndex("page_category_id");

                    b.ToTable("pages");
                });

            modelBuilder.Entity("CMS.Core.Entity.PageCategory", b =>
                {
                    b.Property<long>("page_category_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("is_enabled");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("slug")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.HasKey("page_category_id");

                    b.ToTable("page_categories");
                });

            modelBuilder.Entity("CMS.Core.Entity.Picture", b =>
                {
                    b.Property<long>("picture_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("image1");

                    b.Property<string>("image2");

                    b.Property<string>("image3");

                    b.Property<string>("image4");

                    b.Property<string>("image5");

                    b.Property<string>("image_name");

                    b.Property<bool>("is_enabled");

                    b.Property<bool>("is_female");

                    b.Property<bool>("is_male");

                    b.Property<bool>("is_slider_image");

                    b.Property<string>("slug");

                    b.Property<string>("title");

                    b.HasKey("picture_id");

                    b.ToTable("pictures");
                });

            modelBuilder.Entity("CMS.Core.Entity.PlayerProfile", b =>
                {
                    b.Property<long>("player_profile_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("birth_place")
                        .IsRequired();

                    b.Property<string>("carrier_info");

                    b.Property<string>("contact");

                    b.Property<string>("description");

                    b.Property<string>("fb_url");

                    b.Property<string>("height")
                        .IsRequired();

                    b.Property<string>("image");

                    b.Property<bool>("is_enabled");

                    b.Property<string>("name")
                        .IsRequired();

                    b.Property<int>("playerProfile");

                    b.Property<int>("role");

                    b.Property<string>("slug");

                    b.Property<int>("status");

                    b.Property<string>("web_url");

                    b.Property<string>("youtube_url");

                    b.HasKey("player_profile_id");

                    b.ToTable("playerProfiles");
                });

            modelBuilder.Entity("CMS.Core.Entity.ReceivedEmail", b =>
                {
                    b.Property<long>("received_email_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("date");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("message")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasMaxLength(1000);

                    b.Property<string>("sender_email")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("subject")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("received_email_id");

                    b.ToTable("received_emails");
                });

            modelBuilder.Entity("CMS.Core.Entity.Services", b =>
                {
                    b.Property<long>("service_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description");

                    b.Property<string>("image_name")
                        .HasMaxLength(70);

                    b.Property<string>("image_name_two")
                        .HasMaxLength(70);

                    b.Property<bool>("is_enabled");

                    b.Property<long>("service_category_id");

                    b.Property<string>("slug")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("service_id");

                    b.HasIndex("service_category_id");

                    b.ToTable("services");
                });

            modelBuilder.Entity("CMS.Core.Entity.ServicesCategory", b =>
                {
                    b.Property<long>("service_category_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("is_enabled");

                    b.Property<string>("slug")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("service_category_id");

                    b.ToTable("service_categories");
                });

            modelBuilder.Entity("CMS.Core.Entity.Setup", b =>
                {
                    b.Property<long>("setup_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("key")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.Property<string>("value")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.HasKey("setup_id");

                    b.ToTable("setup");
                });

            modelBuilder.Entity("CMS.Core.Entity.Testimonial", b =>
                {
                    b.Property<long>("testimonial_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("associated_company_name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("designation")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("image_name")
                        .HasMaxLength(100);

                    b.Property<bool>("is_visible");

                    b.Property<string>("person_name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("statement")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.HasKey("testimonial_id");

                    b.ToTable("testimonials");
                });

            modelBuilder.Entity("CMS.Core.Entity.Video", b =>
                {
                    b.Property<long>("video_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description")
                        .HasMaxLength(50000);

                    b.Property<bool>("is_enabled");

                    b.Property<bool>("is_home_video");

                    b.Property<string>("title");

                    b.Property<string>("video_url")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("video_id");

                    b.ToTable("videos");
                });

            modelBuilder.Entity("CMS.Core.Entity.BlogComment", b =>
                {
                    b.HasOne("CMS.Core.Entity.Blog")
                        .WithMany("blogComment")
                        .HasForeignKey("blogComment");

                    b.HasOne("CMS.Core.Entity.Blog", "blog")
                        .WithMany()
                        .HasForeignKey("blog_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CMS.Core.Entity.GalleryImage", b =>
                {
                    b.HasOne("CMS.Core.Entity.Gallery", "gallery")
                        .WithMany("gallery_images")
                        .HasForeignKey("gallery_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CMS.Core.Entity.Page", b =>
                {
                    b.HasOne("CMS.Core.Entity.PageCategory", "page_category")
                        .WithMany("pages")
                        .HasForeignKey("page_category_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CMS.Core.Entity.Services", b =>
                {
                    b.HasOne("CMS.Core.Entity.ServicesCategory", "service_category")
                        .WithMany("services")
                        .HasForeignKey("service_category_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}