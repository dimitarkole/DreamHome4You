namespace DreamHouse4You.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamHouse4You.Services.Contracts.AdminAccount.Access;
    using DreamHouse4You.Web.ViewModels.Administration.Access;
    using Microsoft.AspNetCore.Mvc;

    public class AddCategoryController : AdministrationController
    {
        public AddCategoryController(IAddCategoryService addCategoryService)
            : base(addCategoryService)
        {
        }

        public IActionResult Index()
        {
            AddCategoryViewModel model = new AddCategoryViewModel();
            return this.View(model);
        }
    }
}