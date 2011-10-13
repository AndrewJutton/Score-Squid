using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ScoreSquid.Web.ViewModels;
using ScoreSquid.Web.Models;

namespace ScoreSquid.Web.Mappers
{
    public class DomainToViewModelProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelProfile";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Fixture, FixtureViewModel>();
        }
    }
}