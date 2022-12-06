using AutoMapper;
using ChatApp.Application.ViewModels.Member;
using ChatApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Mappers
{
    public class MemberProfile:Profile
    {
        public MemberProfile()
        {
            //register
            CreateMap<Member, RegisterMemberVM>();
            CreateMap<RegisterMemberVM,Member>();
            //login
            CreateMap<Member, LoginMemberVM>();
            CreateMap<LoginMemberVM, Member>();
        }
    }
}
