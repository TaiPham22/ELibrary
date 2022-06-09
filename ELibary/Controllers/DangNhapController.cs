using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ELibary.Mail;
using ELibary.Session;
using ELibary.Data;
using ELibary.Models;
using System.Net.Mail;

namespace ELibary.Controllers
{
  
    public class DangNhapController : ControllerBase
    {
        private readonly ELibaryContext _context;
        private SmtpClient client = new SmtpClient("smtp.gmail.com");
        private string _from = "ptai22092001@gmail.com";
        private string _to = "ptai22092001@gmail.com";
        private string _subject = "Mã xác thực ";
        private string _body = "Mã xác thực của bạn là ";

        public DangNhapController(ELibaryContext context)
        {
            _context = context;
        }
        // GET: api/DangNhap/5
        [Route("api/DangNhap")]
        [HttpGet]
        public IActionResult GetTaiKhoan(string UserName, string password)
        {
            var taikhoan = _context.TaiKhoan.SingleOrDefault(n => n.UserName == UserName && n.PassWord == password);

            if (taikhoan == null)
            {
                return BadRequest("Nhập sai tài khoản hoặc mật khẩu");
            }

            var thongtin = from c in _context.TaiKhoan
                           join s in _context.NguoiDung on c.MaNguoiDung equals s.MaNguoiDung
                           join v in _context.Role on s.VaiTro equals v.Id
                           where c.UserName == taikhoan.UserName && taikhoan.PassWord == password
                           select new
                           {
                               TenNguoiDung = s.TenNguoiDung,
                               TenVaiTro = v.TenVaiTro
                           };

            return Ok(thongtin);
        }
        [Route("api/NhapXacNhan")]
        [HttpPost]
        public IActionResult PostXacNhan(string code)
        {
            string ss = UserLogin.code;
            if (string.IsNullOrEmpty(ss))
            {
                return BadRequest("Lỗi");
            }
            if (ss == code)
            {
                return Ok("Xác thực thành công quay lại trang đặt lại mật khẩu /api/DatMatKhau");
            }
            else
                return BadRequest("Mã xác thực không đúng");
        }
        [Route("api/DatMatKhau")]
        [HttpPut]
        public IActionResult PutMatKhau(string UserName, string pass)
        {
            var ss = _context.TaiKhoan.SingleOrDefault(n => n.UserName == UserName);
            if (ss == null)
            {
                return BadRequest("Lỗi không tìm thấy tài khoản");
            }
            ss.PassWord = pass;
            _context.SaveChanges();

            return Ok(string.Format("Cập nhật thành công \n {0}", ss));
        }



        [Route("api/KhoiPhucMatKhau")]
        [HttpPost]
        public async Task<string> GetKhoiPhucmatkhau(string UserName)
        {
            var taikhoan = _context.TaiKhoan.SingleOrDefault(n => n.UserName == UserName);
            if (taikhoan != null)
            {
                Random rd = new Random();
                string code = "";
                for (int i = 0; i < 6; i++)
                {
                    code += rd.Next(9);
                }
                _body += code;
                UserLogin.code = code;
                UserLogin.username = UserName;
            }
            else
                return "Không tìm thấy tài khoản";

            try
            {
                var message = await MailUtils.SendMail(_from, _to, _subject, _body);
                return message + " /api/NhapXacNhan";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
