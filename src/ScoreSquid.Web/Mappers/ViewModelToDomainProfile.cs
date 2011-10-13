using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ScoreSquid.Web.ViewModels;
using ScoreSquid.Web.Models;

namespace ScoreSquid.Web.Mappers
{
    public class ViewModelToDomainProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainProfile";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<RegistrationViewModel, Player>();
        }
    }
}