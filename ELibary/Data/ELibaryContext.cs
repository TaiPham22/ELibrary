using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ELibary.Models;

namespace ELibary.Data
{
    public class ELibaryContext : DbContext
    {
        public ELibaryContext (DbContextOptions<ELibaryContext> options)
            : base(options)
        { 
        }

        public DbSet<ELibary.Models.BaiGiang_TaiNguyen>? BaiGiang_TaiNguyen { get; set; }

        public DbSet<ELibary.Models.DeThi>? DeThi { get; set; }

        public DbSet<ELibary.Models.HeThongThuVien>? HeThongThuVien { get; set; }

        public DbSet<ELibary.Models.LopHoc>? LopHoc { get; set; }

        public DbSet<ELibary.Models.MonHoc>? MonHoc { get; set; }

        public DbSet<ELibary.Models.NguoiDung>? NguoiDung { get; set; }

        public DbSet<ELibary.Models.TaiKhoan>? TaiKhoan { get; set; }

        public DbSet<ELibary.Models.TaiLieu>? TaiLieu { get; set; }

        public DbSet<ELibary.Models.TepRieng>? TepRieng { get; set; }

        public DbSet<ELibary.Models.ThongBao>? ThongBao { get; set; }

        public DbSet<ELibary.Models.TroGiup>? TroGiup { get; set; }

        public DbSet<ELibary.Models.Role>? Role { get; set; }
        public DbSet<ELibary.Models.Giangday>? GiangDay { get; set; }
        public DbSet<ELibary.Models.PhanCong>? PhanCong { get; set; }
    }
}
