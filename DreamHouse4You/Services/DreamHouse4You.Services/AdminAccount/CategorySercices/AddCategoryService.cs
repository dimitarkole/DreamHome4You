namespace DreamHouse4You.Services.AdminAccount.CategorySercices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using DreamHouse4You.Data;
    using DreamHouse4You.Data.Models;
    using DreamHouse4You.Services.Contracts.AdminAccount.CategorySercices;
    using DreamHouse4You.Services.Contracts.CommonResorces;
    using DreamHouse4You.Web.ViewModels.Administration.Category;

    public class AddCategoryService : IAddCategoryService
    {
        private readonly ApplicationDbContext context;
        private readonly ICategoryService categoryService;

        public AddCategoryService(
            ApplicationDbContext context,
            ICategoryService categoryService)
        {
            this.context = context;
            this.categoryService = categoryService;
        }

        public string AddNewCategory(AddCategoryViewModel model, string userId)
        {
            var result = "Категорията се доблира с друга категория!";
            if (this.IsDublicateCategory(model) == false)
            {
                this.AddCategoryAtDB(model, userId);
                result = "Категорията е добавена успешно!";
            }

            return result;
        }

        public AddCategoryViewModel PreperedPage()
        {
            var categories = this.categoryService.GetCategories();
            var model = new AddCategoryViewModel()
            {
                ParentCategorys = categories,
            };
            return model;
        }

        private void AddCategoryAtDB(AddCategoryViewModel model, string userId)
        {
            var parentCategory = this.context.Categories.FirstOrDefault(c => c.Id == model.SelectedParentCategoryId);
            var user = this.context.Users.Find(userId); 
            Category category = new Category()
            {
                User = user,
                UserId = userId,
                Name = model.Name,
                ParentCategory = parentCategory,
                ParentCategoryId = model.SelectedParentCategoryId,
            };
            this.context.Categories.Add(category);
            this.context.SaveChanges();
        }

        private bool IsDublicateCategory(AddCategoryViewModel model)
        {
            var check = this.context.Categories.FirstOrDefault(c => c.Name == model.Name);
            if (check == null)
            {
                return false;
            }

            return true;
        }
    }
}
