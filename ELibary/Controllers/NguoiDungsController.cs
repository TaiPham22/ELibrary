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
    public class NguoiDungController : ControllerBase
    {
        private readonly ELibaryContext _context;

        public NguoiDungController(ELibaryContext context)
        {
            _context = context;
        }

        // GET: api/NguoiDung
        [HttpGet]
        public IActionResult GetNguoiDung(string tukhoa = null)
        {
            if (tukhoa == null)
            {
                var get = (from s in _context.Role
                           join c in _context.NguoiDung on s.Id equals c.VaiTro
                           select new
                           {
                               c.MaNguoiDung,
                               c.TenNguoiDung,
                               c.Email,
                               s.TenVaiTro
                           }).OrderBy(x => x.MaNguoiDung);
                return Ok(get);
            }
            else if (char.IsNumber(tukhoa[0]))
            {
                return LocNguoiDung(Convert.ToInt32(tukhoa));
            }
            else
            {
                return TimKiemNguoiDung(tukhoa);
            }
        }

        private IActionResult TimKiemNguoiDung(string tukhoa)
        {

            var get = (from s in _context.Role
                       join c in _context.NguoiDung on s.Id equals c.VaiTro
                       where c.TenNguoiDung.Contains(tukhoa)
                       select new
                       {
                           c.MaNguoiDung,
                           c.TenNguoiDung,
                           c.Email,
                           s.TenVaiTro
                       }).OrderBy(x => x.MaNguoiDung);

            return Ok(get);
        }

        private IActionResult LocNguoiDung(int tukhoa)
        {

            var get = (from s in _context.Role
                       join c in _context.NguoiDung on s.Id equals c.VaiTro
                       where c.VaiTro == tukhoa
                       select new
                       {
                           c.MaNguoiDung,
                           c.TenNguoiDung,
                           c.Email,
                           s.TenVaiTro
                       }).OrderBy(x => x.MaNguoiDung);

            return Ok(get);
        }

        // PUT: api/NguoiDung/5            Chỉnh sửa thông tin người dùng
        [HttpPut]
        public IActionResult PutNguoiDung(string ma, NguoiDung nguoidung)
        {
            try
            {
                var put = _context.NguoiDung.SingleOrDefault(n => n.MaNguoiDung == ma);
                if (put != null)
                {
                    put.TenNguoiDung = nguoidung.TenNguoiDung;
                    put.Email = nguoidung.Email;
                    put.SDT = nguoidung.SDT;
                    put.VaiTro = nguoidung.VaiTro;

                    _context.SaveChanges();
                    return Ok(String.Format("TenNguoiDung: {0}, " +
                        "Email: {1}," +
                        "SDT: {2} " +
                        "VaiTro: {3}", put.TenNguoiDung, put.Email, put.SDT, put.VaiTro));
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(ModelState);
            }
        }

        // POST: api/NguoiDung              Thêm người dùng vào hệ thống
        [HttpPost]

        public IActionResult PostNguoiDung(NguoiDung nguoidung)
        {
            try
            {
                if (nguoidung != null)
                {
                    _context.NguoiDung.Add(nguoidung);
                    _context.SaveChanges();
                    return Ok(nguoidung);
                }
                return BadRequest("Chưa nhập dữ liệu");
            }
            catch
            {
                return BadRequest("Lỗi");
            }
        }

        // DELETE: api/NguoiDung/5          Xóa người dùng
        [HttpDelete]
        public IActionResult DeleteNguoiDung(string ma)
        {
            try
            {
                var delete = _context.NguoiDung.SingleOrDefault(n => n.MaNguoiDung == ma);
                if (delete != null)
                {
                    _context.NguoiDung.Remove(delete);
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

        private bool NguoidungExists(string ma)
        {
            return _context.NguoiDung.Count(e => e.MaNguoiDung == ma) > 0;
        }
    }
}
