using AutoMapper;
using FinalProject.Models;
using FinalProject.ViewModels;

namespace FinalProject.DataModels
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<HangHoa, HangHoaViewModel>().ReverseMap();
            CreateMap<HangHoa, CartItem>()
                .ForMember(p => p.DonGia, h => h.MapFrom(d => d.DonGia*(100-d.GiamGia)/100.0));
        }
    }
}