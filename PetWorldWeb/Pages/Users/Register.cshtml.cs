using DataAccess.Model;
using DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace PetWorldWeb.Pages.Users
{
    public class RegisterModel : BaseViewModel
    {
        IUserRepository userRepository;

        private readonly DataAccess.Model.prn221_petworldContext _context;

        public RegisterModel(DataAccess.Model.prn221_petworldContext context, IUserRepository userRepository)
        {
            _context = context;
            this.userRepository = userRepository;
        }

        [BindProperty]
        public User Customer { get; set; }
        public string Msg { get; set; }
        [BindProperty]
        public string ConfirmPassword { get; set; }
        public void OnGet()
        {
        }


        public IActionResult OnPost()
        {
            User checkExist = userRepository.GetUserByUsername(Customer.UserName);
            if (checkExist != null)
            {
                Msg = "Username has existed. Please choose another one.";
                return Page();
            }
            if (ConfirmPassword != Customer.Password)
            {
                Msg = "Passwords are not matched. Please re-enter.";
                return Page();
            }
            _context.Users.Add(Customer);
            _context.SaveChanges();
            Response.Cookies.Append("Username", Customer.UserName);
            return RedirectToPage("/Index");
        }
    }
}
