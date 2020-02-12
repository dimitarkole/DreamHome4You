namespace DreamHouse4You.Services.CommonResorces
{
    using DreamHouse4You.Data;
    using DreamHouse4You.Services.Contracts.CommonResorces;
    using DreamHouse4You.Web.ViewModels.CommonResorces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CategoryServices : ICategoryService
    {
        private readonly ApplicationDbContext context;

        public CategoryServices(ApplicationDbContext context)
        {
            this.context = context;
        }

        public CategoriesViewModel GetCategories()
        {
            var categories = this.context.Categories
                .OrderByDescending( c=> c.Name)
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    ParentId = c.ParentCategoryId,
                    ParentName = c.ParentCategory.Name,
                }).ToList();
            var nullCategory = new CategoryViewModel();
            categories.Add(nullCategory);
            categories.Reverse();
            var result = new CategoriesViewModel(categories);
            return result;
        }
    }
}
