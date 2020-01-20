namespace DreamHouse4You.Web.Areas.User.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
   
    public class DashboardController : UserController
    {
        public IActionResult Proba()
        {
            return this.View();
        }
    }
}
