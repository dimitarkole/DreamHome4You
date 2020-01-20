namespace DreamHouse4You.Web.ViewModels.Administration.Access
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AddCategoryViewModel
    {
        public string Name { get; set; }

        public string SelectedParentCategoryId { get; set; }

        public List<string> ParentCategorys { get; set; }

    }
}
