using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyTaiKhoan
{
    /// <summary>
    /// Class hỗ trợ quá trình ghi Nhật Ký hoạt động của hệ thống,
    /// có nhiệm vụ ghi lại thao tác người dùng
    /// hoặc các hoạt động 'bất thường' của hệ thóng
    /// 
    /// Chú ý trong toàn bộ các trường thông tin nên sử dụng tiếng Việt có dấu
    /// </summary>
    public static class NhatKy
    {
        public delegate void ErrorEventHandler(HTDataClassDataContext DBctx, HT_NhatKy NhatKy, Exception ex);

        public static event ErrorEventHandler OnError;

        /// <summary>
        /// Ghi nhật ký chương trình
        /// </summary>
        /// <returns>Nhat ky.</returns>
        /// <param name="TenNhatKy">Ten nhat ky.</param>
        /// <param name="LoaiNhatKy">Loai nhat ky.</param>
        /// <param name="MoTa">Mo ta.</param>
        /// <param name="IDTaiKhoan">ID Tai khoan.</param>
        public static void Ghi(string TenNhatKy, string LoaiNhatKy, string MoTa, Nullable<long> IDTaiKhoan)
        {
            try
            {
                HT_NhatKy nk = new HT_NhatKy();
                try
                {
                    nk.TenNhatKy = TenNhatKy;
                    nk.LoaiNhatKy = LoaiNhatKy;
                    nk.MoTa = MoTa;

                    if (IDTaiKhoan != null && Context.DB.HT_TaiKhoans.First(tk => tk.IDTaiKhoan == IDTaiKhoan) != null)
                    {
                        nk.IDTaiKhoan = IDTaiKhoan;
                    }

                    nk.ThoiGianTao = DateTime.Now;

                    Context.DB.HT_NhatKies.InsertOnSubmit(nk);
                    Context.DB.SubmitChanges();
                }
                catch (Exception ex)
                {
                    if (OnError != null)
                    {
                        OnError(Context.DB, nk, ex);
                    }
                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// Ghi nhật ký hệ thống
        /// </summary>
        /// <returns>The ghi.</returns>
        /// <param name="TenNhatKy">Ten nhat ky.</param>
        /// <param name="LoaiNhatKy">Loai nhat ky.</param>
        /// <param name="MoTa">Mo ta.</param>
        public static void Ghi(string TenNhatKy, string LoaiNhatKy, string MoTa)
        {
            Ghi(TenNhatKy, LoaiNhatKy, MoTa, null);
        }

        /// <summary>
        /// Ghi nhật ký hệ thống vào khu vực chung
        /// </summary>
        /// <returns>The ghi.</returns>
        /// <param name="TenNhatKy">Ten nhat ky.</param>
        /// <param name="MoTa">Mo ta.</param>
        public static void Ghi(string TenNhatKy, string MoTa)
        {
            Ghi(TenNhatKy, "Nhật Ký Chung", MoTa);
        }

        /// <summary>
        /// Ghi nhật ký lỗi thao tác
        /// </summary>
        /// <returns>The loi.</returns>
        /// <param name="TenNhatKy">Ten nhat ky.</param>
        /// <param name="MoTa">Mo ta.</param>
        /// <param name="IDTaiKhoan">IDT ai khoan.</param>
        public static void Loi(string TenNhatKy, string MoTa, long IDTaiKhoan)
        {
            Ghi(TenNhatKy, "Nhật Ký Lỗi", MoTa, IDTaiKhoan);
        }

        /// <summary>
        /// Ghi nhật ký lỗi hệ thống
        /// </summary>
        /// <returns>The loi.</returns>
        /// <param name="TenNhatKy">Ten nhat ky.</param>
        /// <param name="MoTa">Mo ta.</param>
        public static void Loi(string TenNhatKy, string MoTa)
        {
            Ghi(TenNhatKy, "Nhật Ký Lỗi", MoTa);
        }

        /// <summary>
        /// Nhật ký thực hiện thao tác
        /// </summary>
        /// <param name="TenNhatKy">Ten nhat ky.</param>
        /// <param name="MoTa">Mo ta.</param>
        /// <param name="IDTaiKhoan">IDT ai khoan.</param>
        public static void DaThaoTac(string TenNhatKy, string MoTa, long IDTaiKhoan)
        {
            Ghi(TenNhatKy, "Nhật ký thao tác", MoTa, IDTaiKhoan);
        }

        /// <summary>
        /// Danh sách Tên nhật ký tồn tại trong hệ thống
        /// </summary>
        /// <returns>Danh sach ten nhat ky.</returns>
        public static List<string> DanhSachTenNhatKy()
        {
            return Context.DB.HT_NhatKies.Select(l => l.TenNhatKy).Distinct().ToList();
        }

        /// <summary>
        /// Danh sách Loại nhật ký tồn tại trong hệ thống
        /// </summary>
        /// <returns>Danh sach loai nhat ky.</returns>
        public static List<string> DanhSachLoaiNhatKy()
        {
            return Context.DB.HT_NhatKies.Select(l => l.LoaiNhatKy).Distinct().ToList();
        }

        /// <summary>
        /// Danh sách tất cả nhật ký
        /// </summary>
        /// <returns>Danh sach nhat ky.</returns>
        public static List<HT_NhatKy> DanhSachNhatKy()
        {
            return Context.DB.HT_NhatKies.ToList();
        }

        /// <summary>
        /// Danh sách nhật ký theo Tên nhật ký
        /// </summary>
        /// <returns>Danh sach nhat ky theo ten.</returns>
        /// <param name="TenNhatKy">Ten nhat ky.</param>
        public static List<HT_NhatKy> DanhSachNhatKyTheoTen(string TenNhatKy)
        {
            return Context.DB.HT_NhatKies.Where(l => l.TenNhatKy == TenNhatKy).ToList();
        }

        /// <summary>
        /// Danh sách nhật lý theo Loại nhật ký
        /// </summary>
        /// <returns>Danh sach nhat ky theo loai.</returns>
        /// <param name="LoaiNhatKy">Loai nhat ky.</param>
        public static List<HT_NhatKy> DanhSachNhatKyTheoLoai(string LoaiNhatKy)
        {
            return Context.DB.HT_NhatKies.Where(l => l.LoaiNhatKy == LoaiNhatKy).ToList();
        }

        /// <summary>
        /// Danh sách nhật ký theo ID Tài khoản
        /// </summary>
        /// <returns>Danh sach nhat ky theo tai khoan.</returns>
        /// <param name="IDTaiKhoan">ID Tai khoan.</param>
        public static List<HT_NhatKy> DanhSachNhatKyTheoTaiKhoan(long IDTaiKhoan)
        {
            return Context.DB.HT_NhatKies.Where(l => l.IDTaiKhoan == IDTaiKhoan).ToList();
        }

        /// <summary>
        /// Danh sách nhật ký trong khoảng thời gian
        /// </summary>
        /// <returns>Danh sach nhat ky theo khoang thoi gian.</returns>
        /// <param name="TuNgay">Tu ngay.</param>
        /// <param name="ToiNgay">Toi ngay.</param>
        public static List<HT_NhatKy> DanhSachNhatKyTrongKhoangThoiGian(DateTime TuNgay, DateTime ToiNgay)
        {
            return Context.DB.HT_NhatKies.Where(l => TuNgay <= l.ThoiGianTao && l.ThoiGianTao <= ToiNgay).ToList();
        }
    }
}
