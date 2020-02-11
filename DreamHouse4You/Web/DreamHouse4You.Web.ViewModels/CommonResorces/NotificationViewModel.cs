namespace DreamHouse4You.Web.ViewModels.CommonResorces
{
    using System;

    public class NotificationViewModel
    {
        public string TextOfNotification { get; set; }

        public virtual DateTime CreatedOn { get; set; }

        public virtual DateTime? SeenOn { get; set; }
    }
}