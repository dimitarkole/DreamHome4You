namespace DreamHouse4You.Web.ViewModels.Administration.Access
{
    using DreamHouse4You.Web.ViewModels.CommonResorces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AddCategoryViewModel
    {
        public AddCategoryViewModel()
            : this(new CategoriesViewModel())
        {
        }

        public AddCategoryViewModel(CategoriesViewModel parentCategorys)
        {
            this.ParentCategorys = parentCategorys;
        }

        public string Name { get; set; }

        public string SelectedParentCategoryId { get; set; }

        public CategoriesViewModel ParentCategorys { get; set; }

    }
}
