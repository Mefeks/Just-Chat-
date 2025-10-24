using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace JustChatWeb.Models
{
    public class TimeSlot
    {
        public int Id { get; set; }
        public string VolunteerName { get; set; }
        public string VolunteerPhone { get; set; }
        public DateTime SlotDateTime { get; set; }
        public bool IsBooked { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Новые поля
        public string Category { get; set; }
        public string Description { get; set; }
        public double? Rating { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
