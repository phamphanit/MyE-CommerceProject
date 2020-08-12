using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FinalProject.DataModels;
using FinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public class HangHoaController : Controller
    {
        // GET
        private readonly MyDbContext _context;
        private readonly IMapper _mapper;

        public HangHoaController(MyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public IActionResult Index(int? MaLoai)
        {
            var dataHangHoa = _context.hangHoas.AsQueryable();
            if (MaLoai.HasValue)
            {
                dataHangHoa = dataHangHoa.Where(hh => hh.MaLoai == MaLoai.Value || hh.Loai.MaLoaiCha == MaLoai.Value).AsQueryable();
                
            }

            var result = _mapper.Map<List<HangHoaViewModel>>(dataHangHoa.ToList());
            
            
            return View(result);
        }

        public IActionResult Detail(string id)
        {
            var hangHoaGuid = Guid.Parse(id);
            var hangHoa = _context.hangHoas
                .Include(p => p.Loai)
                .SingleOrDefault(hh => hh.Id == hangHoaGuid);
            return View(hangHoa);
        }
    }
}