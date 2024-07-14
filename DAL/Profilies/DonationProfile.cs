using AutoMapper;
using DAL.DTO;
using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.DTO;
using Project;
namespace DAL.Profilies
{
    public class DonationProfile : Profile
    {
        public DonationProfile()
        {
            CreateMap<Donation, DonationDto>();
            CreateMap<DonationDto, Donation>();
        }
    }
}
