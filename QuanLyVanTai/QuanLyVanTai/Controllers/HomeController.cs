using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;
using Test.Models.HomeHandlingData;

namespace Test.Controllers
{
    public class HomeController : Controller
    {

        public class GraphData
        {
            public string label { get; set; }
            public int ThucTe { get; set; }
            public int KeHoach { get; set; }
            public int TangTruong { get; set; }
            public int KoThucHien { get; set; }
            public GraphData(string label, int value1, int value2)
            {
                this.label = label;
                this.ThucTe = value1;
                this.KeHoach = value2;
                this.KoThucHien = this.KeHoach - this.ThucTe;
            }

            public GraphData(string label, int value1)
            {
                this.label = label;
                this.TangTruong = value1;
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetDataTongLuotVanChuyen()
        {
            List<GraphData> GraphDataList = new List<GraphData>();
            HomeHD hd = new HomeHD();
            int kehoach = hd.TongLuotVanChuyenKeHoach();
            List<int> lis = hd.TongLuotVanChuyenThucTe();
            for (int i = 1; i <= DateTime.Now.Day; i++)
            {
                GraphDataList.Add(new GraphData("Ngày " + i + "/" + DateTime.Now.Month, lis[i - 1], kehoach));
            }
            return Json(GraphDataList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDataTocDoTangTruongTheoThang()
        {
            List<GraphData> GraphDataList = new List<GraphData>();
            HomeHD hd = new HomeHD();
            List<int> lis = hd.TocDoTangTruongTheoThang();
            for (int i = 1; i <= DateTime.Now.Month; i++)
            {
                GraphDataList.Add(new GraphData("Tháng " + i + "/" + DateTime.Now.Year, lis[i - 1]));
            }
            return Json(GraphDataList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDataTocDoTangTruongTheoNam()
        {
            List<GraphData> GraphDataList = new List<GraphData>();
            HomeHD hd = new HomeHD();
            List<int> lis = hd.TocDoTangTruongTheoNam();
            for (int i = lis.Count-1; i >= 0; i--)
            {
                GraphDataList.Add(new GraphData("Năm " + (DateTime.Now.Year - i), lis[i]));
            }
            return Json(GraphDataList, JsonRequestBehavior.AllowGet);
        }

        public class dataTemp
        {
            public string label { get; private set; }
            public int value { get; private set; }

            public dataTemp(string label, int value)
            {
                this.label = label;
                this.value = value;
            }
        }

        public ActionResult GetDataKhongThucHien()
        {
            HomeHD hd = new HomeHD();
            int kehoach = hd.TongLuotVanChuyenKeHoach();
            List<int> lis = hd.TongLuotVanChuyenThucTe();
            int KhongThucHien = 0;
            int TongKeHoach = 0;
            List<dataTemp> lisO = new List<dataTemp>();
            for (int i = 1; i <= DateTime.Now.Day; i++)
            {
                KhongThucHien += kehoach - lis[i - 1];
                TongKeHoach += kehoach;
            }
            lisO.Add(new dataTemp("Thực hiện", TongKeHoach));
            lisO.Add(new dataTemp("Không thực hiện", KhongThucHien));
            return Json(lisO, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDataTanXuatXuatBenTrenGio()
        {
            HomeHD hd = new HomeHD();
            List<int> lis = hd.TanXuatXuatBen();
            List<dataTemp> lisO = new List<dataTemp>();
            for (int i = 0; i < 24; i++)
            {
                lisO.Add(new dataTemp(i + " Giờ", lis[i]));
            }   

            return Json(lisO, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}