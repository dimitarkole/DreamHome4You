namespace DreamHouse4You.Services.Contracts.CommonResorces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DreamHouse4You.Web.ViewModels.CommonResorces;

    public interface ICategoryService
    {
        public CategoriesViewModel GetCategories();
    }
}
