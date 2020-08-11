using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FinalProject.DataModels;
using FinalProject.Helpers;
using FinalProject.Models;
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
        public IActionResult Test()
        {
            var a = _context.hangHoas.Include(hh => hh.Loai).ToList();
            var b = _context.hangHoas.Include("Loai").ToList();
            var c = _context.hangHoas.SingleOrDefault(hh => hh.MaLoai == 1);
            var d = _context.loais.ToList();



            return Json(d);
        }
    }
}