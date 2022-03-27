using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Model;
using DataAccess.Repository;

namespace PetWorldWeb.Pages.Users
{
    public class EditModel : BaseViewModel
    {
        private IUserRepository _userRepository;
        private readonly DataAccess.Model.prn221_petworldContext _context;

        public EditModel(DataAccess.Model.prn221_petworldContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }
        public string Msg { get; set; }
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            User = _context.Users.FirstOrDefault(c => c.UserId == id);
            return Page();
        }
        [BindProperty]
        public User User { get; set; }
        public IActionResult OnPost()
        {
            _context.Attach(User).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToPage("/Index");
        }
    }
}
