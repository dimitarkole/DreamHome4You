namespace DreamHouse4You.Services.AdminAccount.Access
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using DreamHouse4You.Data;
    using DreamHouse4You.Services.Contracts.AdminAccount.Access;
    using DreamHouse4You.Web.ViewModels.Administration.Access;

    public class AddCategoryService : IAddCategoryService
    {
        private readonly ApplicationDbContext context;

        public AddCategoryService(
            ApplicationDbContext context)
        {
            this.context = context;
        }

        public string AddNewCategory(AddCategoryViewModel model)
        {

            throw new NotImplementedException();
        }
    }
}
