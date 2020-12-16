using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Store.Interfaces;
using Store.ViewModels;
using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Mapping;
using ApplicationCore.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Store.Pages.Accounts
{
    public class LoginModel : PageModel
    {
        private readonly IAccountService _service;
        public LoginModel(IAccountService service)
        {
            _service = service;
        }

        [BindProperty]
        public string username{get;set;}

        [BindProperty]
        public string password{get;set;}

        public IActionResult OnGet()
        {
            var t  = Request.Cookies["logon"];
            if( t != null )
            {
                if(t == "true") return RedirectToPage("../Index");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            var t = _service.GetByUserName(username);
            if(password == t.password)
            {
                    Response.Cookies.Append("logon", "true");
                    Response.Cookies.Append("permission", t.permission.ToString());
                    return RedirectToPage("../Index");
            }
            else return Page();
           
        }
    }
}