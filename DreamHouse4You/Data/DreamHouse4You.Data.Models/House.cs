namespace DreamHouse4You.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DreamHouse4You.Data.Common.Models;

    public class House : IAuditInfo, IDeletableEntity
    {
        public House()
        {
            this.Id = Guid.NewGuid().ToString();
            this.IsDeleted = false;
            this.CreatedOn = DateTime.UtcNow;
        }

        public string Id { get; set; }

        public string Tittle { get; set; }

        public string Description { get; set; }

        public string UploadUserId { get; set; }

        public ApplicationUser UploadUser { get; set; }

        public int Area { get; set; }

        // ToDo: AreaType enum type
        public string AreaType { get; set; }

        public double Price { get; set; }

        // ToDo: PriceValue enum type
        public string Currency { get; set; }

        public string MainPicture { get; set; }

        public string Picture2 { get; set; }

        public string Picture3 { get; set; }

        public string Picture4 { get; set; }

        public string Picture5 { get; set; }

        public string Picture6 { get; set; }

        public string Picture7 { get; set; }

        public string Picture8 { get; set; }

        public string Picture9 { get; set; }

        public string Picture10 { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}