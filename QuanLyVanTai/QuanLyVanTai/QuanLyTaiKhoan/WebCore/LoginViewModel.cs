using System;
using System.Web;

namespace QuanLyTaiKhoan.WebCore
{
    /// <summary>
    /// Helper class model for design and processing Login-PageView
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Username input name
        /// </summary>
        /// <value>The username field.</value>
        public string UsernameField { get; set; }

        /// <summary>
        /// Password input name
        /// </summary>
        /// <value>The password field.</value>
        public string PasswordField { get; set; }

        /// <summary>
        /// Value of Username in FormData
        /// </summary>
        /// <value>The username value.</value>
        public string UsernameValue
        {
            get
            {
                return HttpContext.Current.Request.Form[UsernameField];
            }
        }

        /// <summary>
        /// Value of Password in FormData
        /// </summary>
        /// <value>The password value.</value>
        public string PasswordValue
        {
            get
            {
                return HttpContext.Current.Request.Form[PasswordField];
            }
        }

        /// <summary>
        /// Thông báo từ controller
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }

        public LoginViewModel()
        {
            UsernameField = "txt-username";
            PasswordField = "txt-password";
        }
    }
}
