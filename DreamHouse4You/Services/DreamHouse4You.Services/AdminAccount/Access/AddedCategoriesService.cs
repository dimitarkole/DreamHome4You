namespace DreamHouse4You.Services.AdminAccount.Access
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using DreamHouse4You.Data;
    using DreamHouse4You.Services.Contracts.AdminAccount.Access;
    using DreamHouse4You.Web.ViewModels.Administration.Access;
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
            var model = new AddedCategoriesViewModel()
            {
                Categories = this.GetAllAddedCategory(),
            };

            return model;
        }

        private List<CategoryViewModel> GetAllAddedCategory()
        {
            var categories = this.context.Categories
                .OrderBy(c => c.Name)
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    ParentId = c.ParentCategoryId,
                    ParentName = c.ParentCategory.Name,
                }).ToList();
            return categories;
        }
    }
}
