using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinalProject.Common;

namespace FinalProject.DataModels
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(10)]
        public string MaHH { get; set; }
        [MaxLength(100)]
        [Required]
        public String TenHH { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        [MaxLength(200)]
        public string MoTa { get; set; }
        public string Hinh { get; set; }
        public string ChiTiet { get; set; }
        [Range(0,100)]
        public byte GiamGia { get; set; }

        public int? MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public Loai Loai { get; set; }
        
    }
    public class HinhSanPham
    {
        [Key]
        public Guid Id { get; set; }
        public String Url { get; set; }
        public LoaiHinh LoaiHinh { get; set; }
        public Guid MaLoai { get; set; }
    }
    
}
