//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ELibary.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ThongBao
    {
        public int Id { get; set; }
        public bool PhanLoai { get; set; }
        public string ChuDe { get; set; }
        public string NoiDung { get; set; }
        public string MaNguoiDung { get; set; }
        public Nullable<System.DateTime> NgayThongBao { get; set; }
        public string TrangThai { get; set; }
    }
}
