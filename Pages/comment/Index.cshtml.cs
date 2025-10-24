using JustChatWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JustChatWeb.Pages.comment
{
    public class IndexModel : PageModel
    {
        public TimeSlot TimeSlot { get; set; }
        public Review Review { get; set; }
        public void OnGet()
        {
        }
    }
}
