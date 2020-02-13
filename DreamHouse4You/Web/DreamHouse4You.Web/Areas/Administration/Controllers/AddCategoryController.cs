namespace DreamHouse4You.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamHouse4You.Data.Models;
    using DreamHouse4You.Services.Contracts.AdminAccount.Access;
    using DreamHouse4You.Services.Contracts.CommonResorces;
    using DreamHouse4You.Services.Data;
    using DreamHouse4You.Services.Messaging;
    using DreamHouse4You.Web.ViewModels.Administration.Access;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class AddCategoryController : AdministrationController
    {
        public AddCategoryController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailSender emailSender, ILogger<AccountController> logger, IAddCategoryService addCategoryService, ISettingsService settingsService, ICategoryService categoryServices, IAddedCategoriesService addedCategoriesService) : base(userManager, signInManager, emailSender, logger, addCategoryService, settingsService, categoryServices, addedCategoriesService)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = this.addCategoryService.PreperedPage();
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Index(AddCategoryViewModel model)
        {
            var result = this.addCategoryService.AddNewCategory(model, this.userId); ;
            this.ViewData["message"] = result;
            return this.View(model);
        }
    }
}