using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using ApplicationCore.Mapping;
using ApplicationCore.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Store.Pages.Accounts
{
    public class EditModel : PageModel
    {
        private readonly IAccountService _service;
        private readonly IMapper _mapper;

        public EditModel(IAccountService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        [BindProperty]
        public SaveAccountDto Account { get; set; }

        public IActionResult OnGet(int? id)
        {
            var t  = Request.Cookies["logon"];
            if( t == null ) return RedirectToPage("Login");
            if(t == "false") return RedirectToPage("Login");

            var permiss = Request.Cookies["permission"];
            if(permiss != null)
            {
                if(!string.IsNullOrEmpty(permiss))
                {
                    if(permiss != "0") return RedirectToPage("../Index");
                }
            }    
            if (id == null)
            {
                return NotFound();
            }

            var pAccount = _service.GetAccount(id ?? default(int));

            if (pAccount == null)
            {
                return NotFound();
            }

            Account = _mapper.Map<AccountDto, SaveAccountDto>(pAccount);

            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                _service.UpdateAccount(Account);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(Account.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("Index");
        }
        private bool AccountExists(int id)
        {
            return _service.GetAccount(id) != null;
        }

    }
}
