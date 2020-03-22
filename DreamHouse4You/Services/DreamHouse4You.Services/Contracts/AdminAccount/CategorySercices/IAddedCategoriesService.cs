namespace DreamHouse4You.Services.Contracts.AdminAccount.CategorySercices
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using DreamHouse4You.Web.ViewModels.Administration.Category;

    public interface IAddedCategoriesService
    {
        public AddedCategoriesViewModel PreparedPage();

        public AddedCategoriesViewModel GetAllAddedCategories(AddedCategoriesViewModel model);

        public AddedCategoriesViewModel ChangeActivePage(AddedCategoriesViewModel model, int id);
    }
}
