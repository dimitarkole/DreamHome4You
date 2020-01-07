namespace DreamHouse4You.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DreamHouse4You.Data.Common.Models;

    public class House : IAuditInfo, IDeletableEntity
    {
        public string Tittle { get; set; }

        public string Description { get; set; }

        public string UploadUserId { get; set; }

        public ApplicationUser UploadUser { get; set; }

        public int Area { get; set; }

        // ToDo: AreaType enum type
        public string AreaType { get; set; }

        public double Price { get; set; }

        // ToDo: PriceValue enum type
        public string PriceValue { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}