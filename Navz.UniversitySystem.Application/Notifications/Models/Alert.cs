using System.Collections.Generic;

namespace Navz.UniversitySystem.Application.Notifications.Models
{
    public class Alert
    {
        public string From { get; set; }
        public IEnumerable<string> To { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
