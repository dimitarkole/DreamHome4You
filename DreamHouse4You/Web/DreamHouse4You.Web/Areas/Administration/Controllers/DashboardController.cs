namespace DreamHouse4You.Web.Areas.Administration.Controllers
{
    using DreamHouse4You.Data.Models;
    using DreamHouse4You.Services.Contracts.AdminAccount.CategorySercices;
    using DreamHouse4You.Services.Contracts.CommonResorces;
    using DreamHouse4You.Services.Data;
    using DreamHouse4You.Services.Messaging;
    using DreamHouse4You.Web.Areas.Administration.ViewModels.Dashboard;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class DashboardController : AdministrationController
    {
        public DashboardController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailSender emailSender, ILogger<AccountController> logger, IAddCategoryService addCategoryService, ISettingsService settingsService, ICategoryService categoryServices, IAddedCategoriesService addedCategoriesService) : base(userManager, signInManager, emailSender, logger, addCategoryService, settingsService, categoryServices, addedCategoriesService)
        {
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel { SettingsCount = this.settingsService.GetCount(), };
            return this.View(viewModel);
        }
    }
}
