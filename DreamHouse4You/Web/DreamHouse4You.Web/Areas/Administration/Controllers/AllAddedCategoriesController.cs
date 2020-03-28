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

    public class AllAddedCategoriesController : AdministrationController
    {
        public AllAddedCategoriesController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailSender emailSender, ILogger<AccountController> logger, IAddCategoryService addCategoryService, ISettingsService settingsService, ICategoryService categoryServices, IAddedCategoriesService addedCategoriesService) : base(userManager, signInManager, emailSender, logger, addCategoryService, settingsService, categoryServices, addedCategoriesService)
        {
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            this.StartUp();
            var model = this.addedCategoriesService.PreparedPage();
            return this.View("Index", model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult ChangePage(AddedCategoriesViewModel model, int id)
        {
            this.StartUp();
            var returnModel = this.addedCategoriesService.ChangeActivePage(model, id);
            return this.View(returnModel);
        }

        [Authorize]
        [HttpGet]
        public IActionResult DeleteCategory(AddedCategoriesViewModel model, string id)
        {
            this.StartUp();
            var returnModel = this.addedCategoriesService.DeleteCategory(this.userId, model, id);
            this.ViewData["message"] = "Успешно премахнат жанр!";
            return this.View("Index", returnModel);
        }

        [Authorize]
        [HttpGet]
        public IActionResult EditCategory(AddedCategoriesViewModel model, string id)
        {
            this.StartUp();
            var returnModel = this.addedCategoriesService.GetCategoryData(id);
            this.TempData["editCategoryId"] = id;
            return this.View("EditCategory", returnModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult EditingCategory(AddCategoryViewModel model)
        {
            this.StartUp();
            var categoryId = this.TempData["editCategoryId"].ToString();
            var result = this.addCategoryService.EditCategory(model, categoryId, this.userId);
            var message = result["message"].ToString();
            if (message.Contains("Успешно"))
            {
                return this.Index();
            }

            var returnModel = result["model"];
            return this.View("EditCategory", returnModel);
        }
    }
}
