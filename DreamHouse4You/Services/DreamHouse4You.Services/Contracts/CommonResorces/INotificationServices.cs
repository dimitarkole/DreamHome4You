namespace DreamHouse4You.Services.Contracts.CommonResorces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface INotificationServices
    {
        public string AddNotification(string notificationMessage, string userId);

    }
}
