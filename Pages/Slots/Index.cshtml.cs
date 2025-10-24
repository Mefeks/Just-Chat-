using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using JustChatWeb.Models;
using JustChatWeb.Data;

namespace JustChatWeb.Pages.Slots
{
    public class IndexModel : PageModel
    {
        private readonly DataService _dataService;

        public IndexModel(DataService dataService)
        {
            _dataService = dataService;
        }

        public List<TimeSlot> AvailableSlots { get; set; }

        public void OnGet()
        {
            AvailableSlots = _dataService.GetAvailableSlots();
        }

        public IActionResult OnPost(int slotId, string userName, string userPhone)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(userPhone))
            {
                TempData["Error"] = "Заполните все поля";
                return RedirectToPage();
            }

            var success = _dataService.BookTimeSlot(slotId, userName, userPhone);
            if (success)
            {
                TempData["Message"] = "Вы успешно записались! Волонтер свяжется с вами.";
            }
            else
            {
                TempData["Error"] = "Не удалось записаться. Возможно, время уже занято.";
            }

            return RedirectToPage();
        }
    }
}