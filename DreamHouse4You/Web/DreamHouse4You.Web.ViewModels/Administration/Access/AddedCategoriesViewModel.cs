namespace DreamHouse4You.Web.ViewModels.Administration.Access
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DreamHouse4You.Web.ViewModels.CommonResorces;

    public class AddedCategoriesViewModel
    {
        public AddedCategoriesViewModel()
        {
            this.Categories = new List<CategoryViewModel>();
        }

        public List<CategoryViewModel> Categories { get; set; }
    }
}
