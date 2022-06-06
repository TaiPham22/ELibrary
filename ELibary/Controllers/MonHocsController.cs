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
    public class MonHocController : ControllerBase
    {
        private readonly ELibaryContext _context;

        public MonHocController(ELibaryContext context)
        {
            _context = context;
        }

        // GET: api/MonHoc
        [Route("api/MonHoc")]
        [HttpGet]
        public IActionResult GetMonHoc()
        {
            
                var monhoc = (from m in _context.MonHoc
                              select new
                              {
                                  m.MaMon,
                                  m.TenMonHoc,
                                  m.MoTa,
                                  m.GiangVien,
                                  SoTaiLieuChoDuyet = (from t in _context.TaiLieu
                                                       join bt in _context.BaiGiang_TaiNguyen on t.Id equals bt.Id
                                                       where bt.MaMon == m.MaMon && t.TinhTrang == "Chờ phê duyệt"
                                                       select new
                                                       {
                                                       }
                                                       ).Count()
                              }
                              );


                return Ok(monhoc);
            
        }
        [Route("api/MonHoc/{id}")]
        [HttpGet]
        public IActionResult ChiTietMonHoc(int id)            //chi tiết môn học

        {
            var monhoc = (from m in _context.MonHoc
                          join a in _context.NguoiDung on m.MaMon equals a.MaNguoiDung
                          where m.Id == id
                          select new
                          {
                              m.MaMon,
                              m.TenMonHoc,
                              m.MoTa,
                              GiangVien = a.TenNguoiDung
                          }
                              );
            return Ok(monhoc);
        }

        // PUT: api/MonHoc/5               Cập nhật môn học
        [Route("api/MonHoc")]
        [HttpPut]
        public IActionResult PutMonHoc(int id, MonHoc monhoc)
        {
            try
            {
                var put = _context.MonHoc.SingleOrDefault(n => n.Id == id);
                if (put != null)
                {
                    put.TenMonHoc = monhoc.TenMonHoc;
                    put.MoTa = monhoc.MoTa;
                    put.GiangVien = monhoc.GiangVien;
                    put.ToBoMon = monhoc.ToBoMon;


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

        // POST: api/MonHoc                    Thêm môn học
        [Route("api/MonHoc")]
        [HttpPost]
        public IActionResult PostMonHoc(MonHoc monhoc)
        {
            try
            {
                if (monhoc != null)
                {
                    _context.MonHoc.Add(monhoc);
                    _context.SaveChanges();
                    return Ok(monhoc);
                }
                return BadRequest("Chưa nhập dữ liệu");
            }
            catch
            {
                return BadRequest("Lỗi");
            }
        }

        // POST: api/MonHoc/PhanCong           Phân công tài liệu

        //[Route("api/MonHoc/PhanCong")]
        //[HttpPost]
        //public IActionResult PhanCongTaiLieu(PhanCong tailieu)
        //{
        //    try
        //    {
        //        if (tailieu != null)
        //        {
        //            _context.PhanCongs.Add(tailieu);
        //            _context.SaveChanges();
        //            return Ok(tailieu);
        //        }
        //        return BadRequest("Chưa nhập dữ liệu");
        //    }
        //    catch
        //    {
        //        return BadRequest("Lỗi");
        //    }
        //}

        // DELETE: api/MonHoc/5
        [Route("api/MonHoc")]
        [HttpDelete]
        public IActionResult DeleteMonHoc(int id)
        {
            try
            {
                var delete = _context.MonHoc.SingleOrDefault(n => n.Id == id);
                if (delete != null)
                {
                    _context.MonHoc.Remove(delete);
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
        private bool MonHocExists(int id)
        {
            return _context.MonHoc.Count(e => e.Id == id) > 0;
        }
    }
}
