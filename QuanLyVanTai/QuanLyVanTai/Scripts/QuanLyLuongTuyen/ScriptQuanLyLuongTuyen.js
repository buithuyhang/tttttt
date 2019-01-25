var record = 0;
function CreateGridTTLuongTuyen() {
    $("#gridTTLuongTuyen").kendoGrid({
        dataSource: {
            data: [],
            pageSize: 20
        },
        selectable: "row",
        title: "Thông tin luồng tuyến",
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
            field: "LT_MaTuyen",
            title: "Mã tuyến",
            width: 110,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        }, {
            field: "LT_DC_TenBen_01",
            title: "Bến đi",
            width: 250,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        }, {
            field: "LT_DC_TenBen_02",
            title: "Bến đến",
            width: 250,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        }, {
            field: "LT_HanhTrinhChay",
            title: "Hành trình chạy",
            width: 350,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        }, {
            field: "LT_CuLy",
            title: "Cự ly",
            width: 80,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        }, {
            field: "LT_LuuLuongQuyDinh",
            title: "Lưu lượng QH",
            width: 80,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        }, {
            field: "PhanLoaiLuongTuyen",
            title: "Phân loại QH",
            width: 150,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        }, {
            field: "GhiChu",
            title: "Ghi chú",
            width: 150,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        }, {
            field: "TrangThaiTuyen",
            title: "Trạng thái",
            width: 190,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        }]
    });
};

function CreateGridTinhSoLuongTuyen() {
    $("#gridTinhSoLuongTuyen").kendoGrid({
        selectable: "row",
        height: 450,
        sortable: true,
        pageable: false,
        change: function (e) {
            setdataGridLuongTuyen("gridTTLuongTuyen")
        },
        //pageable: {
        //    //refresh: true,
        //    pageSizes: false,
        //    //buttonCount: 5
        //    numeric: false,
        //    info: false
    //},
        columns: [{
        //    title: "STT",
        //    template: "#= ++record #",
        //    width: 45,
        //    headerAttributes: {
        //        "class": "table-header-cell",
        //        style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
        //    }
        //}, {
            field: "TS_TenTinh",
            title: "Tên sở",
            width: 110,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        }]
    });
};