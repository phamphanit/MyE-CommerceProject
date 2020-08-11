﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProject.DataModels
{
    [Table("ChiTietDonHang")]
    public class ChiTietDonHang
    {
        [Key]
        public int MaCtDh { get; set; }
        public long MaDonHang { get; set; }
        public Guid MaHangHoa { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        [ForeignKey("MaDonHang")]
        public DonHang DonHang { get; set; }
        [ForeignKey("MaHangHoa")]
        public HangHoa HangHoa { get; set; }
    }
}