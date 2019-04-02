using MediatR;
using Navz.UniversitySystem.Application.Infrastructure;
using Navz.UniversitySystem.Application.Interfaces;
using Navz.UniversitySystem.Application.Notifications.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Navz.UniversitySystem.Application.Subjects.Commands.CreateSubject
{
    public class SubjectCreated : INotification
    {
        public int SubjectID { get; set; }

        public class DepartmentCreatedHandler : INotificationHandler<SubjectCreated>
        {
            private readonly INotificationService _notification;

            public DepartmentCreatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(SubjectCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new Message());
                await _notification.SendAsync(new Alert
                {
                    To = new List<string>()
                    {
                        RequestCaller.ID.ToString()
                    },
                    Title = "Alert Message",
                    Message = "Department successfully created!"
                });
            }
        }
    }
}
