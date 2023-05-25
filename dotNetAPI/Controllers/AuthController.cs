﻿using dotNetAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;//hash password
using System.Security.Cryptography;
using dotNetAPI.Dtos;

namespace dotNetAPI.Controllers
{
    [ApiController]
    [Route("/api/auth")]
    public class AuthController : Controller
    {
        private readonly DotNetApiContext _context;
        public AuthController(DotNetApiContext context) {
            _context = context;
        }

        [HttpPost]
        [Route("/register")]
        public IActionResult Register(UserRegister user)
        {
            var hashed = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _context.Users.Add(new Entities.User { Email=user.Email,Name=user.Name,Password=hashed});
            _context.SaveChanges();
           
            return Ok(new UserData { Name=user.Name,Email=user.Email});
        }
        [HttpPost]
        [Route("/login")]
        public IActionResult Login()
        {
            return Ok();
        }
    }
}