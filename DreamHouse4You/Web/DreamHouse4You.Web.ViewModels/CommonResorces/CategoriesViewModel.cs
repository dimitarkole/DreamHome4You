namespace DreamHouse4You.Web.ViewModels.CommonResorces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CategoriesViewModel
    {
        public CategoriesViewModel()
        {
            this.Categories = new List<CategoryViewModel>();
        }

        public CategoriesViewModel(List<CategoryViewModel> categories)
        {
            this.Categories = categories;
        }

        public List<CategoryViewModel> Categories { get; set; }
    }
}
