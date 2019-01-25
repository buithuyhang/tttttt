using QuanLyTaiKhoan.WebCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyTaiKhoan;

namespace Test.Controllers
{
    public class Controller : SessionControllerBase
    {
        protected override void Config(ActionExecutingContext filterContext)
        {
            SetLoginView("~/Views/Shared/LoginView.cshtml", "txt-username", "txt-password");
            SetAccessCheckingPermission("View", View("~/Views/Shared/AccessDeny.cshtml"));
        }

        protected override void OnEnter(Access Access)
        {
            ViewBag.Access = Access;
        }
    }
}