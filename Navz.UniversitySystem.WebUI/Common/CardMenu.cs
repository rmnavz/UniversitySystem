using Navz.UniversitySystem.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Navz.UniversitySystem.WebUI.Common
{
    public class CardMenu
    {
        public CardMenu(string Title, string Subtitle, string Controller, string Action, List<UserType> UserTypes)
        {
            this.Title = Title;
            this.Subtitle = Subtitle;
            this.Controller = Controller;
            this.Action = Action;
            this.UserTypes = UserTypes;
        }

        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public List<UserType> UserTypes { get; set; }
    }
}
