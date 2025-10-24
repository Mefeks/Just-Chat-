namespace JustChatWeb.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int TimeSlotId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
