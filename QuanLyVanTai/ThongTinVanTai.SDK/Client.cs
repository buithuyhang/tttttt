using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ThongTinVanTai.Data;

namespace ThongTinVanTai.SDK
{
    public class Client
    {
        public static Client Current { get; private set; }

        private string _MaUngDung;
        private string _MaBiMat;

        private string AccessToken = "";

        public Client(string MaUngDung, string MaBiMat)
        {
            _MaUngDung = MaUngDung;
            _MaBiMat = MaBiMat;
        }

        protected string Get(string url)
        {
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }

        protected string Post(string url, string json)
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            byte[] byteArray = Encoding.UTF8.GetBytes(json);
            request.ContentType = "application/json";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }

        protected string Post(string url, object obj)
        {
            return Post(url, Newtonsoft.Json.JsonConvert.SerializeObject(obj));
        }

        public string Ping()
        {
            return this.Get(Endpoints.Ping);
        }

        public bool XeXuatBen(string BienSoXe, string MaLuongTuyen, string MaSoThueDonViVanTai, TimeSpan GioVaoBen, TimeSpan GioXuatBenKeHoach, TimeSpan GioCapXuatBen, TimeSpan GioXuatBen, int SoKhach, bool XeXepKhach, bool XeKhongDuDieuKien, bool XeTangCuong, bool XeVeDonViVanTai, string GhiChu)
        {
            try
            {
                return "true" == this.Post(Endpoints.XeXuatBen, new ThongTinXeXuatBen()
                {
                    BienSoXe = BienSoXe,
                    MaLuongTuyen = MaLuongTuyen,
                    MaSoThueDonViVanTai = MaSoThueDonViVanTai,
                    GioVaoBen = GioVaoBen,
                    GioXuatBenKeHoach = GioXuatBenKeHoach,
                    GioCapXuatBen = GioCapXuatBen,
                    GioXuatBen = GioXuatBen,
                    SoKhach = SoKhach,
                    XeXepKhach = XeXepKhach,
                    XeKhongDuDieuKien = XeKhongDuDieuKien,
                    XeTangCuong = XeTangCuong,
                    XeVeDonViVanTai = XeVeDonViVanTai,
                    GhiChu = GhiChu
                });
            }
            catch
            {
                return false;
            }
        }

        public bool XeDenBen(string BienSoXe, string MaLuongTuyen, string MaSoThueDonViVanTai, TimeSpan GioDenBen, string GhiChu)
        {
            try
            {
                return "true" == this.Post(Endpoints.XeDenBen, new ThongTinXeDenBen()
                {
                    BienSoXe = BienSoXe,
                    MaLuongTuyen = MaLuongTuyen,
                    MaSoThueDonViVanTai = MaSoThueDonViVanTai,
                    GioDenBen = GioDenBen,
                    GhiChu = GhiChu
                });
            }
            catch
            {
                return false;
            }
        }
    }
}
