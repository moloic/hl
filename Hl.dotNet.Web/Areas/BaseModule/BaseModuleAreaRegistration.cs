using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hl.dotNet.Web.Areas.BaseModule
{
    public class BaseModule1AreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "BaseModule";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                this.AreaName + "_Default",
                this.AreaName + "/{controller}/{action}/{id}",
                new { area = this.AreaName, controller = "Home", action = "Index", id = UrlParameter.Optional },
                new string[] { "Hl.dotNet.Web.Areas." + this.AreaName + ".Controllers" }
            );
        }



    }
}
