// ReSharper disable VirtualMemberCallInConstructor
namespace DreamHouse4You.Data.Models
{
    using System;
    using System.Collections.Generic;

    using DreamHouse4You.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            /*this.Houses = new HashSet<House>();
            this.Categories = new HashSet<Category>();
            this.Events = new HashSet<Event>();
            this.Notifications = new HashSet<Notification>();*/

        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

       /* public virtual ICollection<House> Houses { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Event> Events { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }*/
    }
}
