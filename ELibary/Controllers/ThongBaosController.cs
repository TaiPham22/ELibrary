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
    public class ThongBaoController : ControllerBase
    {
        private readonly ELibaryContext _context;

        public ThongBaoController(ELibaryContext context)
        {
            _context = context;
        }

        // GET: api/ThongBao
        [HttpGet]
        public IActionResult GetThongBao(bool phanloai = true)
        {

            List<ThongBao> ThongBao = _context.ThongBao.Where(n => n.PhanLoai == phanloai).ToList();
            if (ThongBao == null)
            {
                return NotFound();
            }

            return Ok(ThongBao);

        }
        [Route("api/ThongBao/TimKiem")]
        [HttpGet]
        public IActionResult TimKiemThongBao(string tukhoa, bool phanloai = true)
        {

            var get = (from c in _context.ThongBao
                       where (c.NoiDung.Contains(tukhoa) || c.ChuDe.Contains(tukhoa)) && c.PhanLoai == phanloai
                       select new
                       {
                           c.MaNguoiDung,
                           c.NoiDung,
                           c.NgayThongBao

                       }).OrderBy(x => x.NgayThongBao);

            return Ok(get);
        }

        // POST= api/ThongBao
        [HttpPost]
        public IActionResult PostThongBao(ThongBao ThongBao, bool phanloai = true)
        {
            try
            {
                if (ThongBao != null)
                {
                    ThongBao.PhanLoai = phanloai;
                    ThongBao.NgayThongBao = DateTime.Now;
                    _context.ThongBao.Add(ThongBao);
                    _context.SaveChanges();
                    return Ok(ThongBao);
                }
                return BadRequest("Chưa nhập dữ liệu");
            }
            catch
            {
                return BadRequest("Lỗi");
            }
        }

        // DELETE: api/ThongBao/5
        [HttpDelete]

        public IActionResult DeleteThongBao(int id)
        {
            try
            {
                var delete = _context.ThongBao.SingleOrDefault(n => n.Id == id);
                if (delete != null)
                {
                    _context.ThongBao.Remove(delete);
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


        private bool ThongBaoExists(int id)
        {
            return _context.ThongBao.Count(e => e.Id == id) > 0;
        }
    }
}
