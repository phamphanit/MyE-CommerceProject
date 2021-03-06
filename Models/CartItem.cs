using System;

namespace FinalProject.Models
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public string TenHH { get; set; }
        public string Hinh { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public double ThanhTien => SoLuong * DonGia;
    }

    public class CartInfo
    {
        public int SoLuong { get; set; }
        public double TongTien { get; set; }
    }
}