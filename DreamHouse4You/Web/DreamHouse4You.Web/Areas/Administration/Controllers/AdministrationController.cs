namespace DreamHouse4You.Web.Areas.Administration.Controllers
{
    using DreamHouse4You.Common;
    using DreamHouse4You.Services.Contracts.AdminAccount.Access;
    using DreamHouse4You.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
        protected IAddCategoryService addCategoryService;

        public AdministrationController(IAddCategoryService addCategoryService)
        {
            this.addCategoryService = addCategoryService;
        }
    }
}
