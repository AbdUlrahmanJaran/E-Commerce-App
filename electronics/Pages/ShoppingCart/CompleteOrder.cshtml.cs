using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Text;

namespace Electronics.Pages.Shopping_Cart
{
    public class CompleteOrderModel : PageModel
    {
        public String Summary { get; set; }
        public void OnGet(String summary)
        {
            Summary = summary;
        }
    }
}
