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
    public class TepRiengController : ControllerBase
    {
        private readonly ELibaryContext _context;

        public TepRiengController(ELibaryContext context)
        {
            _context = context;
        }

        // GET: api/TepRieng
        [HttpGet]
        public IActionResult GetTepRieng(string loaitep = null, string tentep = null)
        {
            if (loaitep == null && tentep == null)
            {
                return Ok(_context.TepRieng);
            }
            else if (loaitep != null)
            {
                return LocTepRieng(loaitep);
            }
            else
            {
                return TimKiemTepRieng(tentep);
            }
        }

        private IActionResult TimKiemTepRieng(string tukhoa)
        {

            var get = (from c in _context.TepRieng
                       where c.TenTep.Contains(tukhoa)
                       select new
                       {
                           c
                       });

            return Ok(get);
        }

        private IActionResult LocTepRieng(string tukhoa)
        {

            var get = (from c in _context.TepRieng
                       where c.TheLoai.Contains(tukhoa)
                       select new
                       {
                           c
                       });

            return Ok(get);

        }

        // PUT: api/TepRieng/5
        [HttpPut]
        public IActionResult PutTepRieng(int id, string teprieng)
        {
            try
            {
                var put = _context.TepRieng.SingleOrDefault(n => n.Id == id);
                if (put != null)
                {
                    put.TenTep = teprieng;

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

        // POST= api/TepRieng
        [HttpPost]
        public IActionResult PostTepRieng(TepRieng teprieng)
        {
            try
            {
                if (teprieng != null)
                {
                    _context.TepRieng.Add(teprieng);
                    _context.SaveChanges();
                    return Ok(teprieng);
                }
                return BadRequest("Chưa nhập dữ liệu");
            }
            catch
            {
                return BadRequest("Lỗi");
            }
        }

        // DELETE: api/TepRieng/5
        [HttpDelete]
        public IActionResult DeleteTepRieng(int id)
        {
            try
            {
                var delete = _context.TepRieng.SingleOrDefault(n => n.Id == id);
                if (delete != null)
                {
                    _context.TepRieng.Remove(delete);
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

        private bool TepRiengExists(int id)
        {
            return _context.TepRieng.Count(e => e.Id == id) > 0;
        }
    }
}
