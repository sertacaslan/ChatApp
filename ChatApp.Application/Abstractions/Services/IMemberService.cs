using ChatApp.Application.ViewModels.Member;
using ChatApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Abstractions.Services
{
    public interface IMemberService
    {
        Task<Member> LoginAsync(LoginMemberVM member);
        Task<bool> RegisterAsync(RegisterMemberVM member);
    }
}
