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
    public class RoleController : ControllerBase
    {
        private readonly ELibaryContext _context;

        public RoleController(ELibaryContext context)
        {
            _context = context;
        }

        // GET: api/Role
        [HttpGet]
        public IActionResult GetRole(int ma = -1)
        {
            if (ma > 0)
            {
                var get = (from s in _context.Role
                           join c in _context.NguoiDung on s.Id equals c.VaiTro
                           where s.Id == ma
                           select new
                           {
                               s.TenVaiTro,
                               c.MaNguoiDung,
                               c.TenNguoiDung,
                               c.Email,
                               c.SDT,

                           }
                           ).OrderBy(x => x.TenVaiTro);
                if (get == null)
                {
                    return NotFound();
                }

                return Ok(get);
            }
            else
            {
                var get = (from s in _context.Role
                           select new
                           {
                               s.TenVaiTro,
                               s.MoTa,
                           }
                           );
                return Ok(get);
            }
        }

        // PUT: api/Role/5             Cập nhật vai trò người dùng
        [HttpPut]

        public IActionResult PutRole(int id, Role role)
        {
            try
            {
                var put = _context.Role.SingleOrDefault(n => n.Id == id);
                if (put != null)
                {
                    put.De = role.De;
                    put.MonHoc = role.MonHoc;
                    put.MoTa = role.MoTa;
                    put.NguoiDung = role.NguoiDung;
                    put.PhanQuyen = role.PhanQuyen;
                    put.TaiNguyen = role.TaiNguyen;
                    put.TenVaiTro = role.TenVaiTro;
                    put.TepRiengTu = role.TepRiengTu;
                    put.ThongBao = role.ThongBao;


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

        // POST: api/Role              Thêm vai trò người dùng
        [HttpPost]

        public IActionResult PostRole(Role role)
        {
            try
            {
                if (role != null)
                {
                    _context.Role.Add(role);
                    _context.SaveChanges();
                    return Ok(role);
                }
                return BadRequest("Chưa nhập dữ liệu");
            }
            catch
            {
                return BadRequest("Lỗi");
            }
        }

        // DELETE: api/Role/5          Xóa vai trò người dùng
        [HttpDelete]

        public IActionResult DeleteRole(int id)
        {
            try
            {
                var delete = _context.Role.SingleOrDefault(n => n.Id == id);
                if (delete != null)
                {
                    _context.Role.Remove(delete);
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


        private bool RoleExists(int id)
        {
            return _context.Role.Count(e => e.Id == id) > 0;
        }
    }
}
