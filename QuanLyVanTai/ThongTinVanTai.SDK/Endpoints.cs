using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThongTinVanTai.SDK
{
    internal static class Endpoints
    {
        static string _(string path)
        {
            return new UriBuilder(SCHEME, HOST, PORT, path).Uri.AbsoluteUri;
            //return new UriBuilder("http", "192.168.1.132", 80, "TramTiepNhan/" + path.Trim(" /".ToCharArray())).Uri.AbsoluteUri;
        }
        const string SCHEME = "HTTP";
        const string HOST = "192.168.10.90";
        const int PORT = 80;
        public static string Home = _("");
        public static string Ping = _("Ping");
        public static string XeXuatBen = _("BenXe/XeXuatBen");
        public static string XeDenBen = _("BenXe/XeDenBen");
    }
}
