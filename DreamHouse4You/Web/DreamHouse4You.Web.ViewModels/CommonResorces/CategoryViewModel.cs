namespace DreamHouse4You.Web.ViewModels.CommonResorces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CategoryViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ParentId { get; set; }

        public string ParentName { get; set; }
    }
}
