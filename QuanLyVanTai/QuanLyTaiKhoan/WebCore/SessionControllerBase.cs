using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;

namespace QuanLyTaiKhoan.WebCore
{
    /// <summary>
    /// Have OnActionExecuting for prechecking member login.
    /// </summary>
    public abstract class SessionControllerBase : Controller
    {
        public Access Access
        {
            get
            {
                return Session["___SessionController.Access"] as Access;
            }
            private set
            {
                Session["___SessionController.Access"] = value;
            }
        }

        private string _ViewPath;
        private string _UsernameFieldName;
        private string _PasswordFieldName;

        protected bool AccessCheckingPermission_Enabled { get; set; }
        private string AccessCheckingPermission_GroupPermission;
        private ActionResult AccessCheckingPermission_DenyResult;

        /// <summary>
        /// Cấu hình SessionController
        /// </summary>
        /// <returns>The config.</returns>
        /// <param name="filterContext">Filter context.</param>
        protected abstract void Config(ActionExecutingContext filterContext);

        /// <summary>
        /// Khi người dùng truy cập
        /// </summary>
        /// <param name="Access">null nếu chưa đăng nhập thành công, ngược lại trả về đối tượng Access hợp lệ.</param>
        protected abstract void OnEnter(Access Access);

        protected void SetLoginView(string ViewPath, string UsernameFieldName, string PasswordFieldName)
        {
            _ViewPath = ViewPath;
            _UsernameFieldName = UsernameFieldName.Trim();
            _PasswordFieldName = PasswordFieldName.Trim();
        }

        protected void SetLoginView(string ViewPath)
        {
            SetLoginView(ViewPath, string.Empty, string.Empty);
        }

        protected void SetAccessCheckingPermission (string GroupPermission, ActionResult DenyResult)
        {
            AccessCheckingPermission_Enabled = true;
            AccessCheckingPermission_GroupPermission = GroupPermission;
            AccessCheckingPermission_DenyResult = DenyResult;
        }

        protected override void OnActionExecuting(ActionExecutingContext ctx)
        {
            base.OnActionExecuting(ctx);

            Config(ctx);

            if (Access == null)
            {
                LoginViewModel model = new LoginViewModel();
                if (!string.IsNullOrEmpty(_UsernameFieldName))
                {
                    model.UsernameField = _UsernameFieldName;
                }
                if (!string.IsNullOrEmpty(_PasswordFieldName))
                {
                    model.PasswordField = _PasswordFieldName;
                }

                if (!string.IsNullOrEmpty(model.UsernameValue) && !string.IsNullOrEmpty(model.PasswordValue))
                {

                    try
                    {
                        Access = Access.Login(model.UsernameValue, model.PasswordValue);
                        ctx.Result = RedirectToRoute(ctx.RouteData.Values);
                        return;
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        model.Message = ex.Message;
                    }
                    catch (Exception ex)
                    {
                        model.Message = "Lỗi hệ thống, vui lòng liên hệ quản trị viên để kiểm tra lại thông tin!";
                        NhatKy.Loi("Người dùng đăng nhập", ex.Message);
                    }
                }

                ctx.Result = View(_ViewPath, model);
                OnEnter(null);
            }
            else
            {
                if (AccessCheckingPermission_Enabled)
                {
                    var _ = Url.Content("~");
                    var __ = Url.Content(Request.Path);
                    if (_ != __)
                    {
                        if (QuanLyTaiKhoan.Context.DB.HT_Quyens.FirstOrDefault(q => q.Rule == __ && q.NhomQuyen == AccessCheckingPermission_GroupPermission) == null)
                        {
                            QuanLyTaiKhoan.Context.ThemQuyen(AccessCheckingPermission_GroupPermission, __, __);
                        }
                        if (!Access.DuocPhep(__, AccessCheckingPermission_GroupPermission))
                        {
                            ctx.Result = AccessCheckingPermission_DenyResult;
                        }
                    }
                }
                OnEnter(Access);
            }

        }

        public RedirectResult Signout ()
        {
            Access = null;
            return Redirect("~");
        }
    }
}
