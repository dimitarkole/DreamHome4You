namespace DreamHouse4You.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DreamHouse4You.Data.Common.Models;

    public class Event : IAuditInfo, IDeletableEntity
    {
        public Event()
        {
            this.Id = Guid.NewGuid().ToString();
            this.IsDeleted = false;
            this.CreatedOn = DateTime.UtcNow;
        }

        public string Id { get; set; }

        public string Text { get; set; }

        public string Imgage { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime StartOn { get; set; }

        public DateTime FinishOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
