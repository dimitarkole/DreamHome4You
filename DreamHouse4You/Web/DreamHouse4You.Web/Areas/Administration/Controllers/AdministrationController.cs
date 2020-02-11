namespace DreamHouse4You.Web.Areas.Administration.Controllers
{
    using DreamHouse4You.Common;
    using DreamHouse4You.Data.Models;
    using DreamHouse4You.Services.Contracts.AdminAccount.Access;
    using DreamHouse4You.Services.Contracts.CommonResorces;
    using DreamHouse4You.Services.Data;
    using DreamHouse4You.Services.Messaging;
    using DreamHouse4You.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IEmailSender emailSender;
        private readonly ILogger logger;

        protected readonly IAddCategoryService addCategoryService;
        protected readonly INotificationServices notificationServices;
        protected readonly ISettingsService settingsService;
        protected string userId;

        public AdministrationController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ILogger<AccountController> logger,
            IAddCategoryService addCategoryService,
            ISettingsService settingsService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.emailSender = emailSender;
            this.logger = logger;
            this.addCategoryService = addCategoryService;
            this.settingsService = settingsService;
        }

        protected void StarUp()
        {
            this.userId = this.userManager.GetUserId(this.User);
            var messages = this.notificationServices.AddNotification(this.userId);
            //this.ViewData["MessageNavBar"] = messages;
        }
    }
}
