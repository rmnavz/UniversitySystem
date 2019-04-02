﻿using MediatR;
using Navz.UniversitySystem.Application.Infrastructure;
using Navz.UniversitySystem.Application.Interfaces;
using Navz.UniversitySystem.Application.Notifications.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Navz.UniversitySystem.Application.Administrators.Commands.CreateAdministrator
{
    public class AdministratorCreated : INotification
    {
        public int AdministratorID { get; set; }

        public class Handler : INotificationHandler<AdministratorCreated>
        {
            private readonly INotificationService _notification;

            public Handler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(AdministratorCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new Message());
                await _notification.SendAsync(new Alert {
                    To = new List<string>()
                    {
                        RequestCaller.ID.ToString()
                    },
                    Title = "Alert Message",
                    Message = "Account successfully created!"
                });

                await _notification.SendAsync(new Data
                {
                    Name = "Administrator"
                });
            }
        }
    }
}
