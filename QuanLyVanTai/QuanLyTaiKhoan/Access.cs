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

        public readonly string Nhom;

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
            if (Self.IDDonViVanTai != null)
            {
                Nhom = "DonViVanTai";
            }
            if (Self.IDBen != null)
            {
                Nhom = "Ben";
            }
            if (Self.IDSo == null)
            {
                Nhom = "So";
            }
            if (Self.IDTaiKhoan == SA.IDTaiKhoan)
            {
                Nhom = "TongCuc";
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
            bool b = CoTheSua(TaiKhoanKhac);
            if (ThrowException && !b)
            {
                throw new MemberAccessException("Tài khoản không có đủ thẩm quyền.");
            }
            return b;
        }

        public List<AccessType> ChildAccessType()
        {
            List<AccessType> ls = new List<AccessType>();

            if (Self.IDBen == null && Self.IDDonViVanTai == null)
            {
                ls.Add(AccessType.Ben);
                ls.Add(AccessType.DonViVanTai);
            }
            if (Self.IDSo == null)
            {
                ls.Add(AccessType.So);
            }
            if (Self.IDTaiKhoan == SA.IDTaiKhoan)
            {
                ls.Add(AccessType.TongCuc);
            }

            return ls;
        }

        public List<HT_Quyen> DanhSachQuyenDuocPhep()
        {
            return Self.IDTaiKhoan == SA.IDTaiKhoan ? Context.DanhSachQuyen() : Context.DB.HT_PhanQuyens
                     .Where(
                           p =>
                                p.Nhom == Nhom
                          )
                     .Select(p => p.HT_Quyen)
                     .ToList();
        }

        public bool DuocPhep(HT_Quyen Quyen)
        {
            return Self.IDTaiKhoan == SA.IDTaiKhoan || Context.DB.HT_PhanQuyens
                     .Where(
                           p =>
                                p.Nhom == Nhom
                                &&
                                p.HT_Quyen.IDQuyen == Quyen.IDQuyen
                          )
                     .Select(p => p.HT_Quyen)
                     .Contains(Quyen);
        }

        public bool DuocPhep(string Rule, string NhomQuyen)
        {
            return Self.IDTaiKhoan == SA.IDTaiKhoan || Context.DB.HT_PhanQuyens
                     .Where(
                           p =>
                               p.Nhom == Nhom
                               &&
                               p.HT_Quyen.Rule == Rule
                               &&
                               p.HT_Quyen.NhomQuyen == NhomQuyen
                          )
                      .Count() > 0;
        }

        public bool DuocPhep(string Rule)
        {
            return DuocPhep(Rule, Context.PERMISSION_DEFAULT_GROUP);
        }

        public void PhanQuyen (string Nhom, HT_Quyen Quyen)
        {
            Context.DB.HT_PhanQuyens.InsertOnSubmit(new HT_PhanQuyen()
            {
                Nhom = Nhom,
                IDQuyen = Quyen.IDQuyen
            });
            Context.DB.SubmitChanges();
        }

        public void PhanQuyen (string Nhom, long IDQuyen)
        {
            var quyen = Context.DB.HT_Quyens.FirstOrDefault(q => q.IDQuyen == IDQuyen);
            if (quyen != null)
            {
                PhanQuyen(Nhom, quyen);
            }
        }
        public void HuyPhanQuyen (string Nhom, long IDQuyen)
        {
            var quyen = Context.DB.HT_PhanQuyens.FirstOrDefault(q => q.IDQuyen == IDQuyen && q.Nhom == Nhom);
            if (quyen != null)
            {
                Context.DB.HT_PhanQuyens.DeleteOnSubmit(quyen);
                Context.DB.SubmitChanges();
            }
        }

        public enum AccessType
        {
            TongCuc, So, Ben, DonViVanTai
        }
    }


}