using DataAccess.Model;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PetWorldWeb.Pages.Users
{
    public class ResetPasswordModel : BaseViewModel
    {
        private IUserRepository _userRepository;
        private readonly prn221_petworldContext _context;

        public ResetPasswordModel(prn221_petworldContext context, IUserRepository userRepository)
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
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "{0} dài {2} đến {1} ký tự.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Mật khẩu")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Nhập lại mật khẩu")]
            [Compare("Password", ErrorMessage = "Password phải giống nhau.")]
            public string ConfirmPassword { get; set; }

            /*public string Code { get; set; }*/

        }

        public void OnGet()
        {
            /*if (code == null)
            {
                return BadRequest("Mã token không có.");
            }
            else
            {
                Input = new InputModel
                {
                    // Giải mã lại code từ code trong url (do mã này khi gửi mail
                    // đã thực hiện Encode bằng WebEncoders.Base64UrlEncode)
                    Code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code))
                };
                return Page();
            }*/
        }

        public IActionResult OnPost()
        {

            // Tìm User theo email
            var user = _userRepository.GetUserByEmail(Input.Email);
            if (user == null)
            {
                // Không thấy user
                return RedirectToPage("/Users/ResetPasswordConfirmation");
            }
            else
            {
                user.Password = Input.Password;
                _context.Attach(user).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToPage("/Users/ResetPasswordConfirmation");
            }
        }
    }
}
