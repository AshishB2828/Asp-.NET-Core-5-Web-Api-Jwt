﻿using AutoMapper;
using ListingApi.Data;
using ListingApi.Data.Dto;
using ListingApi.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<ApiUser> _userManager;
        //private readonly SignInManager<ApiUser> _signInManager;

        public AccountController(IUnitOfWork unitOfWork, IMapper mapper,
                                UserManager<ApiUser> userManager
                               )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //_signInManager = signInManager;
            _userManager = userManager;
        }

        //Registration
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid) return BadRequest( ModelState);
            try
            {
                var user = _mapper.Map<ApiUser>(userDto);
                user.UserName = user.Email;
                var result = await _userManager.CreateAsync(user, userDto.password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);

                }
                await _userManager.AddToRolesAsync(user, userDto.Roles);
                return Ok("Registration Success");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error. Please Try Again Later. => Register");
            }
        }


        //Login
        //[HttpPost]
        //[Route("login")]
        //public async Task<IActionResult> Login([FromBody] LoginUserDto loginUserDto)
        //{
        //    if (!ModelState.IsValid) return BadRequest(ModelState);
        //    try
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(loginUserDto.Email, loginUserDto.password, false, false);
        //        if (!result.Succeeded)
        //        {
        //            return BadRequest("Wrong Password or Email !");
        //        }
        //        return Ok("Login Success");
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "Internal Server Error. Please Try Again Later. =>LOGIN");
        //    }
        //}



    }
}
