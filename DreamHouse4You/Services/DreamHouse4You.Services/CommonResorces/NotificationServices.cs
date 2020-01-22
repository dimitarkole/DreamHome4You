namespace DreamHouse4You.Services.CommonResorces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using DreamHouse4You.Data;
    using DreamHouse4You.Data.Models;
    using DreamHouse4You.Services.Contracts.CommonResorces;

    public class NotificationServices : INotificationServices
    {
        private readonly ApplicationDbContext context;

        public NotificationServices(
            ApplicationDbContext context)
        {
            this.context = context;
        }

        public string AddNotification(string notificationMessage, string userId)
        {
            var user = this.context.Users.FirstOrDefault(u => u.Id == userId);
            Notification notification = new Notification()
            {
                Text = notificationMessage,
                UserId = userId,
                User = user,
            };
            return "Successful added notification!";
        }
    }
}
