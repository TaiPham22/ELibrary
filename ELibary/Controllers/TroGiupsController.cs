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
    public class TroGiupController : ControllerBase
    {
        private readonly ELibaryContext _context;

        public TroGiupController(ELibaryContext context)
        {
            _context = context;
        }

        // GET: api/TroGiup
        [HttpGet]
        public IActionResult GetTroGiup(int id = -1)
        {
            if (id > 0)
            {
                TroGiup TroGiup = _context.TroGiup.Find(id);
                if (TroGiup == null)
                {
                    return NotFound();
                }

                return Ok(TroGiup);
            }
            else
            {
                return Ok(_context.TroGiup);
            }
        }

        // POST= api/TroGiup
        [HttpPost]
        public IActionResult PostTroGiup(TroGiup TroGiup)
        {
            try
            {
                if (TroGiup != null)
                {
                    _context.TroGiup.Add(TroGiup);
                    _context.SaveChanges();
                    return Ok(TroGiup);
                }
                return BadRequest("Chưa nhập dữ liệu");
            }
            catch
            {
                return BadRequest("Lỗi");
            }
        }

        // DELETE: api/TroGiup/5
        [HttpDelete]
        public IActionResult DeleteTroGiup(int id)
        {
            try
            {
                var delete = _context.TroGiup.SingleOrDefault(n => n.Id == id);
                if (delete != null)
                {
                    _context.TroGiup.Remove(delete);
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

        private bool TroGiupExists(int id)
        {
            return _context.TroGiup.Count(e => e.Id == id) > 0;
        }
    }
}
