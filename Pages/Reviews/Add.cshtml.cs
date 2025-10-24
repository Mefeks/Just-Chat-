using JustChatWeb.Data;
using JustChatWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JustChatWeb.Pages.Reviews
{
    public class AddModel : PageModel
    {
        private readonly DataService _dataService;

        public AddModel(DataService dataService)
        {
            _dataService = dataService;
        }

        [BindProperty]
        public Review Review { get; set; }

        public TimeSlot TimeSlot { get; set; }

        public void OnGet(int slotId)
        {
            Review = new Review { TimeSlotId = slotId };

            // Получаем информацию о слоте для отображения
            var allSlots = _dataService.GetAllSlots();
            TimeSlot = allSlots.FirstOrDefault(s => s.Id == slotId);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _dataService.AddReview(Review);
            TempData["Message"] = "Спасибо за ваш отзыв!";
            return RedirectToPage("/Slots/Index");
        }
    }
}
