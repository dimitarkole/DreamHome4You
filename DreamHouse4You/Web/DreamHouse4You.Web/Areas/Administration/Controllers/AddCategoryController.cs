namespace DreamHouse4You.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DreamHouse4You.Data.Models;
    using DreamHouse4You.Services.Contracts.AdminAccount.Access;
    using DreamHouse4You.Services.Data;
    using DreamHouse4You.Services.Messaging;
    using DreamHouse4You.Web.ViewModels.Administration.Access;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class AddCategoryController : AdministrationController
    {
        public AddCategoryController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailSender emailSender, ILogger<AccountController> logger, IAddCategoryService addCategoryService, ISettingsService settingsService) : base(userManager, signInManager, emailSender, logger, addCategoryService, settingsService)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            AddCategoryViewModel model = new AddCategoryViewModel();
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Index(AddCategoryViewModel model)
        {
            var result = this.addCategoryService.AddNewCategory(model, this.userId); ;
            //AddCategoryViewModel model = new AddCategoryViewModel();
            return this.View(model);
        }
    }
}