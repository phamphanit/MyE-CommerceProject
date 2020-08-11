﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinalProject.Common;

namespace FinalProject.DataModels
{
    [Table("DonHang")]
    public class DonHang
    {
        [Key]
        public long MaHoaDon { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime? NgayGiao { get; set; }
        public OrderStatus TrangThaiDatHang { get; set; }
        public PaymentMethod PhuongThucThanhToan { get; set; }
        public string MaKH { get; set; }
        [ForeignKey("MaKH")]
        public Customer Customer { get; set; }

        public ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public DonHang()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }

    }
}