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
    public class LopHocController : ControllerBase
    {
        private readonly ELibaryContext _context;

        public LopHocController(ELibaryContext context)
        {
            _context = context;
        }
        [Route("api/LopHoc")]
        [HttpGet]
        public IActionResult GetLopHoc(string mon = null, string tenlop = null)
        {
            if (mon == null && tenlop == null)
            {
                var get = (from l in _context.LopHoc
                           select new
                           {
                               l.MaLop,
                               l.TenLop
                           }).OrderBy(x => x.TenLop);
                return Ok(get);
            }
            else if (mon != null)
            {
                var get = (from gd in _context.BaiGiang_TaiNguyen
                           join m in _context.MonHoc on gd.MaMon equals m.MaMon
                           join l in _context.LopHoc on gd.MaMon equals l.MaLop
                           join gv in _context.NguoiDung on gd.Ten equals gv.MaNguoiDung
                           where gd.MaMon == mon
                           select new
                           {
                               m.TenMonHoc,
                               l.TenLop,
                               TenGV = gv.TenNguoiDung
                           }).OrderBy(x => x.TenMonHoc);
                return Ok(get);
            }
            else
            {
                var get = (from gd in _context.BaiGiang_TaiNguyen
                           join m in _context.MonHoc on gd.MaMon equals m.MaMon
                           join l in _context.LopHoc on gd.TenMon equals l.MaLop
                           join gv in _context.NguoiDung on gd.TenMon equals gv.MaNguoiDung
                           where l.TenLop.Contains(tenlop)
                           select new
                           {
                               m.TenMonHoc,
                               l.TenLop,
                               TenGV = gv.MaNguoiDung
                           }).OrderBy(x => x.TenMonHoc);
                return Ok(get);
            }

        }

        // PUT: api/LopHoc/5
        [Route("api/LopHoc/{id}")]
        [HttpPut]
        public IActionResult PutLopHoc(int id, LopHoc lopHoc)
        {
            try
            {
                var put = _context.LopHoc.SingleOrDefault(n => n.Id == id);
                if (put != null)
                {
                    put.TenLop = lopHoc.TenLop;
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

        // POST: api/LopHoc
        [Route("api/LopHoc")]
        [HttpPost]
        public IActionResult PostLopHoc(LopHoc lopHoc)
        {
            try
            {
                if (lopHoc != null)
                {
                    _context.LopHoc.Add(lopHoc);
                    _context.SaveChanges();
                    return Ok(lopHoc);
                }
                return BadRequest("Chưa nhập dữ liệu");
            }
            catch
            {
                return BadRequest("Lỗi");
            }
        }

        // DELETE: api/LopHoc/5
        [Route("api/LopHoc/{id}")]
        [HttpDelete]
        public IActionResult DeleteLopHoc(int id)
        {
            try
            {
                var delete = _context.LopHoc.SingleOrDefault(n => n.Id == id);
                if (delete != null)
                {
                    _context.LopHoc.Remove(delete);
                    _context.SaveChanges();
                    return Ok("Xóa thành công");
                }
                return Ok("Không có dữ liệu cần tìm");
            }
            catch (Exception ex)
            {
                return BadRequest("Lỗi");
            }
        }

        private bool LopHocExists(int id)
        {
            return _context.LopHoc.Count(e => e.Id == id) > 0;
        }
    }
}
