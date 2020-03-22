namespace DreamHouse4You.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using DreamHouse4You.Data.Models;
    using DreamHouse4You.Services.Contracts.AdminAccount.CategorySercices;
    using DreamHouse4You.Services.Contracts.CommonResorces;
    using DreamHouse4You.Services.Data;
    using DreamHouse4You.Services.Messaging;
    using DreamHouse4You.Web.ViewModels.Administration.Category;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class AllAddedCategotiesController : AdministrationController
    {
        public AllAddedCategotiesController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailSender emailSender, ILogger<AccountController> logger, IAddCategoryService addCategoryService, ISettingsService settingsService, ICategoryService categoryServices, IAddedCategoriesService addedCategoriesService) : base(userManager, signInManager, emailSender, logger, addCategoryService, settingsService, categoryServices, addedCategoriesService)
        {
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            this.StarUp();
            var model = this.addedCategoriesService.PreparedPage();
            return this.View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult ChangePageAllCategories(AddedCategoriesViewModel model, int id)
        {
            this.StarUp();
            var returnModel = this.addedCategoriesService.ChangeActivePage(model, id);
            return this.View(returnModel);
        }
    }
}