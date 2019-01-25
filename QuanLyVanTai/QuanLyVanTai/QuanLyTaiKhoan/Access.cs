using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTaiKhoan
{
    public class Access
    {
        internal static HT_TaiKhoan SA
        {
            get
            {
                return Context.SA;
            }
        }

        protected static Dictionary<HT_TaiKhoan, DateTime> Session;

        static Access()
        {
            Session = new Dictionary<HT_TaiKhoan, DateTime>();
        }

        public static Access Login(string TaiKhoan, string MatKhau)
        {
            if (SA.TenTaiKhoan == TaiKhoan && SA.MatKhau == MatKhau)
            {
                return new Access(SA);
            }

            var TK = Context.DB.HT_TaiKhoans.FirstOrDefault(tk => tk.TenTaiKhoan == TaiKhoan && tk.MatKhau == MatKhau);

            if (TK != null)
            {
                return new Access(TK);
            }
            throw new UnauthorizedAccessException("Tài khoản không tồn tại.");
        }

        public readonly HT_TaiKhoan Self;

        public Access(HT_TaiKhoan TaiKhoan)
        {
            if (Session.ContainsKey(TaiKhoan) && DateTime.Now.Subtract(Session[TaiKhoan]).TotalMinutes < 5)
            {
                //throw new UnauthorizedAccessException("Tài khoản " + TaiKhoan.TenTaiKhoan + " đang đăng nhập ở nơi khác, vui lòng thử lại sau!");
            }
            else
            {
                Session.Remove(TaiKhoan);
                Session.Add(Self = TaiKhoan, DateTime.Now);
            }
        }

        ~Access()
        {
            Session.Remove(Self);
        }

        public void UpdateLastAccess()
        {
            Session[Self] = DateTime.Now;
        }

        public bool CoTheSua(HT_TaiKhoan TaiKhoanKhac)
        {
            if (TaiKhoanKhac.IDTaiKhoan != Self.IDTaiKhoan)
            {
                if (Self.IDTaiKhoan == SA.IDTaiKhoan)
                {
                    return true;
                }
                if (Self.IDSo == null && TaiKhoanKhac.IDSo != null)
                {
                    return true;
                }
                if (Self.IDSo != null && TaiKhoanKhac.IDSo != null)
                {
                    if (Self.IDSo == TaiKhoanKhac.IDSo && Self.IDBen == null && Self.IDDonViVanTai == null && (TaiKhoanKhac.IDBen != null || TaiKhoanKhac.IDDonViVanTai != null))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool CoTheSua(HT_TaiKhoan TaiKhoanKhac, bool ThrowException)
        {
            if (ThrowException && !CoTheSua(TaiKhoanKhac))
            {
                throw new MemberAccessException("Tài khoản không có đủ thẩm quyền.");
            }
            return CoTheSua(TaiKhoanKhac);
        }

        public HT_PhanQuyen ThemQuyenCho(HT_TaiKhoan TaiKhoanKhac, HT_Quyen Quyen)
        {
            CoTheSua(TaiKhoanKhac, true);
            var pq = new HT_PhanQuyen();
            pq.HT_TaiKhoan = TaiKhoanKhac;
            pq.HT_Quyen = Quyen;

            Context.DB.HT_PhanQuyens.InsertOnSubmit(pq);
            Context.DB.SubmitChanges();

            return pq;
        }

        public HT_PhanQuyen ThemQuyenCho(HT_TaiKhoan TaiKhoanKhac, string TenQuyen, string NhomQuyen)
        {
            CoTheSua(TaiKhoanKhac, true);
            var pq = new HT_PhanQuyen();
            pq.HT_TaiKhoan = TaiKhoanKhac;
            pq.HT_Quyen = Context.ThemQuyen(TenQuyen, NhomQuyen);

            Context.DB.HT_PhanQuyens.InsertOnSubmit(pq);
            Context.DB.SubmitChanges();

            return pq;
        }

        public HT_PhanQuyen XoaQuyenCho(HT_TaiKhoan TaiKhoanKhac, HT_Quyen Quyen)
        {
            CoTheSua(TaiKhoanKhac, true);
            var pq = Context.DB.HT_PhanQuyens.First(_pq => _pq.HT_TaiKhoan.IDTaiKhoan == TaiKhoanKhac.IDTaiKhoan && _pq.HT_Quyen.IDQuyen == Quyen.IDQuyen);
            if (pq != null)
            {
                Context.DB.HT_PhanQuyens.DeleteOnSubmit(pq);
                Context.DB.SubmitChanges();
            }

            return pq;
        }

        public List<HT_Quyen> DanhSachQuyenDuocPhep()
        {
            return Self.IDTaiKhoan == SA.IDTaiKhoan ? Context.DanhSachQuyen() : Context.DB.HT_PhanQuyens
                     .Where(
                           p =>
                                p.HT_TaiKhoan.IDTaiKhoan == Self.IDTaiKhoan
                          )
                     .Select(p => p.HT_Quyen)
                     .ToList();
        }

        public bool DuocPhep(HT_Quyen Quyen)
        {
            return Self.IDTaiKhoan == SA.IDTaiKhoan || Context.DB.HT_PhanQuyens
                     .Where(
                           p =>
                                p.HT_TaiKhoan.IDTaiKhoan == Self.IDTaiKhoan
                                &&
                                p.HT_Quyen.IDQuyen == Quyen.IDQuyen
                          )
                     .Select(p => p.HT_Quyen)
                     .Contains(Quyen);
        }

        public bool DuocPhep(string TenQuyen, string NhomQuyen)
        {
            return Self.IDTaiKhoan == SA.IDTaiKhoan || Context.DB.HT_PhanQuyens
                     .Where(
                           p =>
                               p.HT_TaiKhoan.IDTaiKhoan == Self.IDTaiKhoan
                               &&
                               p.HT_Quyen.TenQuyen == TenQuyen
                               &&
                               p.HT_Quyen.NhomQuyen == NhomQuyen
                          )
                      .Count() > 0;
        }

        public bool DuocPhep(string TenQuyen)
        {
            return DuocPhep(TenQuyen, Context.PERMISSION_DEFAULT_GROUP);
        }
    }


}