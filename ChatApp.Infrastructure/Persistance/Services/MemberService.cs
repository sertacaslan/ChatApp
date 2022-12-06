using AutoMapper;
using ChatApp.Application.Abstractions.Services;
using ChatApp.Application.ViewModels.Member;
using ChatApp.Domain.Entities;
using ChatApp.Infrastructure.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;


namespace ChatApp.Infrastructure.Persistance.Services
{
    public class MemberService : IMemberService
    {
        private readonly ChatAppContext _context;
        private readonly IMapper _mapper;
        public MemberService(ChatAppContext chatAppContext, IMapper mapper)
        {
            _context = chatAppContext;
            _mapper = mapper;
        }
        public async Task<Member> LoginAsync(LoginMemberVM member)
        {
            Member user = _mapper.Map<Member>(member);

            Member? result;
            try
            {
                Member selected = new Member() { UserName = user.UserName, UserPass = user.UserPass };
                result = await _context.Members.FirstAsync(x => x.UserName == selected.UserName && x.UserPass == selected.UserPass);
            }
            catch
            {
                result = null;
            }
            return result;
        }

        public async Task<bool> RegisterAsync(RegisterMemberVM member)
        {
            member.RegisterDate = DateTime.Now;

            await _context.Members.AddAsync(_mapper.Map<Member>(member));
            int affectedRows = await _context.SaveChangesAsync();


            if (affectedRows == 0)
            {
                return false;
            }

            return true;
        }
    }
}
