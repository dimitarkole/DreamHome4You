namespace DreamHouse4You.Services.AdminAccount.CategorySercices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using DreamHouse4You.Data;
    using DreamHouse4You.Services.Contracts.AdminAccount.CategorySercices;
    using DreamHouse4You.Web.ViewModels.Administration.Category;
    using DreamHouse4You.Web.ViewModels.CommonResorces;

    public class AddedCategoriesService : IAddedCategoriesService
    {
        private readonly ApplicationDbContext context;

        public AddedCategoriesService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public AddedCategoriesViewModel PreparedPage()
        {
            var model = new AddedCategoriesViewModel();

            return this.GetAllAddedCategories(model);
        }

        public AddedCategoriesViewModel GetAllAddedCategories(AddedCategoriesViewModel model)
        {
            var genreName = model.SearchCategory.Name;
            var sortMethodId = model.SortMethodId;
            var countBooksOfPage = model.CountCategoriesOfPage;
            var currentPage = model.CurrentPage;

            var categories = this.context.Categories
                .Where(c => c.DeletedOn == null)
                .OrderBy(c => c.Name)
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    ParentId = c.ParentCategoryId,
                    ParentName = c.ParentCategory.Name,
                });
            categories = this.SelectGenres(genreName, categories);
            categories = this.SortGenres(sortMethodId, categories);

            int maxCountPage = categories.Count() / countBooksOfPage;
            if (categories.Count() % countBooksOfPage != 0)
            {
                maxCountPage++;
            }


            var viewCategories = categories.Skip((currentPage - 1) * countBooksOfPage)
                                .Take(countBooksOfPage)
                                .ToList();
            var returnModel = new AddedCategoriesViewModel()
            {
                Categories = viewCategories,
                CountCategoriesOfPage = model.CountCategoriesOfPage,
                CountCategoriesOfPageList = model.CountCategoriesOfPageList,
                SortMethodId = model.SortMethodId,
                SearchCategory = model.SearchCategory,
            };
            return returnModel;
        }

        public AddedCategoriesViewModel ChangeActivePage(AddedCategoriesViewModel model, int id)
        {
            model.CurrentPage = id;
            return this.GetAllAddedCategories(model);

        }

        public AddCategoryViewModel GetCategoryData(string categoryId)
        {
            var category = this.context.Categories.FirstOrDefault(c => c.Id == categoryId);
            var allCategory = this.context.Categories
                .Where(c => c.Id != categoryId)
                .Select(c => new CategoryViewModel()
                {
                    Name = c.Name,
                    Id = c.Name,
                    ParentId = c.ParentCategoryId,
                    ParentName = c.ParentCategory.Name,
                }).ToList();
            CategoriesViewModel categories = new CategoriesViewModel()
            {
                Categories = allCategory,
            };


            var model = new AddCategoryViewModel()
            {
                Name = category.Name,
                ParentCategories = categories,
                SelectedParentCategoryId = category.ParentCategoryId,
            };

            return model;
        }

        public AddedCategoriesViewModel DeleteCategory(string userId, AddedCategoriesViewModel model, string categoryId)
        {
            var category = this.context.Categories.FirstOrDefault(c => c.Id == categoryId);
            category.DeletedOn = DateTime.UtcNow;
            this.context.SaveChanges();

            return this.PreparedPage();
        }

        private IQueryable<CategoryViewModel> SortGenres(
            string sortMethodId,
            IQueryable<CategoryViewModel> categories)
        {
            if (sortMethodId == "Име а-я")
            {
                categories = categories.OrderByDescending(g => g.Name);
            }
            else
            {
                categories = categories.OrderBy(g => g.Name);
            }

            return categories;
        }

        private IQueryable<CategoryViewModel> SelectGenres(
          string genreName,
          IQueryable<CategoryViewModel> categories)
        {
            if (genreName != null)
            {
                categories = categories.Where(g => g.Name.Contains(genreName));
            }

            return categories;
        }

     
    }
}
