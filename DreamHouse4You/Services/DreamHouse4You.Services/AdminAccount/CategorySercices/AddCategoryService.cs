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
            var message = this.CheckNullData(model);
            if (message == null)
            {
                message = "Категорията се доблира с друга категория!";
                if (this.IsDublicateCategoryAdd(model) == false)
                {
                    this.AddCategoryAtDB(model, userId);
                    message = "Успешно добавена категорията!";
                }
            }

            return message;
        }

        public Dictionary<string, object> EditCategory(AddCategoryViewModel model, string categoryId, string userId)
        {
            var result = new Dictionary<string, object>();
            result.Add("model", model);
            var message = this.CheckNullData(model);
            if (message == null)
            {
                message = "Категорията се доблира с друга категория!";
                if (this.IsDublicateCategoryAdd(model) == false)
                {
                    this.EditCategoryAtDB(model,categoryId, userId);
                    message = "Успешно редактирана категорията!";
                }
            }

            result.Add("message", message);
            return result;
        }

        public AddCategoryViewModel PreperedPage()
        {
            var categories = this.categoryService.GetCategories();
            var model = new AddCategoryViewModel()
            {
                ParentCategories = categories,
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

        private void EditCategoryAtDB(AddCategoryViewModel model, string categoryId, string userId)
        {
            var categoty = this.context.Categories.Where(c => c.Id == categoryId);
            var parentCategory = this.context.Categories
                .FirstOrDefault(c => c.Id == model.SelectedParentCategoryId);
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

        private bool IsDublicateCategoryAdd(AddCategoryViewModel model)
        {
            var check = this.context.Categories.FirstOrDefault(c => c.Name == model.Name);
            if (check == null)
            {
                return false;
            }

            return true;
        }

        private bool IsDublicateCategoryEdit(AddCategoryViewModel model, string categoryId)
        {
            var check = this.context.Categories
                .FirstOrDefault(c => c.Name == model.Name && c.Id != categoryId);
            if (check == null)
            {
                return false;
            }

            return true;
        }

        private string CheckNullData(AddCategoryViewModel model)
        {
            StringBuilder result = new StringBuilder();
            if (string.IsNullOrEmpty(model.Name) || string.IsNullOrWhiteSpace(model.Name) || (model.Name.Length > 5))
            {
                result.AppendLine("Името на категорията трябва да съдържа поне 5 символа!");
            }

            return result.ToString().Trim();
        }
    }
}
