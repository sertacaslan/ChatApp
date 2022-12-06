using AutoMapper;
using ChatApp.Application.Abstractions.Services;
using ChatApp.Application.ViewModels.Member;
using ChatApp.Domain.Entities;
using ChatApp.Infrastructure.Persistance.Contexts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ChatApp.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly ChatAppContext _context;
        public HomeController(IMemberService memberService, ChatAppContext context)
        {
            _memberService = memberService;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Room");
            }


            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginMemberVM user)
        {
            if (HttpContext.User.Identity.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Room");
            }



            Member result = await _memberService.LoginAsync(user);

            if (result != null)
            {
                var claims = new List<Claim>() {
                new Claim(ClaimTypes.Name,result.UserName)//claimler bu listte
                };
                ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "ChatApp authentication system");
                ClaimsPrincipal userPrincipal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(userPrincipal);
                return RedirectToAction("Index", "Room");
            }
            else
            {
                TempData["LoginErr"] = "Err";
                return RedirectToAction("Index", "Room");
            }
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        public IActionResult Register()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Room");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterMemberVM registerMember)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Room");
            }

            if (!ModelState.IsValid)
            {
                TempData["err"] = "error";
                return View(registerMember);
            }
            bool result = await _memberService.RegisterAsync(registerMember);

            if (!result)
            {
                TempData["err"] = "error";
                return View(registerMember);
            }

            return RedirectToAction("Index");

        }
    }
}
