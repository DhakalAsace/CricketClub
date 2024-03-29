﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Core.Migrations
{
    public partial class playersadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "blog",
                columns: table => new
                {
                    blog_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    slug = table.Column<string>(maxLength: 120, nullable: false),
                    title = table.Column<string>(maxLength: 150, nullable: false),
                    posted_on = table.Column<DateTime>(nullable: false),
                    artical_by = table.Column<string>(maxLength: 200, nullable: false),
                    description = table.Column<string>(maxLength: 50000, nullable: true),
                    image_name = table.Column<string>(maxLength: 100, nullable: true),
                    is_enabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog", x => x.blog_id);
                });

            migrationBuilder.CreateTable(
                name: "careers",
                columns: table => new
                {
                    career_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(maxLength: 50, nullable: false),
                    opening_date = table.Column<DateTime>(nullable: false),
                    closing_date = table.Column<DateTime>(nullable: true),
                    description = table.Column<string>(maxLength: 2000, nullable: true),
                    image_name = table.Column<string>(maxLength: 70, nullable: true),
                    is_closed = table.Column<bool>(nullable: false),
                    slug = table.Column<string>(maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_careers", x => x.career_id);
                });

            migrationBuilder.CreateTable(
                name: "classes",
                columns: table => new
                {
                    class_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    is_active = table.Column<bool>(nullable: false),
                    name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classes", x => x.class_id);
                });

            migrationBuilder.CreateTable(
                name: "designations",
                columns: table => new
                {
                    Designation_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    position = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_designations", x => x.Designation_id);
                });

            migrationBuilder.CreateTable(
                name: "details",
                columns: table => new
                {
                    details_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    value1 = table.Column<long>(nullable: false),
                    value2 = table.Column<long>(nullable: false),
                    value3 = table.Column<long>(nullable: false),
                    value4 = table.Column<long>(nullable: false),
                    value0 = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_details", x => x.details_id);
                });

            migrationBuilder.CreateTable(
                name: "email_setup",
                columns: table => new
                {
                    email_setup_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    password = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    port = table.Column<string>(nullable: true),
                    host = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_email_setup", x => x.email_setup_id);
                });

            migrationBuilder.CreateTable(
                name: "enquiries",
                columns: table => new
                {
                    enquiry_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    address = table.Column<string>(maxLength: 100, nullable: true),
                    contact_number = table.Column<string>(maxLength: 50, nullable: true),
                    name = table.Column<string>(maxLength: 200, nullable: false),
                    email = table.Column<string>(maxLength: 300, nullable: false),
                    description = table.Column<string>(maxLength: 5000, nullable: true),
                    enquiry_date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enquiries", x => x.enquiry_id);
                });

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    event_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(maxLength: 250, nullable: false),
                    slug = table.Column<string>(maxLength: 120, nullable: false),
                    event_from_date = table.Column<DateTime>(nullable: false),
                    event_to_date = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(nullable: false),
                    image_name = table.Column<string>(maxLength: 70, nullable: true),
                    venue = table.Column<string>(maxLength: 250, nullable: false),
                    file_name = table.Column<string>(maxLength: 70, nullable: true),
                    time = table.Column<string>(maxLength: 200, nullable: true),
                    is_closed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.event_id);
                });

            migrationBuilder.CreateTable(
                name: "exam_terms",
                columns: table => new
                {
                    exam_term_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    is_active = table.Column<bool>(nullable: false),
                    name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exam_terms", x => x.exam_term_id);
                });

            migrationBuilder.CreateTable(
                name: "faculty",
                columns: table => new
                {
                    faculty_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    is_active = table.Column<bool>(nullable: false),
                    name = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_faculty", x => x.faculty_id);
                });

            migrationBuilder.CreateTable(
                name: "faqs",
                columns: table => new
                {
                    faq_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    question = table.Column<string>(maxLength: 500, nullable: false),
                    answer = table.Column<string>(maxLength: 1000, nullable: false),
                    is_active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_faqs", x => x.faq_id);
                });

            migrationBuilder.CreateTable(
                name: "fiscalYears",
                columns: table => new
                {
                    fiscal_year_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: false),
                    is_current = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fiscalYears", x => x.fiscal_year_id);
                });

            migrationBuilder.CreateTable(
                name: "franchiseModels",
                columns: table => new
                {
                    franchise_model_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(maxLength: 50, nullable: false),
                    description = table.Column<string>(nullable: false),
                    slug = table.Column<string>(maxLength: 60, nullable: false),
                    file_name = table.Column<string>(nullable: true),
                    is_enabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_franchiseModels", x => x.franchise_model_id);
                });

            migrationBuilder.CreateTable(
                name: "gallery",
                columns: table => new
                {
                    gallery_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    is_active = table.Column<bool>(nullable: false),
                    _description = table.Column<string>(nullable: true),
                    name = table.Column<string>(maxLength: 200, nullable: false),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gallery", x => x.gallery_id);
                });

            migrationBuilder.CreateTable(
                name: "itemCategories",
                columns: table => new
                {
                    designing_category_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    slug = table.Column<string>(maxLength: 55, nullable: false),
                    description = table.Column<string>(maxLength: 2000, nullable: true),
                    is_enabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemCategories", x => x.designing_category_id);
                });

            migrationBuilder.CreateTable(
                name: "notices",
                columns: table => new
                {
                    notice_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    notice_date = table.Column<DateTime>(nullable: false),
                    notice_expiry_date = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    slug = table.Column<string>(maxLength: 120, nullable: false),
                    image_name = table.Column<string>(maxLength: 70, nullable: true),
                    title = table.Column<string>(maxLength: 250, nullable: false),
                    is_closed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notices", x => x.notice_id);
                });

            migrationBuilder.CreateTable(
                name: "outlets",
                columns: table => new
                {
                    outlet_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(maxLength: 50, nullable: false),
                    address = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: false),
                    file_name = table.Column<string>(nullable: true),
                    is_enabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_outlets", x => x.outlet_id);
                });

            migrationBuilder.CreateTable(
                name: "page_categories",
                columns: table => new
                {
                    page_category_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 60, nullable: false),
                    slug = table.Column<string>(maxLength: 70, nullable: false),
                    is_enabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_page_categories", x => x.page_category_id);
                });

            migrationBuilder.CreateTable(
                name: "partners",
                columns: table => new
                {
                    partners_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 250, nullable: false),
                    logo_name = table.Column<string>(maxLength: 250, nullable: true),
                    web_url = table.Column<string>(nullable: true),
                    is_active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_partners", x => x.partners_id);
                });

            migrationBuilder.CreateTable(
                name: "pictures",
                columns: table => new
                {
                    picture_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    image1 = table.Column<string>(nullable: true),
                    image2 = table.Column<string>(nullable: true),
                    image3 = table.Column<string>(nullable: true),
                    image4 = table.Column<string>(nullable: true),
                    image5 = table.Column<string>(nullable: true),
                    image_name = table.Column<string>(nullable: true),
                    is_enabled = table.Column<bool>(nullable: false),
                    is_slider_image = table.Column<bool>(nullable: false),
                    is_male = table.Column<bool>(nullable: false),
                    is_female = table.Column<bool>(nullable: false),
                    title = table.Column<string>(nullable: true),
                    slug = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pictures", x => x.picture_id);
                });

            migrationBuilder.CreateTable(
                name: "playerProfiles",
                columns: table => new
                {
                    player_profile_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: false),
                    birth_place = table.Column<string>(nullable: false),
                    height = table.Column<string>(nullable: false),
                    contact = table.Column<string>(nullable: true),
                    fb_url = table.Column<string>(nullable: true),
                    web_url = table.Column<string>(nullable: true),
                    youtube_url = table.Column<string>(nullable: true),
                    role = table.Column<int>(nullable: false),
                    playerProfile = table.Column<int>(nullable: false),
                    status = table.Column<int>(nullable: false),
                    carrier_info = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    image = table.Column<string>(nullable: true),
                    is_enabled = table.Column<bool>(nullable: false),
                    slug = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playerProfiles", x => x.player_profile_id);
                });

            migrationBuilder.CreateTable(
                name: "received_emails",
                columns: table => new
                {
                    received_email_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    sender_email = table.Column<string>(maxLength: 50, nullable: false),
                    first_name = table.Column<string>(maxLength: 30, nullable: false),
                    last_name = table.Column<string>(maxLength: 30, nullable: false),
                    subject = table.Column<string>(maxLength: 150, nullable: false),
                    message = table.Column<string>(maxLength: 1000, nullable: false),
                    phone = table.Column<string>(maxLength: 1000, nullable: false),
                    date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_received_emails", x => x.received_email_id);
                });

            migrationBuilder.CreateTable(
                name: "service_categories",
                columns: table => new
                {
                    service_category_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(maxLength: 60, nullable: false),
                    slug = table.Column<string>(maxLength: 70, nullable: false),
                    is_enabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_service_categories", x => x.service_category_id);
                });

            migrationBuilder.CreateTable(
                name: "setup",
                columns: table => new
                {
                    setup_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    key = table.Column<string>(maxLength: 70, nullable: false),
                    value = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_setup", x => x.setup_id);
                });

            migrationBuilder.CreateTable(
                name: "specialitiesCategories",
                columns: table => new
                {
                    project_category_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 60, nullable: false),
                    description = table.Column<string>(nullable: true),
                    image_name = table.Column<string>(maxLength: 70, nullable: true),
                    slug = table.Column<string>(maxLength: 70, nullable: false),
                    is_enabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialitiesCategories", x => x.project_category_id);
                });

            migrationBuilder.CreateTable(
                name: "testimonials",
                columns: table => new
                {
                    testimonial_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    person_name = table.Column<string>(maxLength: 50, nullable: false),
                    statement = table.Column<string>(maxLength: 500, nullable: false),
                    designation = table.Column<string>(maxLength: 50, nullable: false),
                    associated_company_name = table.Column<string>(maxLength: 200, nullable: false),
                    image_name = table.Column<string>(maxLength: 100, nullable: true),
                    is_visible = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_testimonials", x => x.testimonial_id);
                });

            migrationBuilder.CreateTable(
                name: "videos",
                columns: table => new
                {
                    video_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    video_url = table.Column<string>(maxLength: 200, nullable: false),
                    description = table.Column<string>(maxLength: 50000, nullable: true),
                    title = table.Column<string>(nullable: true),
                    is_enabled = table.Column<bool>(nullable: false),
                    is_home_video = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_videos", x => x.video_id);
                });

            migrationBuilder.CreateTable(
                name: "blog_comment",
                columns: table => new
                {
                    blog_comment_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    blog_id = table.Column<long>(nullable: false),
                    comment_by = table.Column<string>(maxLength: 200, nullable: false),
                    comment_date = table.Column<DateTime>(nullable: false),
                    email = table.Column<string>(maxLength: 300, nullable: false),
                    comments = table.Column<string>(maxLength: 5000, nullable: false),
                    blogComment = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog_comment", x => x.blog_comment_id);
                    table.ForeignKey(
                        name: "FK_blog_comment_blog_blogComment",
                        column: x => x.blogComment,
                        principalTable: "blog",
                        principalColumn: "blog_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_blog_comment_blog_blog_id",
                        column: x => x.blog_id,
                        principalTable: "blog",
                        principalColumn: "blog_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "routine",
                columns: table => new
                {
                    routine_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    title = table.Column<string>(maxLength: 50, nullable: false),
                    class_id = table.Column<long>(nullable: false),
                    start_date = table.Column<DateTime>(nullable: false),
                    end_date = table.Column<DateTime>(nullable: false),
                    image = table.Column<string>(nullable: false),
                    is_active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_routine", x => x.routine_id);
                    table.ForeignKey(
                        name: "FK_routine_classes_class_id",
                        column: x => x.class_id,
                        principalTable: "classes",
                        principalColumn: "class_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    course_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    faculty_id = table.Column<long>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    slug = table.Column<string>(maxLength: 120, nullable: false),
                    description = table.Column<string>(nullable: true),
                    specification = table.Column<string>(nullable: true),
                    features = table.Column<string>(nullable: true),
                    is_enabled = table.Column<bool>(nullable: false),
                    file_name = table.Column<string>(maxLength: 110, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.course_id);
                    table.ForeignKey(
                        name: "FK_courses_faculty_faculty_id",
                        column: x => x.faculty_id,
                        principalTable: "faculty",
                        principalColumn: "faculty_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    member_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Designation_id = table.Column<long>(nullable: false),
                    fiscal_year_id = table.Column<long>(nullable: false),
                    full_name = table.Column<string>(maxLength: 50, nullable: false),
                    address = table.Column<string>(maxLength: 50, nullable: true),
                    contact_number = table.Column<string>(maxLength: 50, nullable: true),
                    image_url = table.Column<string>(maxLength: 120, nullable: true),
                    is_contact_enabled = table.Column<bool>(nullable: false),
                    description = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_members", x => x.member_id);
                    table.ForeignKey(
                        name: "FK_members_designations_Designation_id",
                        column: x => x.Designation_id,
                        principalTable: "designations",
                        principalColumn: "Designation_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_members_fiscalYears_fiscal_year_id",
                        column: x => x.fiscal_year_id,
                        principalTable: "fiscalYears",
                        principalColumn: "fiscal_year_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GalleryImage",
                columns: table => new
                {
                    gallery_image_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    gallery_id = table.Column<long>(nullable: false),
                    image_name = table.Column<string>(maxLength: 70, nullable: false),
                    title = table.Column<string>(maxLength: 70, nullable: true),
                    description = table.Column<string>(nullable: true),
                    is_enabled = table.Column<bool>(nullable: false),
                    is_slider_image = table.Column<bool>(nullable: false),
                    is_default = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryImage", x => x.gallery_image_id);
                    table.ForeignKey(
                        name: "FK_GalleryImage_gallery_gallery_id",
                        column: x => x.gallery_id,
                        principalTable: "gallery",
                        principalColumn: "gallery_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    designing_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    designing_category_id = table.Column<long>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    slug = table.Column<string>(maxLength: 120, nullable: false),
                    description = table.Column<string>(nullable: true),
                    is_enabled = table.Column<bool>(nullable: false),
                    file_name = table.Column<string>(maxLength: 110, nullable: true),
                    image_name_two = table.Column<string>(maxLength: 110, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.designing_id);
                    table.ForeignKey(
                        name: "FK_products_itemCategories_designing_category_id",
                        column: x => x.designing_category_id,
                        principalTable: "itemCategories",
                        principalColumn: "designing_category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pages",
                columns: table => new
                {
                    page_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    page_category_id = table.Column<long>(nullable: false),
                    title = table.Column<string>(maxLength: 50, nullable: false),
                    slug = table.Column<string>(maxLength: 60, nullable: false),
                    description = table.Column<string>(nullable: true),
                    image_name = table.Column<string>(maxLength: 70, nullable: true),
                    is_enabled = table.Column<bool>(nullable: false),
                    is_home_page = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pages", x => x.page_id);
                    table.ForeignKey(
                        name: "FK_pages_page_categories_page_category_id",
                        column: x => x.page_category_id,
                        principalTable: "page_categories",
                        principalColumn: "page_category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    service_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    service_category_id = table.Column<long>(nullable: false),
                    title = table.Column<string>(maxLength: 50, nullable: false),
                    description = table.Column<string>(nullable: true),
                    is_enabled = table.Column<bool>(nullable: false),
                    slug = table.Column<string>(maxLength: 60, nullable: false),
                    image_name = table.Column<string>(maxLength: 70, nullable: true),
                    image_name_two = table.Column<string>(maxLength: 70, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services", x => x.service_id);
                    table.ForeignKey(
                        name: "FK_services_service_categories_service_category_id",
                        column: x => x.service_category_id,
                        principalTable: "service_categories",
                        principalColumn: "service_category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "specialities",
                columns: table => new
                {
                    project_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    project_category_id = table.Column<long>(nullable: false),
                    video_url = table.Column<string>(maxLength: 200, nullable: true),
                    title = table.Column<string>(maxLength: 50, nullable: false),
                    slug = table.Column<string>(maxLength: 60, nullable: false),
                    image_name_two = table.Column<string>(maxLength: 70, nullable: true),
                    image_name_three = table.Column<string>(maxLength: 70, nullable: true),
                    image_name_four = table.Column<string>(maxLength: 70, nullable: true),
                    description = table.Column<string>(nullable: true),
                    image_name = table.Column<string>(maxLength: 70, nullable: true),
                    address = table.Column<string>(maxLength: 50, nullable: true),
                    is_enabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialities", x => x.project_id);
                    table.ForeignKey(
                        name: "FK_specialities_specialitiesCategories_project_category_id",
                        column: x => x.project_category_id,
                        principalTable: "specialitiesCategories",
                        principalColumn: "project_category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_blog_comment_blogComment",
                table: "blog_comment",
                column: "blogComment");

            migrationBuilder.CreateIndex(
                name: "IX_blog_comment_blog_id",
                table: "blog_comment",
                column: "blog_id");

            migrationBuilder.CreateIndex(
                name: "IX_courses_faculty_id",
                table: "courses",
                column: "faculty_id");

            migrationBuilder.CreateIndex(
                name: "IX_GalleryImage_gallery_id",
                table: "GalleryImage",
                column: "gallery_id");

            migrationBuilder.CreateIndex(
                name: "IX_members_Designation_id",
                table: "members",
                column: "Designation_id");

            migrationBuilder.CreateIndex(
                name: "IX_members_fiscal_year_id",
                table: "members",
                column: "fiscal_year_id");

            migrationBuilder.CreateIndex(
                name: "IX_pages_page_category_id",
                table: "pages",
                column: "page_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_designing_category_id",
                table: "products",
                column: "designing_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_routine_class_id",
                table: "routine",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "IX_services_service_category_id",
                table: "services",
                column: "service_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_specialities_project_category_id",
                table: "specialities",
                column: "project_category_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blog_comment");

            migrationBuilder.DropTable(
                name: "careers");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "details");

            migrationBuilder.DropTable(
                name: "email_setup");

            migrationBuilder.DropTable(
                name: "enquiries");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "exam_terms");

            migrationBuilder.DropTable(
                name: "faqs");

            migrationBuilder.DropTable(
                name: "franchiseModels");

            migrationBuilder.DropTable(
                name: "GalleryImage");

            migrationBuilder.DropTable(
                name: "members");

            migrationBuilder.DropTable(
                name: "notices");

            migrationBuilder.DropTable(
                name: "outlets");

            migrationBuilder.DropTable(
                name: "pages");

            migrationBuilder.DropTable(
                name: "partners");

            migrationBuilder.DropTable(
                name: "pictures");

            migrationBuilder.DropTable(
                name: "playerProfiles");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "received_emails");

            migrationBuilder.DropTable(
                name: "routine");

            migrationBuilder.DropTable(
                name: "services");

            migrationBuilder.DropTable(
                name: "setup");

            migrationBuilder.DropTable(
                name: "specialities");

            migrationBuilder.DropTable(
                name: "testimonials");

            migrationBuilder.DropTable(
                name: "videos");

            migrationBuilder.DropTable(
                name: "blog");

            migrationBuilder.DropTable(
                name: "faculty");

            migrationBuilder.DropTable(
                name: "gallery");

            migrationBuilder.DropTable(
                name: "designations");

            migrationBuilder.DropTable(
                name: "fiscalYears");

            migrationBuilder.DropTable(
                name: "page_categories");

            migrationBuilder.DropTable(
                name: "itemCategories");

            migrationBuilder.DropTable(
                name: "classes");

            migrationBuilder.DropTable(
                name: "service_categories");

            migrationBuilder.DropTable(
                name: "specialitiesCategories");
        }
    }
}
