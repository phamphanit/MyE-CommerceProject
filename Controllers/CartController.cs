using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FinalProject.Common;
using FinalProject.DataModels;
using FinalProject.Helpers;
using FinalProject.Models;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public class CartController : Controller
    {
        // GET
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public CartController(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<CartItem> CartItems
        {
            get
            {
                var myCart = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if (myCart == null)
                {
                    myCart = new List<CartItem>();
                }

                return myCart;
            }
        }

        public IActionResult Index()
        {
            return View(CartItems);
        }

        public IActionResult AddtoCart(Guid id, int soLuong = 1, bool isAjaxCall = false)

        {
            var myCart = CartItems;
            var cartItem = myCart.SingleOrDefault(p => p.Id == id);
            if (cartItem != null)
            {
                cartItem.SoLuong += soLuong;
            }
            else
            {
                var hangHoa = _context.hangHoas.SingleOrDefault(p => p.Id == id);
                cartItem = _mapper.Map<CartItem>(hangHoa);
                cartItem.SoLuong = soLuong;
                myCart.Add(cartItem);

            }
            HttpContext.Session.Set("GioHang", myCart);

            return RedirectToAction("Index");
        }
        public CartInfo CartInfo => new CartInfo
        {
            SoLuong = CartItems.Count,
            TongTien = CartItems.Sum(p => p.ThanhTien)
        };
        public IActionResult RemoveCartItem(Guid id, bool isAjaxCall = false)
        {
            var myCart = CartItems;
            var cartItem = myCart.SingleOrDefault(p => p.Id == id);
            if (cartItem != null)
            {
                myCart.Remove(cartItem);
            }
            HttpContext.Session.Set("GioHang", myCart);
            if (isAjaxCall)
            {
                return Json(CartInfo);
            }
            return RedirectToAction("Index");
        }
        //example TestLinQ
        public IActionResult TestLinq()
        {
            var a = _context.hangHoas.Include(hh => hh.Loai).ToList();
            var b = _context.hangHoas.Include("Loai").ToList();
            var c = _context.hangHoas.SingleOrDefault(hh => hh.MaLoai == 1);
            var d = _context.loais.ToList();



            return Json(d);
        }
        public IActionResult ProcessCheckout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ProcessCheckout(RegisterViewModel model)
        {
            try
            {
                _context.Database.BeginTransaction();
                var customer = new Customer();
                if (User.Identity.IsAuthenticated)
                {
                    var _IdCust = User.Claims.FirstOrDefault(p => p.Type == MyClaimType.CustomerID);
                    customer.IdCust = _IdCust.Value;
                }
                else
                {
                    customer = new Customer
                    {
                        IdCust = Guid.NewGuid().ToString(),
                        NameCust = model.CustName,
                        Phone = model.Phone,
                        Email = model.Email,
                    };

                    _context.Add(customer);
                    _context.SaveChanges();
                }
                var Order = new DonHang
                {
                    MaKH = customer.IdCust,
                    NgayDat = DateTime.Now,
                    TrangThaiDatHang = OrderStatus.Open,
                    PhuongThucThanhToan = PaymentMethod.COD,
                };
                _context.Add(Order);
                _context.SaveChanges();

                foreach (var item in CartItems)
                {
                    var OrderDetail = new ChiTietDonHang
                    {
                        MaDonHang = Order.MaHoaDon,
                        MaHangHoa = item.Id,
                        SoLuong = item.SoLuong,
                        DonGia = item.DonGia,


                    };
                    _context.Add(OrderDetail);
                }
                _context.SaveChanges();
                HttpContext.Session.Remove("GioHang");
                _context.Database.CommitTransaction();

            }
            catch (Exception exp)
            {
                _context.Database.RollbackTransaction();
            }
            return View();
        }
        public IActionResult Test()
        {
            return View();
        }
    }
}