using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThongTinVanTai.Data
{
    public class ThongTinXeDenBen
    {
        /// <summary>
        /// Biển số xe theo định dạng 00A-0000 hoặc 00A-00000
        /// </summary>
        [DisplayName("Biển số xe")]
        public string BienSoXe { get; set; }

        /// <summary>
        /// Mã luồng tuyến theo định dạng 0000.0000.A
        /// </summary>
        [DisplayName("Mã luồng tuyến")]
        public string MaLuongTuyen { get; set; }

        /// <summary>
        /// Mã số thuế đơn vị vận tải quản lý xe
        /// </summary>
        [DisplayName("Mã số thuế đơn vị vận tải")]
        public string MaSoThueDonViVanTai { get; set; }

        /// <summary>
        /// Giờ đến bến
        /// </summary>
        [DisplayName("Giờ đến bến")]
        public TimeSpan GioDenBen { get; set; }

        [DisplayName("Ghi chú")]
        public string GhiChu { get; set; } = "";
    }
}
