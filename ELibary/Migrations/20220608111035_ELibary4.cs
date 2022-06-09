using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELibary.Migrations
{
    public partial class ELibary4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GiangDay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaMon = table.Column<int>(type: "int", maxLength: 128, nullable: false),
                    MaGV = table.Column<int>(type: "int", maxLength: 128, nullable: false),
                    MaLop = table.Column<int>(type: "int", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiangDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiangDay_LopHoc_MaLop",
                        column: x => x.MaLop,
                        principalTable: "LopHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GiangDay_MonHoc_MaMon",
                        column: x => x.MaMon,
                        principalTable: "MonHoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GiangDay_NguoiDung_MaGV",
                        column: x => x.MaGV,
                        principalTable: "NguoiDung",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GiangDay_MaGV",
                table: "GiangDay",
                column: "MaGV");

            migrationBuilder.CreateIndex(
                name: "IX_GiangDay_MaLop",
                table: "GiangDay",
                column: "MaLop");

            migrationBuilder.CreateIndex(
                name: "IX_GiangDay_MaMon",
                table: "GiangDay",
                column: "MaMon");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GiangDay");
        }
    }
}
