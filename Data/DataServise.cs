using JustChatWeb.Models;
using System.Text.Json;
namespace JustChatWeb.Data
{
    public class DataService
    {
        private readonly string _dataFile = "App_Data/timeslots.json";
        private List<TimeSlot> _timeSlots;

        public DataService()
        {
            LoadData();
        }

        public List<TimeSlot> GetAvailableSlots()
        {
            return _timeSlots.FindAll(s => !s.IsBooked);
        }

        public List<TimeSlot> GetAllSlots()
        {
            return _timeSlots;
        }

        public void AddTimeSlot(TimeSlot slot)
        {
            slot.Id = _timeSlots.Count > 0 ? _timeSlots.Max(s => s.Id) + 1 : 1;
            _timeSlots.Add(slot);
            SaveData();
        }

        public bool BookTimeSlot(int id, string userName, string userPhone)
        {
            var slot = _timeSlots.FirstOrDefault(s => s.Id == id);
            if (slot != null && !slot.IsBooked)
            {
                slot.IsBooked = true;
                slot.UserName = userName;
                slot.UserPhone = userPhone;
                SaveData();
                return true;
            }
            return false;
        }

        private void LoadData()
        {
            var directory = Path.GetDirectoryName(_dataFile);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            if (!File.Exists(_dataFile))
            {
                _timeSlots = new List<TimeSlot>();
                return;
            }

            var json = File.ReadAllText(_dataFile);
            _timeSlots = JsonSerializer.Deserialize<List<TimeSlot>>(json) ?? new List<TimeSlot>();
        }

        private void SaveData()
        {
            var json = JsonSerializer.Serialize(_timeSlots, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_dataFile, json);
        }

        public void AddReview(Review review)
        {
            var slot = _timeSlots.FirstOrDefault(s => s.Id == review.TimeSlotId);
            if (slot != null)
            {
                review.Id = slot.Reviews.Count > 0 ? slot.Reviews.Max(r => r.Id) + 1 : 1;
                slot.Reviews.Add(review);

                // Пересчет рейтинга
                if (slot.Reviews.Any())
                {
                    slot.Rating = slot.Reviews.Average(r => r.Rating);
                }

                SaveData();
            }
        }
        public TimeSlot GetTimeSlot(int id)
        {
            return _timeSlots.FirstOrDefault(s => s.Id == id);
        }
        public List<string> GetCategories()
        {
            return new List<string>
    {
        "💬 Просто общение",
        "💭 Психологическая поддержка",
        "🛠️ Техническая помощь",
        "🎓 Образование и консультация",
        "🎨 Творчество и хобби",
        "🏥 Поддержка здоровья"
    };
        }
    }
}
