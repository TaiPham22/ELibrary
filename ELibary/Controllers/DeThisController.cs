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
    
    public class DeThiController : ControllerBase
    {
        private readonly ELibaryContext _context;

        public DeThiController(ELibaryContext context)
        {
            _context = context;
        }
        [Route("api/DeThi")]
        [HttpGet]
        public IActionResult GetDeThi(int id = -1)
        {
            if (id > 0)
            {
                DeThi dethi = _context.DeThi.Find(id);
                if (dethi == null)
                {
                    return NotFound();
                }

                return Ok(dethi);
            }
            else
            {
                return Ok(_context.DeThi);
            }
        }

        // PUT: api/DeThi/5
        [Route("api/DeThi")]
        [HttpPut]
        public IActionResult PutDeThi(int id, DeThi dethi)
        {
            try
            {
                var put = _context.DeThi.SingleOrDefault(n => n.Id == id);
                if (put != null)
                {

                    put.TenDeThi = dethi.TenDeThi;
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
        [Route("api/DeThi/PheDuyet")]
        [HttpPut]
        public IActionResult DuyetDeThi(int id, DeThi dethi)
        {
            try
            {
                var put = _context.DeThi.SingleOrDefault(n => n.Id == id);
                if (put != null)
                {

                    put.NguoiPheDuyet = dethi.NguoiPheDuyet;
                    put.TinhTrang = dethi.TinhTrang;
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

        // POST: api/DeThi
        [Route("api/DeThi/PheDuyet")]
        [HttpPost]
        public IActionResult PostDeThi(DeThi dethi)
        {
            try
            {
                if (dethi != null)
                {
                    dethi.NgayTao = DateTime.Now;
                    _context.DeThi.Add(dethi);
                    _context.SaveChanges();
                    return Ok(dethi);
                }
                return BadRequest("Chưa nhập dữ liệu");
            }
            catch
            {
                return BadRequest("Lỗi");
            }
        }

        // DELETE: api/DeThi/5
        [Route("api/DeThi")]
        [HttpDelete]
        public IActionResult DeleteDeThi(int id)
        {
            try
            {
                var delete = _context.DeThi.SingleOrDefault(n => n.Id == id);
                if (delete != null)
                {
                    _context.DeThi.Remove(delete);
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

        private bool DeThiExists(int id)
        {
            return _context.DeThi.Count(e => e.Id == id) > 0;
        }
    }
}
