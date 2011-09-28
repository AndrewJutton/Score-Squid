using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

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
        }
    }
}