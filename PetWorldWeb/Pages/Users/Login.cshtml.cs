using DataAccess.Model;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace PetWorldWeb.Pages.Users
{
    public class LoginModel : BaseViewModel
    {
        IUserRepository userRepository;
        private readonly DataAccess.Model.prn221_petworldContext _context;

        public LoginModel(DataAccess.Model.prn221_petworldContext context, IUserRepository userRepository)
        {
            _context = context;
            this.userRepository = userRepository;
        }
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }
        public User CurrentUser { get; set; }
        public string Msg { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            CurrentUser = userRepository.GetUserByUsernameAndPassword(Username, Password);
            if (CurrentUser != null){
                Response.Cookies.Append("Username", CurrentUser.UserName);
                return RedirectToPage("Index");
            }
            else
            {
                Msg = "Invalid";
                return Page();
            }
        }
        public IActionResult OnGetLogout()
        {
            Response.Cookies.Delete("Username");
            return RedirectToPage("Index");
        }
    }
}
