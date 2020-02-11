namespace DreamHouse4You.Web.ViewModels.CommonResorces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class NotificationsViewModel
    {
        public NotificationsViewModel()
        {
            this.CountNotificaitonsOfPageList = new List<int>();

            this.CountNotificaitonsOfPageList.Add(10);
            this.CountNotificaitonsOfPageList.Add(20);
            this.CountNotificaitonsOfPageList.Add(30);

            this.CountNotificationsOfPage = this.CountNotificaitonsOfPageList[0];
            this.CurrentPage = 1;
        }

        public List<NotificationViewModel> Notificaitons { get; set; }

        public int CurrentPage { get; set; }

        public int MaxCountPage { get; set; }

        public int CountNotificationsOfPage { get; set; }

        public List<int> CountNotificaitonsOfPageList { get; set; }
    }
}
