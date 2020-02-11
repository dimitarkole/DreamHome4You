using System;
using System.Collections.Generic;
using System.Text;

namespace DreamHouse4You.Web.ViewModels.CommonResorces
{
    public class NotificationsNavBarViewModel
    {
        public NotificationsNavBarViewModel(List<NotificationNavBarViewModel> notifications)
        {
            this.Notifications = notifications;
            this.CountNotifications = notifications.Count;
        }

        public int CountNotifications { get; set; }

        public List<NotificationNavBarViewModel> Notifications { get; set; }
    }
}
