namespace DreamHouse4You.Web.ViewModels.Administration.Category
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
            this.ParentCategories = parentCategorys;
        }

        public string Name { get; set; }

        public string SelectedParentCategoryId { get; set; }

        public CategoriesViewModel ParentCategories { get; set; }

    }
}
