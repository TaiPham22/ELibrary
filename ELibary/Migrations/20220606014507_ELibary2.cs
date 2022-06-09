using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELibary.Migrations
{
    public partial class ELibary2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenVaiTro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonHoc = table.Column<int>(type: "int", nullable: true),
                    TepRiengTu = table.Column<int>(type: "int", nullable: true),
                    TaiNguyen = table.Column<int>(type: "int", nullable: true),
                    De = table.Column<int>(type: "int", nullable: true),
                    ThongBao = table.Column<int>(type: "int", nullable: true),
                    PhanQuyen = table.Column<int>(type: "int", nullable: true),
                    NguoiDung = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
