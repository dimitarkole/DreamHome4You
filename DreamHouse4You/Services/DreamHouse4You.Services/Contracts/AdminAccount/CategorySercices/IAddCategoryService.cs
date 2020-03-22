namespace DreamHouse4You.Services.Contracts.AdminAccount.CategorySercices
{ 
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DreamHouse4You.Web.ViewModels.Administration.Category;

    public interface IAddCategoryService
    {
        public string AddNewCategory(AddCategoryViewModel model, string userId);

        public AddCategoryViewModel PreperedPage();

    }
}
