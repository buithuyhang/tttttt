using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace Test.Models.HomeHandlingData
{
    public class HomeHD
    {

        public HomeHD()
        {

        }

        public List<int> TocDoTangTruongTheoThang()
        {
            List<int> lis = new List<int>();
            QLVanTai_2017 dbc = new QLVanTai_2017();
            for (int i = 1; i <= DateTime.Now.Month; i++)
            {
                var SoLuong = dbc.QLVT_ThongTinXe.Where(ptr =>
                    (ptr.TX_NgayThemMoi.Value.Month <= i || ptr.TX_NgayThemMoi.Value.Year <= DateTime.Now.Year) && (ptr.TX_NgayNgungHoatDong.Value.Month >= i || ptr.TX_NgayNgungHoatDong.Value.Year >= DateTime.Now.Year)).ToList();
                lis.Add(SoLuong.Count);
            }
            return lis;
        }

        public List<int> TocDoTangTruongTheoNam()
        {
            List<int> lis = new List<int>();
            QLVanTai_2017 dbc = new QLVanTai_2017();
            for (int i = DateTime.Now.Year; i >= 2005; i--)
            {
                var SoLuong = dbc.QLVT_ThongTinXe.Where(ptr =>
                    ( ptr.TX_NgayThemMoi.Value.Year <= i) && (ptr.TX_NgayNgungHoatDong.Value.Year >= i)).ToList();
                lis.Add(SoLuong.Count);
            }
            return lis;
        }

        public List<int> TongLuotVanChuyenThucTe()
        {
            QLVanTai_2017 dbc = new QLVanTai_2017();
            List<int> lis = new List<int>();
            for (int item = 1; item <= DateTime.Now.Day; item++)
            {
                DateTime a = new DateTime(DateTime.Now.Year, DateTime.Now.Month, item);

                var temp = dbc.NhatTrinhXes.Where(ptr => EntityFunctions.TruncateTime(ptr.GioCapXuatBen) == a.Date && ptr.XeXepKhach.Value == true).ToList();
                lis.Add(temp.Count);
            }
            return lis;
        }

        public int TongLuotVanChuyenKeHoach()
        {
            QLVanTai_2017 dbc = new QLVanTai_2017();
            return Convert.ToInt32(dbc.QLVT_ThongTinXe_beta.Sum(ptr => ptr.TX_TanXuatNgay).Value); ;
        }

        public List<int> TanXuatXuatBen()
        {
            List<int> lis = new List<int>();
            QLVanTai_2017 dbc = new QLVanTai_2017();
            for (int i = 0; i < 24; i++)
            {
                var tem = dbc.NhatTrinhXes.Where(ptr => ptr.GioCapXuatBen.Value.Hour == i && ptr.GioCapXuatBen.Value.Day == DateTime.Now.Day && ptr.GioCapXuatBen.Value.Month == DateTime.Now.Month && ptr.GioCapXuatBen.Value.Year == DateTime.Now.Year).ToList();
                lis.Add(tem.Count);
            }
            return lis;
        }
    }
}