﻿using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moz.Admin.Layui.Common;
using Moz.Administration.Models.Members;
using Moz.Auth;
using Moz.Core.Options;
using Moz.Exceptions;

namespace Moz.Admin.Layui.Controllers
{
    public class HomeController : AdminBaseController
    {
        private readonly IAuthService _authenticationService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthService _passportService;
        private readonly IOptions<MozOptions> _mozOptions;

        public HomeController(IAuthService passportService,
            IAuthService authenticationService,
            IHttpContextAccessor httpContextAccessor,
            IOptions<MozOptions> mozOptions)
        {
            _authenticationService = authenticationService;
            _passportService = passportService;
            _httpContextAccessor = httpContextAccessor;
            _mozOptions = mozOptions;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var path = string.IsNullOrEmpty(_mozOptions.Value.Admin.LoginView) 
                ? "~/Administration/Views/Home/Index.cshtml"
                : _mozOptions.Value.Admin.LoginView;           
            return View(path);
        }
        
        
        [HttpPost]
        public IActionResult Index(LoginModel model)
        {
            var resp = _passportService.LoginWithUsernamePassword(new MemberLoginRequest()
            {
                Username = model.Username,
                Password = model.Password
            });
            if(resp.IsError)
                throw new MozException(resp.Errors.FirstOrDefault());
            _passportService.SetAuthCookie(resp.AccessToken);
            return RespJson(new{});
        }
        

        [HttpGet]
        public IActionResult Logout()
        {
            _passportService.RemoveAuthCookie();
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult Error()
        {
            return View("~/Administration/Views/Home/Error.cshtml");
        }
    }
}