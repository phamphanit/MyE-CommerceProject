using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.DataModels
{
    [Table("Loai")]
    public class Loai
    {
        [Key]
        public int MaLoai { get; set; }

        [MaxLength(100)]
        [Required]
        public string TenLoai { get; set; }
        public int? MaLoaiCha { get; set; }
        [ForeignKey("MaLoaiCha")]
        public Loai LoaiCha { get; set; }
    }
}
