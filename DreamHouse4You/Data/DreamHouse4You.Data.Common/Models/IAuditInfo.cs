namespace DreamHouse4You.Data.Common.Models
{
    using System;

    public interface IAuditInfo
    {
        DateTime CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }
    }
}
