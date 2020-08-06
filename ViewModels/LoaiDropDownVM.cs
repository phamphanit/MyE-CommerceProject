using System;
using System.Collections.Generic;
using FinalProject.DataModels;

namespace FinalProject.ViewModels
{
    public class LoaiDropDownVM
    {
        public int? Selected { get; set; }
        public List<Loai> Data { get; set; }
    }
}
