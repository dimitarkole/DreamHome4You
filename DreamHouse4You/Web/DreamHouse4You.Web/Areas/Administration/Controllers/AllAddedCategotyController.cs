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
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class AllAddedCategotyController : AdministrationController
    {
        public AllAddedCategotyController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailSender emailSender, ILogger<AccountController> logger, IAddCategoryService addCategoryService, ISettingsService settingsService, ICategoryService categoryServices, IAddedCategoriesService addedCategoriesService) : base(userManager, signInManager, emailSender, logger, addCategoryService, settingsService, categoryServices, addedCategoriesService)
        {
        }

        public IActionResult Index()
        {
            
            return View();
        }
    }
}