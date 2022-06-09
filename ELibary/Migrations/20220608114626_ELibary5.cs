using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELibary.Migrations
{
    public partial class ELibary5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhanCong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lop = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChuDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaiGiang = table.Column<int>(type: "int", nullable: true),
                    BaiGiang_TaiNguyenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanCong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhanCong_BaiGiang_TaiNguyen_BaiGiang_TaiNguyenId",
                        column: x => x.BaiGiang_TaiNguyenId,
                        principalTable: "BaiGiang_TaiNguyen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhanCong_BaiGiang_TaiNguyenId",
                table: "PhanCong",
                column: "BaiGiang_TaiNguyenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhanCong");
        }
    }
}
