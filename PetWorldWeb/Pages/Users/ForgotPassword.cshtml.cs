using DataAccess.Model;
using DataAccess.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace PetWorldWeb.Pages.Users
{
    public class ForgotPasswordModel : BaseViewModel
    {
        //private readonly UserManager<AppUser> _userManager;
        private IUserRepository _userRepository;
        private readonly prn221_petworldContext _context;

        public ForgotPasswordModel(prn221_petworldContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }
        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Enter your email exactly:")]
            public string Email { get; set; }
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            // Tìm user theo email gửi đến
            var user = _userRepository.GetUserByEmail(Input.Email);
            if (user == null)
            {
                return RedirectToPage("/Users/ForgotPasswordConfirmation");
            }
            var callbackUrl = Url.Page(
                "/Users/ResetPassword",
                pageHandler: null,
                values: new { area = "Identity" },
                protocol: Request.Scheme);

            // Gửi email
            _userRepository.SendMail
            (
                Input.Email,
                "Reset password",
                $"To reset password, <a href='{callbackUrl}'>click here</a>.");

            // Chuyển đến trang thông báo đã gửi mail để reset password
            return RedirectToPage("/Users/ForgotPasswordConfirmation");
        }
    }
}

