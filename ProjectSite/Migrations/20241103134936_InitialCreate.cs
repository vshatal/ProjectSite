using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectSite.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    res_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    adress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_restaurant = table.Column<int>(type: "int", nullable: false),
                    id_user = table.Column<int>(type: "int", nullable: false),
                    service_assessment = table.Column<int>(type: "int", nullable: true),
                    evaluation_of_the_first_courses = table.Column<int>(type: "int", nullable: true),
                    evaluation_of_the_second_courses = table.Column<int>(type: "int", nullable: true),
                    evaluation_of_snacks = table.Column<int>(type: "int", nullable: true),
                    dessert_evaluation = table.Column<int>(type: "int", nullable: true),
                    assessment_of_the_atmosphere = table.Column<int>(type: "int", nullable: true),
                    total_review = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Restaurant");

            migrationBuilder.DropTable(
                name: "Review");
        }
    }
}
