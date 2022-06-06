using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELibary.Migrations
{
    public partial class ELibary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaiGiang_TaiNguyen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhanLoai = table.Column<bool>(type: "bit", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaMon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenMon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiChinhSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayChinhSuaCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KichThuoc = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaiGiang_TaiNguyen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeThi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoaiFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenDeThi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonHoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HinhThuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiLuong = table.Column<int>(type: "int", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayThi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiPheDuyet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeThi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeThongThuVien",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaTruong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenTruong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiTruong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HieuTruong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenThuVien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiaChiTruyCap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SĐT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgonNgu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NienKhoa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeThongThuVien", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LopHoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenLop = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LopHoc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MonHoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaMon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenMonHoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GiangVien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToBoMon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonHoc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDung",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNguoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenNguoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VaiTro = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaNguoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VaiTro = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaiLieu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTaiLieu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonHoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhanLoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiPheDuyet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayGui = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TinhTrang = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiLieu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TepRieng",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TheLoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenTep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySuaLanCuoi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    KichThuoc = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TepRieng", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThongBao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhanLoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaNguoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayThongBao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongBao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TroGiup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiGui = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayGui = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TroGiup", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaiGiang_TaiNguyen");

            migrationBuilder.DropTable(
                name: "DeThi");

            migrationBuilder.DropTable(
                name: "HeThongThuVien");

            migrationBuilder.DropTable(
                name: "LopHoc");

            migrationBuilder.DropTable(
                name: "MonHoc");

            migrationBuilder.DropTable(
                name: "NguoiDung");

            migrationBuilder.DropTable(
                name: "TaiKhoan");

            migrationBuilder.DropTable(
                name: "TaiLieu");

            migrationBuilder.DropTable(
                name: "TepRieng");

            migrationBuilder.DropTable(
                name: "ThongBao");

            migrationBuilder.DropTable(
                name: "TroGiup");
        }
    }
}
