using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Core.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "careers");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "exam_terms");

            migrationBuilder.DropTable(
                name: "faqs");

            migrationBuilder.DropTable(
                name: "members");

            migrationBuilder.DropTable(
                name: "partners");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "routine");

            migrationBuilder.DropTable(
                name: "specialities");

            migrationBuilder.DropTable(
                name: "faculty");

            migrationBuilder.DropTable(
                name: "fiscalYears");

            migrationBuilder.DropTable(
                name: "itemCategories");

            migrationBuilder.DropTable(
                name: "classes");

            migrationBuilder.DropTable(
                name: "specialitiesCategories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "careers",
                columns: table => new
                {
                    career_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    closing_date = table.Column<DateTime>(nullable: true),
                    description = table.Column<string>(maxLength: 2000, nullable: true),
                    image_name = table.Column<string>(maxLength: 70, nullable: true),
                    is_closed = table.Column<bool>(nullable: false),
                    opening_date = table.Column<DateTime>(nullable: false),
                    slug = table.Column<string>(maxLength: 120, nullable: false),
                    title = table.Column<string>(maxLength: 50, nullable: false)
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
                    answer = table.Column<string>(maxLength: 1000, nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    question = table.Column<string>(maxLength: 500, nullable: false)
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
                    is_current = table.Column<bool>(nullable: false),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fiscalYears", x => x.fiscal_year_id);
                });

            migrationBuilder.CreateTable(
                name: "itemCategories",
                columns: table => new
                {
                    designing_category_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(maxLength: 2000, nullable: true),
                    is_enabled = table.Column<bool>(nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    slug = table.Column<string>(maxLength: 55, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemCategories", x => x.designing_category_id);
                });

            migrationBuilder.CreateTable(
                name: "partners",
                columns: table => new
                {
                    partners_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    is_active = table.Column<bool>(nullable: false),
                    logo_name = table.Column<string>(maxLength: 250, nullable: true),
                    name = table.Column<string>(maxLength: 250, nullable: false),
                    web_url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_partners", x => x.partners_id);
                });

            migrationBuilder.CreateTable(
                name: "specialitiesCategories",
                columns: table => new
                {
                    project_category_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(nullable: true),
                    image_name = table.Column<string>(maxLength: 70, nullable: true),
                    is_enabled = table.Column<bool>(nullable: false),
                    name = table.Column<string>(maxLength: 60, nullable: false),
                    slug = table.Column<string>(maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specialitiesCategories", x => x.project_category_id);
                });

            migrationBuilder.CreateTable(
                name: "routine",
                columns: table => new
                {
                    routine_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    class_id = table.Column<long>(nullable: false),
                    end_date = table.Column<DateTime>(nullable: false),
                    image = table.Column<string>(nullable: false),
                    is_active = table.Column<bool>(nullable: false),
                    start_date = table.Column<DateTime>(nullable: false),
                    title = table.Column<string>(maxLength: 50, nullable: false)
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
                    description = table.Column<string>(nullable: true),
                    faculty_id = table.Column<long>(nullable: false),
                    features = table.Column<string>(nullable: true),
                    file_name = table.Column<string>(maxLength: 110, nullable: true),
                    is_enabled = table.Column<bool>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    slug = table.Column<string>(maxLength: 120, nullable: false),
                    specification = table.Column<string>(nullable: true)
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
                    address = table.Column<string>(maxLength: 50, nullable: true),
                    contact_number = table.Column<string>(maxLength: 50, nullable: true),
                    description = table.Column<string>(maxLength: 2000, nullable: true),
                    fiscal_year_id = table.Column<long>(nullable: false),
                    full_name = table.Column<string>(maxLength: 50, nullable: false),
                    image_url = table.Column<string>(maxLength: 120, nullable: true),
                    is_contact_enabled = table.Column<bool>(nullable: false)
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
                name: "products",
                columns: table => new
                {
                    designing_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(nullable: true),
                    designing_category_id = table.Column<long>(nullable: false),
                    file_name = table.Column<string>(maxLength: 110, nullable: true),
                    image_name_two = table.Column<string>(maxLength: 110, nullable: true),
                    is_enabled = table.Column<bool>(nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false),
                    slug = table.Column<string>(maxLength: 120, nullable: false)
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
                name: "specialities",
                columns: table => new
                {
                    project_id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    address = table.Column<string>(maxLength: 50, nullable: true),
                    description = table.Column<string>(nullable: true),
                    image_name = table.Column<string>(maxLength: 70, nullable: true),
                    image_name_four = table.Column<string>(maxLength: 70, nullable: true),
                    image_name_three = table.Column<string>(maxLength: 70, nullable: true),
                    image_name_two = table.Column<string>(maxLength: 70, nullable: true),
                    is_enabled = table.Column<bool>(nullable: false),
                    project_category_id = table.Column<long>(nullable: false),
                    slug = table.Column<string>(maxLength: 60, nullable: false),
                    title = table.Column<string>(maxLength: 50, nullable: false),
                    video_url = table.Column<string>(maxLength: 200, nullable: true)
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
                name: "IX_courses_faculty_id",
                table: "courses",
                column: "faculty_id");

            migrationBuilder.CreateIndex(
                name: "IX_members_Designation_id",
                table: "members",
                column: "Designation_id");

            migrationBuilder.CreateIndex(
                name: "IX_members_fiscal_year_id",
                table: "members",
                column: "fiscal_year_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_designing_category_id",
                table: "products",
                column: "designing_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_routine_class_id",
                table: "routine",
                column: "class_id");

            migrationBuilder.CreateIndex(
                name: "IX_specialities_project_category_id",
                table: "specialities",
                column: "project_category_id");
        }
    }
}
