using AutoMapper;
using DAL.DTO;
using Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Profilies
{
    public class CostumerProfile: Profile
    {
        public CostumerProfile()
        {
            CreateMap<Costumer, CostumerDto>();
            CreateMap<CostumerDto, Costumer>();
        }
    }
}
