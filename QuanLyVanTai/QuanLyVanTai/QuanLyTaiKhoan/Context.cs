using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace QuanLyTaiKhoan
{
    public static class Context
    {
        private const string SA_DEFAULT_USERNAME = "sa";
        private const string SA_DEFAULT_PASSWORD = "default123";

        private static string HTDB_ConnectionString;

        internal static HT_TaiKhoan SA { get; private set; }

        private static HTDataClassDataContext _DB;

        public static HTDataClassDataContext DB
        {
            get
            {
                if (string.IsNullOrEmpty(HTDB_ConnectionString))
                {
                    Setup();
                }
                return _DB = _DB != null ? _DB : new HTDataClassDataContext(HTDB_ConnectionString);
            }
        }

        #region [Constructor]
        /// <summary>
        /// Thiết lập thông tin cho phần Quản Lý Tài Khoản.
        /// </summary>
        /// <returns>The setup.</returns>
        /// <param name="HTDB_ConnectionString">Chuỗi kết nối CSDL.</param>
        /// <param name="SA_TenTaiKhoan">Tên tài khoản Quản Trị Cấp Cao.</param>
        /// <param name="SA_MatKhau">Mật khẩu tài khoản Quản Trị Cấp Cao.</param>
        public static void Setup(string HTDB_ConnectionString, string SA_TenTaiKhoan, string SA_MatKhau)
        {
            Contract.Requires(string.IsNullOrEmpty(SA_MatKhau) == false);
            Contract.Requires(string.IsNullOrEmpty(SA_TenTaiKhoan) == false);
            Contract.Requires(string.IsNullOrEmpty(HTDB_ConnectionString) == false);
            if (SA_MatKhau == null)
                throw new ArgumentNullException("SA_MatKhau");
            if (SA_TenTaiKhoan == null)
                throw new ArgumentNullException("SA_TenTaiKhoan");
            if (HTDB_ConnectionString == null)
                throw new ArgumentNullException("HTDB_ConnectionString");
            Context.HTDB_ConnectionString = HTDB_ConnectionString;

            SA = new HT_TaiKhoan()
            {
                IDTaiKhoan = -1,
                TenTaiKhoan = SA_TenTaiKhoan,
                MatKhau = SA_MatKhau
            };
        }

        /// <summary>
        /// Thiết lập thông tin cho phần Quản Lý Tài Khoản.
        /// Chuỗi kết nối CSDL được lấy mặc định trong tệp config với name="QuanLyTaiKhoan.Properties.Settings.QLVanTai_2017ConnectionString"
        /// </summary>
        /// <returns>The setup.</returns>
        /// <param name="SA_TenTaiKhoan">Tên tài khoản Quản Trị Cấp Cao.</param>
        /// <param name="SA_MatKhau">Mật khẩu tài khoản Quản Trị Cấp Cao.</param>
        public static void Setup(string SA_TenTaiKhoan, string SA_MatKhau)
        {
            if (global::QuanLyTaiKhoan.Properties.Settings.Default.QLVanTai_2017ConnectionString != null)
            {
                Setup(global::QuanLyTaiKhoan.Properties.Settings.Default.QLVanTai_2017ConnectionString, SA_TenTaiKhoan, SA_MatKhau);
            }
            else
            {
                throw new MissingFieldException("connectionStrings", "QuanLyTaiKhoan.Properties.Settings.QLVanTai_2017ConnectionString");
            }
        }

        /// <summary>
        /// Thiết lập thông tin cho phần Quản Lý Tài Khoản.
        /// Chuỗi kết nối CSDL được lấy mặc định trong tệp config với name="QuanLyTaiKhoan.Properties.Settings.QLVanTai_2017ConnectionString"
        /// Tên tài khoản mặc định là [sa]
        /// </summary>
        /// <returns>The setup.</returns>
        /// <param name="SA_MatKhau">Mật khẩu tài khoản Quản Trị Cấp Cao.</param>
        public static void Setup(string SA_MatKhau)
        {
            Setup(SA_DEFAULT_USERNAME, SA_MatKhau);
        }

        /// <summary>
        /// Thiết lập với cấu hình mặc định.
        /// 
        /// sa - default123
        /// </summary>
        public static void Setup()
        {
            Setup(SA_DEFAULT_PASSWORD);
        }

        static Context()
        {
            SA = new HT_TaiKhoan()
            {
                IDTaiKhoan = -1,
                TenTaiKhoan = SA_DEFAULT_USERNAME,
                MatKhau = SA_DEFAULT_PASSWORD
            };
        }
        #endregion

        #region [Account]
        /// <summary>
        /// Them tài khoản với các giá trị tuỳ chọn
        /// </summary>
        /// <returns>Tài khoản.</returns>
        /// <param name="TenTaiKhoan">Tên tài khoản.</param>
        /// <param name="MatKhau">Mật khẩu.</param>
        /// <param name="IDSo">ID Sở.</param>
        /// <param name="IDBen">ID Bến.</param>
        /// <param name="IDDonViVanTai">ID Đơn vị vận tải.</param>
        private static HT_TaiKhoan ThemTaiKhoan(string TenTaiKhoan, string MatKhau, System.Nullable<long> IDSo, System.Nullable<long> IDBen, System.Nullable<long> IDDonViVanTai)
        {
            HT_TaiKhoan tk = new HT_TaiKhoan()
            {
                TenTaiKhoan = TenTaiKhoan,
                MatKhau = MatKhau,
                IDSo = IDSo,
                IDBen = IDBen,
                IDDonViVanTai = IDDonViVanTai,
                ThoiGianTao = DateTime.Now
            };
            DB.HT_TaiKhoans.InsertOnSubmit(tk);
            DB.SubmitChanges();
            return tk;
        }

        /// <summary>
        /// Thêm tài khoản cấp Tổng cục
        /// </summary>
        /// <returns>Tài khoản Tổng cục.</returns>
        /// <param name="TenTaiKhoan">Tên tài khoản.</param>
        /// <param name="MatKhau">Mật khẩu.</param>
        public static HT_TaiKhoan ThemTaiKhoanTongCuc(string TenTaiKhoan, string MatKhau)
        {
            return ThemTaiKhoan(TenTaiKhoan, MatKhau, null, null, null);
        }

        /// <summary>
        /// Thêm tài khoản cấp Sở
        /// </summary>
        /// <returns>Tài khoản cấp Sở.</returns>
        /// <param name="TenTaiKhoan">Tên tài khoản.</param>
        /// <param name="MatKhau">Mật khẩu.</param>
        /// <param name="IDSo">ID Tỉnh / Sở.</param>
        public static HT_TaiKhoan ThemTaiKhoanSo(string TenTaiKhoan, string MatKhau, long IDSo)
        {
            return ThemTaiKhoan(TenTaiKhoan, MatKhau, IDSo, null, null);
        }

        /// <summary>
        /// Thêm tài khoản cấp Bến.
        /// </summary>
        /// <returns>Tài khoản cấp Bến.</returns>
        /// <param name="TenTaiKhoan">Tên tài khoản.</param>
        /// <param name="MatKhau">Mật khẩu.</param>
        /// <param name="IDSo">ID Sở phụ trách.</param>
        /// <param name="IDBen">ID Bến.</param>
        public static HT_TaiKhoan ThemTaiKhoanBen(string TenTaiKhoan, string MatKhau, long IDSo, long IDBen)
        {
            return ThemTaiKhoan(TenTaiKhoan, MatKhau, IDSo, IDBen, null);
        }

        /// <summary>
        /// Thêm tài khoản cấp Đơn vị vận tải.
        /// </summary>
        /// <returns>Tài khoản cấp Đơn vị vận tải.</returns>
        /// <param name="TenTaiKhoan">Tên tài khoản.</param>
        /// <param name="MatKhau">Mật khẩu.</param>
        /// <param name="IDSo">ID Sở phụ trách.</param>
        /// <param name="IDDonViVanTai">ID Đơn vị vận tải.</param>
        public static HT_TaiKhoan ThemTaiKhoanDonViVanTai(string TenTaiKhoan, string MatKhau, long IDSo, long IDDonViVanTai)
        {
            return ThemTaiKhoan(TenTaiKhoan, MatKhau, IDSo, null, IDDonViVanTai);
        }

        public static HT_TaiKhoan TimTheoIDTaiKhoan(long IDTaiKhoan)
        {
            return DB.HT_TaiKhoans.FirstOrDefault(tk => tk.IDTaiKhoan == IDTaiKhoan);
        }

        public static HT_TaiKhoan TimTheoTenTaiKhoan(string TenTaiKhoan)
        {
            return DB.HT_TaiKhoans.FirstOrDefault(tk => tk.TenTaiKhoan == TenTaiKhoan);
        }

        public static List<HT_TaiKhoan> DanhSachTaiKhoan()
        {
            return DB.HT_TaiKhoans.ToList();
        }
        #endregion

        #region [Permission]
        public const string PERMISSION_DEFAULT_GROUP = "Mặc định";

        /// <summary>
        /// Thêm quyền cho quá trình quản trị.
        /// (Tự động thêm quyền nếu chưa tồn tại trong hệ thống)
        /// </summary>
        /// <returns>Quyền trong hệ thống.</returns>
        /// <param name="TenQuyen">Tên quyền.</param>
        /// <param name="NhomQuyen">Nhóm quyền.</param>
        public static HT_Quyen ThemQuyen(string TenQuyen, string NhomQuyen)
        {
            if (DB.HT_Quyens.FirstOrDefault(q => q.TenQuyen == TenQuyen && q.NhomQuyen == NhomQuyen) == null)
            {
                DB.HT_Quyens.InsertOnSubmit(new HT_Quyen()
                {
                    TenQuyen = TenQuyen,
                    NhomQuyen = NhomQuyen
                });
                DB.SubmitChanges();
            }
            return DB.HT_Quyens.FirstOrDefault(q => q.TenQuyen == TenQuyen && q.NhomQuyen == NhomQuyen);
        }

        /// <summary>
        /// Thêm quyền cho quá trình quản trị, với giá trị [Nhóm quyền] được thiết đặt theo mặc định.
        /// (Tự động thêm quyền nếu chưa tồn tại trong hệ thống)
        /// (Tham khảo QuanLyTaiKhoan.Context.PERMISSION_DEFAULT_GROUP)
        /// </summary>
        /// <returns>Quyền trong hệ thống.</returns>
        /// <param name="TenQuyen">tên quyền.</param>
        public static HT_Quyen ThemQuyen(string TenQuyen)
        {
            return ThemQuyen(TenQuyen, PERMISSION_DEFAULT_GROUP);
        }

        /// <summary>
        /// Danh sách các quyền hiện có trong hệ thống
        /// </summary>
        /// <returns>Danh sách quyền trong hệ thống.</returns>
        public static List<HT_Quyen> DanhSachQuyen()
        {
            return DB.HT_Quyens.ToList();
        }
        #endregion
    }
}
