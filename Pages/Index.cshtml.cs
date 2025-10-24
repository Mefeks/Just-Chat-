using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using JustChatWeb.Models;
using JustChatWeb.Data;

namespace JustChatWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DataService _dataService;

        public IndexModel(DataService dataService)
        {
            _dataService = dataService;
        }

        [BindProperty]
        public TimeSlot NewSlot { get; set; }
        public List<string> Categories { get; set; }
        public void OnGet()
        {
            Categories = _dataService.GetCategories();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Categories = _dataService.GetCategories();
                return Page();
            }

            _dataService.AddTimeSlot(NewSlot);
            TempData["Message"] = "Время успешно добавлено! Спасибо за вашу помощь!";
            return RedirectToPage("/Index");
        }
    }
}