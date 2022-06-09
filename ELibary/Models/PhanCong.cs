namespace ELibary.Models
{
    using System;
    using System.Collections.Generic;

    public partial class PhanCong
    {
        public int Id { get; set; }
        public string Lop { get; set; }
        public string ChuDe { get; set; }
        public Nullable<int> BaiGiang { get; set; }

        public virtual BaiGiang_TaiNguyen BaiGiang_TaiNguyen { get; set; }
    }
}
