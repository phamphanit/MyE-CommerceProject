using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FinalProject.DataModels;
using FinalProject.Helpers;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;


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
        public CartInfo CartInf => new CartInfo
        {
            SoLuong = CartItems.Count,
            TongTien = CartItems.Sum(p => p.ThanhTien)
        };
        

        public IActionResult Index()
        {
            return View(CartItems);
        }

        public IActionResult AddtoCart(Guid id, int soLuong = 1)

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
        public IActionResult RemoveCartItem(Guid id)
        {
            var myCart = CartItems;
            var cartItem = myCart.SingleOrDefault(p => p.Id == id);
            if(cartItem != null)
            {
                myCart.Remove(cartItem);
            }
            HttpContext.Session.Set("GioHang", myCart);
            return RedirectToAction("Index");
        }
    }
}