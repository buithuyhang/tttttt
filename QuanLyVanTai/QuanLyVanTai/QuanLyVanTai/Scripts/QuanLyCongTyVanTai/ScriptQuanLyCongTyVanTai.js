var record = 0;
function CreateGridTTCongTyVanTai() {
    $("#gridTTCongTyVanTai").kendoGrid({
        dataSource: {
            data: [],
            pageSize: 20
        },
        selectable: "row",
        title: "Thông tin công ty vận tải",
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
            field: "TenCongTy",
            title: "Tên công ty",
            width: 200,
            headerAttributes: {
                "class": "table-header-cell",
                style:
                    "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        }, {
            field: "SoLuongXe",
            title: "Số lượng xe",
            width: 60,
            headerAttributes: {
                "class": "table-header-cell",
                style:
                    "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        }, {
            field: "TenTinhSo",
            title: "Sở giao thông",
            width: 100,
            headerAttributes: {
                "class": "table-header-cell",
                style:
                    "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        }, {
        field: "DiaChi",
        title: "Địa chỉ",
        width: 300,
        headerAttributes: {
            "class": "table-header-cell",
            style:
                "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
        }
    }]
    });
};