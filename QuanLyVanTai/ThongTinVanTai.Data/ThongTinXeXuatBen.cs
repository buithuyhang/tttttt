using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ThongTinVanTai.Data
{
    public class ThongTinXeXuatBen
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
        /// Giờ vào bến
        /// </summary>
        [DisplayName("Giờ vào bến")]
        public TimeSpan GioVaoBen { get; set; }

        /// <summary>
        /// Giờ xuất bến trên kế hoạch
        /// </summary>
        [DisplayName("Giờ xuất bến kế hoạch")]
        public TimeSpan GioXuatBenKeHoach { get; set; }

        /// <summary>
        /// Giờ cấp xuất bến
        /// </summary>
        [DisplayName("Giờ cấp xuất bến")]
        public TimeSpan GioCapXuatBen { get; set; }

        /// <summary>
        /// Giờ xuất bến thực tế của xe
        /// </summary>
        [DisplayName("Giờ xuất bến thực tế")]
        [Required()]
        public TimeSpan GioXuatBen { get; set; }

        /// <summary>
        /// Số khách thực tế khi xe xuất bến
        /// </summary>
        [DisplayName("Số khách")]
        public int SoKhach { get; set; } = 0;

        /// <summary>
        /// Là xe vào nốt xếp khách
        /// </summary>
        [DisplayName("Xe xếp khách")]
        public bool XeXepKhach { get; set; } = false;

        /// <summary>
        /// Là xe không đủ điều kiện
        /// </summary>
        [DisplayName("Xe không đủ điều kiện")]
        public bool XeKhongDuDieuKien { get; set; } = false;

        /// <summary>
        /// Là xe về đơn vị vận tải
        /// </summary>
        [DisplayName("Xe về đơn vị vận tải")]
        public bool XeVeDonViVanTai { get; set; } = false;

        /// <summary>
        /// Là xe chạy lệnh tăng cường
        /// </summary>
        [DisplayName("Xe tăng cường")]
        public bool XeTangCuong { get; set; } = false;

        /// <summary>
        /// Ghi chú thêm các thông tin như lý do vào muộn, lý do không đủ điều kiện,...
        /// </summary>
        [DisplayName("Ghi chú")]
        public string GhiChu { get; set; } = "";
    }
}
