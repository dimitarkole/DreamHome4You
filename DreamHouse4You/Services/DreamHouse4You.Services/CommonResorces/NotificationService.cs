namespace DreamHouse4You.Services.CommonResorces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using DreamHouse4You.Data;
    using DreamHouse4You.Data.Models;
    using DreamHouse4You.Services.Contracts.CommonResorces;
    using DreamHouse4You.Web.ViewModels.CommonResorces;

    public class NotificationService : INotificationServices
    {
        private readonly ApplicationDbContext context;

        public NotificationService(
            ApplicationDbContext context)
        {
            this.context = context;
        }

        public string AddNotification(string notificationNotifications, string userId)
        {
            var user = this.context.Users.FirstOrDefault(u => u.Id == userId);
            Notification notification = new Notification()
            {
                Text = notificationNotifications,
                UserId = userId,
                User = user,
            };
            return "Successful added notification!";
        }

        public NotificationsNavBarViewModel GetNotificationssNavBar(string userId)
        {
            var messages = this.context.Notifications
                .Where(m =>
                    m.DeletedOn == null
                    && m.UserId == userId
                    && m.SeenOn == null)
                .Select(m => new NotificationNavBarViewModel()
                {
                    CreatedOn = m.CreatedOn,
                    Id = m.Id,
                    TextOfNotification = m.Text,
                    SeenOn = m.SeenOn,
                })
                .ToList();

            var result = new NotificationsNavBarViewModel(messages);

            return result;
        }

        public NotificationsViewModel GetNotificationssChangePage(NotificationsViewModel model, string userId)
        {
            var messages = this.context.Notifications
               .Where(m =>
                   m.DeletedOn == null
                   && m.UserId == userId)
               .OrderByDescending(m => m.CreatedOn)
               .Select(m => new NotificationViewModel()
               {
                   CreatedOn = m.CreatedOn,
                   TextOfNotification = m.Text,
                   SeenOn = m.SeenOn,
               })
               .ToList();
            int countBooksOfPage = model.CountNotificationsOfPage;
            int currentPage = model.CurrentPage;

            int maxCountPage = messages.Count() / countBooksOfPage;
            if (messages.Count() % countBooksOfPage != 0)
            {
                maxCountPage++;
            }

            var viewBook = messages.Skip((currentPage - 1) * countBooksOfPage)
                                .Take(countBooksOfPage);

            var result = new NotificationsViewModel()
            {
                Notificaitons = messages,
                CountNotificationsOfPage = countBooksOfPage,
                MaxCountPage = maxCountPage,
            };

            return result;
        }

        public NotificationsViewModel GetNotificationssPreparedPage(string userId)
        {
            var model = new NotificationsViewModel();
            var returnModel = this.GetNotificationssChangePage(model, userId);
            return returnModel;
        }
    }
}
