namespace DreamHouse4You.Web.Areas.User.Controllers
{
    using DreamHouse4You.Common;
    using DreamHouse4You.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.UserRoleName)]
    [Area("User")]

    public class UserController : BaseController
    {
       
    }
}
