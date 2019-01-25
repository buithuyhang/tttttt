using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyTaiKhoan;
using QuanLyTaiKhoan.WebCore;

namespace WebQuanLyTaiKhoan.Controllers
{
    public class ControllerBase : SessionControllerBase
    {
        protected override void Config(ActionExecutingContext filterContext)
        {
            ViewBag.Title = "Quản lý tài khoản";
            SetLoginView("~/Views/Shared/LoginView.cshtml", "oso1", "oso2");
        }

        protected override void OnEnter(Access Access)
        {
            ViewBag.Access = Access;
        }
    }
}
