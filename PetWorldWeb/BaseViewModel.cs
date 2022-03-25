using DataAccess.Model;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetWorldWeb
{
    public class BaseViewModel: PageModel
    {
        public string CartItemCount { get; set; } = "5";
        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            CartItemCount = Request.Cookies["CartItemCount"] != null ? Request.Cookies["CartItemCount"] : "0";
            base.OnPageHandlerExecuting(context);
        }
    }
}
