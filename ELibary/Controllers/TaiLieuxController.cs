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
    public class TaiLieuController : ControllerBase
    {
        private readonly ELibaryContext _context;

        public TaiLieuController(ELibaryContext context)
        {
            _context = context;
        }

        // GET: api/TaiLieu
        [HttpGet]
        public IActionResult GetTaiLieu(string mon = null, string gv = null, string tinhtrang = null, string ten = null)
        {
            if (mon == null && gv == null && tinhtrang == null && ten == null)
            {
                var get = (from c in _context.TaiLieu
                           join b in _context.BaiGiang_TaiNguyen on c.Id equals b.Id
                           join a in _context.NguoiDung on b.NguoiChinhSua equals a.MaNguoiDung
                           select new
                           {
                               c.Id,
                               b.LoaiFile,
                               b.Ten,
                               PhanLoai = b.PhanLoai == true ? "bài giảng" : "tài nguyên",
                               b.TenMon,
                               NguoiGui = a.TenNguoiDung,
                               c.NguoiPheDuyet,
                               c.NgayGui,
                               c.TinhTrang,
                               b.KichThuoc
                           });
                return Ok(get);
            }
            else if (ten == null)
            {
                return LocTaiLieu(mon, gv, tinhtrang);
            }
            else
            {
                return TimKiemTaiLieu(ten);
            }
        }
        private IActionResult TimKiemTaiLieu(string tukhoa)
        {

            var get = (from c in _context.TaiLieu
                       join b in _context.BaiGiang_TaiNguyen on c.Id equals b.Id
                       join a in _context.NguoiDung on b.NguoiChinhSua equals a.MaNguoiDung
                       where b.Ten.Contains(tukhoa)
                       select new
                       {
                           b.Id,
                           b.LoaiFile,
                           b.Ten,
                           PhanLoai = b.PhanLoai == true ? "bài giảng" : "tài nguyên",
                           b.TenMon,
                           NguoiGui = a.TenNguoiDung,
                           c.NguoiPheDuyet,
                           c.NgayGui,
                           c.TinhTrang,
                           b.KichThuoc
                       }).OrderBy(x => x.Ten);

            return Ok(get);
        }

        private IActionResult LocTaiLieu(string mon, string gv, string tinhtrang)
        {

            var get = (from c in _context.TaiLieu
                       join b in _context.BaiGiang_TaiNguyen on c.Id equals b.Id
                       join a in _context.NguoiDung on b.NguoiChinhSua equals a.MaNguoiDung
                       where b.MaMon == mon || b.NguoiChinhSua == gv || c.TinhTrang == tinhtrang
                       select new
                       {
                           b.Id,
                           b.LoaiFile,
                           b.Ten,
                           PhanLoai = b.PhanLoai == true ? "bài giảng" : "tài nguyên",
                           b.TenMon,
                           NguoiGui = a.TenNguoiDung,
                           c.NguoiPheDuyet,
                           c.NgayGui,
                           c.TinhTrang,
                           b.KichThuoc
                       }).OrderBy(x => x.Ten);

            return Ok(get);

        }


        [Route("api/TaiLieu")]
        [HttpPut]
        public IActionResult PheDuyet(int id, string nguoipheduyet, string tinhtrang, string ghichu = null)
        {
            TaiLieu tailieu = _context.TaiLieu.SingleOrDefault(n => n.Id == id);
            try
            {
                if (tailieu != null)
                {
                    tailieu.NguoiPheDuyet = nguoipheduyet;
                    tailieu.TinhTrang = tinhtrang;
                    tailieu.GhiChu = ghichu;
                    _context.SaveChanges();
                    return Ok(tinhtrang);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Lỗi");
            }

        }
        [HttpDelete]
        public IActionResult XoaTaiLieu(int id)
        {
            TaiLieu tailieu = _context.TaiLieu.SingleOrDefault(n => n.Id == id);
            try
            {
                if (tailieu != null)
                {
                    _context.Remove(tailieu);
                    _context.SaveChanges();
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest("Lỗi");
            }

        }


        private bool TaiLieuExists(int id)
        {
            return _context.TaiLieu.Count(e => e.Id == id) > 0;
        }
    }
}
