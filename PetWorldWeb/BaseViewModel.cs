using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetWorldWeb
{
    public class BaseViewModel : PageModel
    {
        public string CartItemCount { get; set; } = "0";
        public string CurUser { get; set; }
        public string CurUserId { get; set; }
        public override void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            CurUser = Request.Cookies["Username"] != null ? Request.Cookies["Username"] : null;
            CartItemCount = Request.Cookies["CartItemCount"] != null ? Request.Cookies["CartItemCount"] : "0";

            CurUserId = Request.Cookies["UserId"] != null ? Request.Cookies["UserId"] : null;

            ViewData["CartItemCount"] = CartItemCount;
            base.OnPageHandlerSelected(context);
        }
        
        public bool IsLoggedIn()
        {
            if (CurUser == null || CurUser == "") return false;
            return true;
        }
    }
}

