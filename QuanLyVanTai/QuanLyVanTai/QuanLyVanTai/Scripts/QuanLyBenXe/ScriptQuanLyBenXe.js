var record = 0;
function CreateGridTTBenXe() {
    $("#gridTTBenXe").kendoGrid({
        dataSource: {
            data: [],
            pageSize: 20
        },
        selectable: "row",
        title: "Thông tin bến xe",
        height: 450,
        sortable: true,
        pageable: {
            //refresh: true,
            pageSizes: true,
            //buttonCount: 5
            numeric: true,
            info: false
        }, dataBinding: function () {
            record = 0;
            //$('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe);
        },
        columns: [{
            title: "STT",
            template: "#= ++record #",
            width: 45,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        }, {
            field: "MaBen",
            title: "Mã bến xe",
            width: 100,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        }, {
            field: "TenBenXe",
            title: "Tên bến xe",
            width: 200,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        }, {
            field: "TenTinhSo",
            title: "Tỉnh sở",
            width: 150,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        }, {
            field: "CoQuanQuanLy",
            title: "Cơ quan quản lý",
            width: 200,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        }, {
            field: "TongDienTich",
            title: "Tổng diện tích",
            width: 70,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        }, {
            field: "DienTich_XeKhach",
            title: "Diện tích xe khách",
            width: 70,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        }, {
            field: "DienTich_PhuongTienKhac",
            title: "Diện tích phương tiện khác",
            width: 70,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        }, {
            field: "DienTich_NhaCho",
            title: "Diện tích nhà chờ",
            width: 70,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        }, {
            field: "LoaiBenXe",
            title: "Loại bến xe",
            width: 70,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        }, {
            field: "SoTuyenQuyHoach",
            title: "Số tuyến quy hoạch",
            width: 70,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        }, {
            field: "SoLuotXuatBenQuyHoach",
            title: "Số lượng xuất bến quy hoạch",
            width: 70,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        }, {
            field: "SDT",
            title: "Số điện thoại",
            width: 120,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        }, {
            field: "DiaChi",
            title: "Địa chỉ",
            width: 300,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        }, {
            field: "TrangThai",
            title: "Trạng thái",
            width: 130,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        }, {
            field: "GhiChu",
            title: "Ghi chú",
            width: 350,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        }]
    });
};