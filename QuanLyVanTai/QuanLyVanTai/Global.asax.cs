using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Test
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            // Hàm này để cài đặt cho phần Quản Lý Tài Khoản
            // Tham số thứ nhất là chuỗi kết nối SQL
            // Tham số thứ hai là tên tài khoản Quản trị cấp cao
            // Tham số thứ ba là mật khẩu quản trị cấp cao
            //QuanLyTaiKhoan.Context.Setup(
            //    @"Data Source=DCDATA\MSSQLSERVER2014;Initial Catalog=QLVanTai_2017;Persist Security Info=True;User ID=sa;Password=123ngoisao!",
            //    "admin",
            //    "QuanAnhUyen"
            //);

            // Hàm này để cài đặt cho phần Quản Lý Tài Khoản
            // Chuỗi kết nối ở đây sẽ được lấy mặc định từ config ( app.config, web.config ) có name là QuanLyTaiKhoan.Properties.Settings.QLVanTai_2017ConnectionString
            // Tham số thứ nhất là tên tài khoản Quản trị cấp cao
            // Tham số thứ hai là mật khẩu quản trị cấp cao

            QuanLyTaiKhoan.Context.Setup(
                "admin",
                "admin"
            );
        }
    }
}
