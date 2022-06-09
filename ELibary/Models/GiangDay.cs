
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELibary.Models
{
    [Table("GiangDay")]
    public partial class Giangday
    {
        public int Id { get; set; }
        [StringLength(128)]
        public int MaMon { get; set; }

        [StringLength(128)]
       
        public int MaGV { get; set; }

        [StringLength(128)]
      
        public int MaLop { get; set; }

        [ForeignKey("MaMon")]
        public virtual MonHoc Mon { get; set; }
        [ForeignKey("MaGV")]
        public virtual NguoiDung GiangVien { get; set; }
        [ForeignKey("MaLop")]
        public virtual LopHoc LopHoc { get; set; }
    }
}
