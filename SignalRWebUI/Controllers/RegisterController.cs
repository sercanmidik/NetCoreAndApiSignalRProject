﻿using EntityLayer.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalRWebUI.Dtos.IdentityDtos;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Index(RegisterDto registerDto)
        {
            var appuser = new AppUser()
            {
                Name = registerDto.Name,
                SurName = registerDto.SurName,
                Email=registerDto.Mail,
                UserName= registerDto.UserName,
            };
            var result=await _userManager.CreateAsync(appuser,registerDto.Password);
            if(result.Succeeded)
            {
                return RedirectToAction("Index","Login");
            }
            return View();
        }
    }
}
