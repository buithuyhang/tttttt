using System;
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
            SetLoginView(ViewPath, null, null);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            Config(filterContext);

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

                filterContext.Result = View(_ViewPath, model);
                OnEnter(null);
            }
            else
            {
                OnEnter(Access);
            }

        }
    }
}
