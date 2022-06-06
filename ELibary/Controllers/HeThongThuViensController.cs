using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ELibary.Data;
using ELibary.Models;

namespace ELibary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeThongThuVienController : ControllerBase
    {
        private readonly ELibaryContext _context;

        public HeThongThuVienController(ELibaryContext context)
        {
            _context = context;
        }
        [Route("api/ThuVien")]
        [HttpGet]
        public IActionResult GetThuVien(int id = -1)
        {
            if (id > 0)
            {
                HeThongThuVien thuvien = _context.HeThongThuVien.Find(id);
                if (thuvien == null)
                {
                    return NotFound();
                }

                return Ok(thuvien);
            }
            else
            {
                return Ok(_context.HeThongThuVien);
            }
        }

        // PUT: api/ThuVien/5          Cập nhật thông tin hệ thống thư viện
        [Route("api/ThuVien")]
        [HttpPut]
        public IActionResult PutThuVien(int id, HeThongThuVien thuvien)
        {
            try
            {
                var put = _context.HeThongThuVien.SingleOrDefault(n => n.Id == id);
                if (put != null)
                {
                    put.DiaChiTruyCap = thuvien.DiaChiTruyCap;
                    put.Email = thuvien.Email;
                    put.HieuTruong = thuvien.HieuTruong;
                    put.LoaiTruong = thuvien.LoaiTruong;
                    put.MaTruong = thuvien.MaTruong;
                    put.NgonNgu = thuvien.NgonNgu;
                    put.NienKhoa = thuvien.NienKhoa;
                    put.SĐT = thuvien.SĐT;
                    put.TenThuVien = thuvien.TenThuVien;
                    put.TenTruong = thuvien.TenTruong;
                    put.Website = thuvien.Website;


                    _context.SaveChanges();
                    return Ok(put);
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(ModelState);
            }
        }

        // POST: api/ThuViens
        private bool HeThongThuVienExists(string id)
        {
            return _context.HeThongThuVien.Count(e => e.MaTruong == id) > 0;
        }
    }
}
