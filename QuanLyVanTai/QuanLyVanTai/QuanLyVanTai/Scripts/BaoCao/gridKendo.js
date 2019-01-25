/*=================================================================================================================================*/
function setOptionSelect(id, data, select, idItem, txtItem, search) {
    data = $.map(data, function (item) {
        console.log(item)
        return { id: item[idItem], text: item[txtItem] }
    });

    $("#" + id).select2({
        placeholder: "Chọn",
        allowClear: true,
        //formatSelection: format,
        //formatResult: format,
        language: 'vi',
        data: data,
        theme: 'bootstrap',
        containerCssClass: ":all:",
        width: "100%"
    });
    $("#" + id).select2('val', data[select]);
}
/*=================================================================================================================================*/
//Lấy dữ liệu của url
var getUrlParameter = function getUrlParameter(sParam) {
    var sPageURL = decodeURIComponent(window.location.search.substring(1)),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? true : sParameterName[1];
        }
    }
};
/*=================================================================================================================================*/
//Panel Title
function Panel_Title(id, title1, title2) {
    var ttt = "#" + id;
    $(ttt).html(title1 + ' - <span style = "color: red;">' + title2 + '</span>');
}
/*=================================================================================================================================*/
//Chỉnh Vị Trí Trang
function Chinh_Location(id, id1, id2, id3, id4) {
    var ttt = "#" + id;
    var ttt1 = "#" + id1;
    var ttt2 = "#" + id2;
    var ttt3 = "#" + id3;
    var ttt4 = "#" + id4;

    var PhanNoiDung_Cao = $(window).height() - $(".navbar-fixed-top").height();
    var PhanNoiDung_Rong = $(window).width();
    var phanCao_Blank = PhanNoiDung_Cao / 5 + $(".navbar-fixed-top").height();
    var phanRong_Blank = PhanNoiDung_Rong * 3 / 10;

    var cao_tong = PhanNoiDung_Cao * 2 / 3;
    var rong_tong = PhanNoiDung_Rong * 2 / 5;
    $(ttt).height(cao_tong);
    $(ttt).width(rong_tong);
    $(ttt).css({ "top": phanCao_Blank + "px", "left": phanRong_Blank + "px" });

    var cao_id1 = (PhanNoiDung_Cao * 2 / 3) * 1 / 4;
    $(ttt1).height(cao_id1);
    $(ttt1).width(rong_tong);
    $(ttt1).css({ "top": 0 + "px", "left": -1 + "px" });


    $(ttt2).height(cao_tong - cao_id1);
    $(ttt2).width(rong_tong);
    $(ttt2).css({ "top": cao_id1 + "px", "left": -1 + "px" });

    $(ttt3).height(cao_id1);
    $(ttt3).width(rong_tong);
    $(ttt3).css({ "top": 0 + "px", "left": -1 + "px" });

    $(ttt4).height(cao_tong - cao_id1);
    $(ttt4).width(rong_tong);
    $(ttt4).css({ "top": cao_id1 + "px", "left": -1 + "px" });
}
/*=======================================================CheckBox DropDownList==========================================================================*/
var IsItemChecked = false;
function UpdateIdinHF(obj) {
    var id = $(obj).attr('id');
    var name = $(obj).attr('name');
    var value = parseInt($(obj).attr('value'));
    var IsChecked = $(obj).is(':checked');
    var hf = $("#hf_" + name).get(0);

    if (value != -1) {
        UpdateIdInHiddenField(hf, value, IsChecked);

        var totalchk = $('input[id*="chk_' + name + '"]').not("#chk_" + name + "_0").length;
        var checkedchk = $('input[id*="chk_' + name + '"]:checked').not("#chk_" + name + "_0").length;

        if (totalchk == checkedchk) {
            $("#chk_" + name + "_0").prop("checked", true);
        }
        else {
            $("#chk_" + name + "_0").prop("checked", false);
        }
    }
    else {
        $('input[id*="chk_' + name + '"]').each(function () {
            if (parseInt($(this).val()) != 0) {
                if (IsChecked == true) {
                    $(this).prop("checked", true);
                    UpdateIdInHiddenField(hf, $(this).val(), IsChecked);
                }
                else {
                    $(this).prop("checked", false);
                    UpdateIdInHiddenField(hf, $(this).val(), IsChecked);
                }
            }
        });
    }
    IsItemChecked = true;
}
function onClose(e) {
    if (IsItemChecked == true) {
        IsItemChecked = false;
        e.preventDefault();
    }
    else {
        ShowSelectedItem();
    }
}
function ShowSelectedItem() {
    var tt = $("#hf_fabric").val().split(",");
    if (tt != "") {
        if (tt.indexOf("-1") > -1) {
            console.log(tt);
            $("#spanfabric").html(tt.length - 3);
        } else {
            console.log(tt);
            $("#spanfabric").html(tt.length - 2);
        };
    }
    //$("#spanfabric").html($("#hf_fabric").val());
}
function UpdateIdInHiddenField(hf, id, IsAdd) {
    if (hf.value == "") {
        hf.value = ",";
    }

    if (IsAdd == true) {
        if (hf.value.indexOf("," + id + ",") == -1) {
            hf.value = hf.value + id + ",";
        }
    }
    else if (IsAdd == false) {
        if (hf.value.indexOf("," + id + ",") >= 0) {
            hf.value = hf.value.replace("," + id + ",", ",");
        }
    }
}
function onChange(e) {
    e.sender.value(e.value);
}
/*==============================================Remove items per page===================================================================================*/
function removeitemperpage() {
    $(".k-pager-sizes")
    .contents()
    .filter(function () {
        return this.nodeType === 3;
    }).remove();
};
/*=================================================================================================================================*/
var otherElementsHeightThongTinXe = $("#body_dau").height() + $(".navbar-fixed-top").height() + 200;
//BÁO CÁO HOẠT ĐỘNG ==>
//BÁO CÁO TỔNG HỢP
function BaoCaoHoatDong_BaoCaoTongHop_BaoCaoToanQuoc(id, data) {
    var ttt = "#" + id;
    $(ttt).kendoGrid({
        sortable: true,
        selectable: "row",
        scrollable: true,
        //height: 380,
        dataSource: {
            data: data,
            pageSize: 25
        },
        pageable: {
            pageSizes: true,
            //input: true,
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TS_TenTinh",
                title: "TỈNH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                },
                template: '<a target="_blank" href="#=URL#">#=TS_TenTinh#</a>',
                attributes: { style: "text-align: left;" }
            },
            {
                field: "SoChuenDangKy",
                title: "SỐ CHUYẾN ĐĂNG KÝ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "SoLuotXuatBen",
                title: "SỐ LƯỢT XUẤT BẾN",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "SoLuotKhach",
                title: "SỐ KHÁCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TyLeThucHien",
                title: "TỶ LỆ THỰC HIỆN (%)",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            }
        ]
    })
}; //fix toanquoc
function BaoCaoHoatDong_BaoCaoTongHop_BaoCaoSo(id, data) {
    var ttt = "#" + id;
    $(ttt).kendoGrid({
        sortable: true,
        selectable: "row",
        scrollable: true,
        //height: 380,
        dataSource: {
            data: data,
            pageSize: 25
        },
        pageable: {
            pageSizes: [10, 25, 50, 100, 150, 200, "all"],
            //input: true,
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TenTuyen",
                title: "TUYẾN VẬN TẢI",
                width: 250,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                },
                template: '<a target="_blank" href="#=URL#">#=TenTuyen#</a>',
                attributes: { style: "text-align: left;" }
            },
            {
                field: "SoChuyenKeHoach",
                title: "SỐ CHUYẾN KẾ HOẠCH",
                width: 50,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "SoChuyenThucHien",
                title: "SỐ CHUYẾN THỰC HIỆN",
                width: 50,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "SoLuotKhach",
                title: "SỐ KHÁCH",
                width: 50,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TyLeXuatBen",
                title: "TỶ LỆ (%)",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            }
        ]
    })
}; //fix so
function BaoCaoHoatDong_BaoCaoTongHop_BaoCaoTuyen(id, data) {
    var ttt = "#" + id;
    $(ttt).kendoGrid({
        sortable: true,
        selectable: "row",
        scrollable: true,
        //height: 380,
        dataSource: {
            data: data,
            pageSize: 25
        },
        pageable: {
            pageSizes: [10, 25, 50, 100, 150, 200, "all"],
            ////input: true,
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TenCongTy",
                title: "ĐƠN VỊ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                },
                template: '<a target="_blank" href="#=URL#">#=TenCongTy#</a>',
                attributes: { style: "text-align: left;" }
            },
            {
                field: "TongLuotXuatBen",
                title: "SỐ CHUYẾN KẾ HOẠCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "SoLuotXuatBen",
                title: "SỐ CHUYẾN THỰC CHẠY",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "SoLuotKhach",
                title: "SỐ KHÁCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TyLeXuatBen",
                title: "TỈ LỆ (%)",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            }
        ]
    })
}; //fix tuyen
function BaoCaoHoatDong_BaoCaoTongHop_BaoCaoDonViVanTai(id, data) {
    var ttt = "#" + id;
    $(ttt).kendoGrid({
        sortable: true,
        selectable: "row",
        scrollable: true,
        //height: 380,
        dataSource: {
            data: data,
            pageSize: 25
        },
        pageable: {
            pageSizes: [10, 25, 50, 100, 150, 200, "all"],
            ////input: true,
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TX_BienSoXe",
                title: "BIỂN SỐ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                },
                template: '<a target="_blank" href="#=URL#">#=TX_BienSoXe#</a>',
                attributes: { style: "text-align: left;" }
            },
            {
                field: "TaiTrong",
                title: "TẢI TRỌNG",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TX_BX_TongLuotVanChuyen",
                title: "SỐ CHUYẾN KẾ HOẠCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "SoLuotXuatBen",
                title: "SỐ CHUYẾN THỰC CHẠY",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "SoLuotKhach",
                title: "SỐ KHÁCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TyLeVanChuyen",
                title: "TỶ LỆ (%)",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            }
        ]
    })
}; //fix dvvt
function BaoCaoHoatDong_BaoCaoTongHop_BaoCaoBen(id, data) {
    var ttt = "#" + id;
    $(ttt).kendoGrid({
        sortable: true,
        selectable: "row",
        scrollable: true,
        //height: 380,
        dataSource: {
            data: data,
            pageSize: 25
        },
        pageable: {
            pageSizes: [10, 25, 50, 100, 150, 200, "all"],
            ////input: true,
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TX_BienSoXe",
                title: "BIỂN SỐ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "BienSoDi",
                title: "BIỂN SỐ RA",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "GioXuatBenKeHoach",
                title: "GIỜ KẾ HOẠCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "GioRaBen",
                title: "GIỜ THỰC TẾ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "SoKhach",
                title: "SỐ KHÁCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "GhiChu",
                title: "GHI CHÚ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            }
        ]
    })
}; //fix ben
//BÁO CÁO XE KHÔNG THỰC HIỆN
function BaoCaoHoatDong_BaoCaoXeKhongThucHien_BaoCaoToanQuoc(id, data) {
    var ttt = "#" + id;
    $(ttt).kendoGrid({
        sortable: true,
        selectable: "row",
        scrollable: true,
        //height: 380,
        dataSource: {
            data: data,
            pageSize: 25
        },
        pageable: {
            pageSizes: [10, 25, 50, 100, 150, 200, "all"],
            ////input: true,
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TS_TenTinh",
                title: "TUYẾN VẬN TẢI",
                width: 150,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                },
                template: '<a target="_blank" href="#=URL#">#=TS_TenTinh#</a>',
                attributes: { style: "text-align: left;" }
            },
            {
                field: "SoChuenDangKy",
                title: "SỐ XE ĐĂNG KÝ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "SoChuyenKhongThucHien",
                title: "SỐ CHUYẾN KHÔNG THỰC HIỆN",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TyLeKhongThucHien",
                title: "TỶ LỆ (%)",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            }
        ]
    })
}; //fix toanquoc 
function BaoCaoHoatDong_BaoCaoXeKhongThucHien_BaoCaoSo(id, data) {
    var ttt = "#" + id;
    $(ttt).kendoGrid({
        sortable: true,
        selectable: "row",
        scrollable: true,
        //height: 380,
        dataSource: {
            data: data,
            pageSize: 25
        },
        pageable: {
            pageSizes: [10, 25, 50, 100, 150, 200, "all"],
            ////input: true,
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TenTuyen",
                title: "TUYẾN VẬN TẢI",
                width: 200,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                },
                template: '<a target="_blank" href="#=URL#">#=TenTuyen#</a>',
                attributes: { style: "text-align: left;" }
            },
            {
                field: "SoChuyenKeHoach",
                title: "SỐ CHUYẾN KẾ HOẠCH",
                width: 50,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "SoChuyenKhongThucHien",
                title: "SỐ CHUYẾN KHÔNG THỰC HIỆN",
                width: 50,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TyLeKhongXuatBen",
                title: "TỶ LỆ KHÔNG THỰC HIỆN (%)",
                width: 50,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            }
        ]
    })
}; //fix so
function BaoCaoHoatDong_BaoCaoXeKhongThucHien_BaoCaoTuyen(id, data) {
    var ttt = "#" + id;
    $(ttt).kendoGrid({
        sortable: true,
        selectable: "row",
        scrollable: true,
        //height: 380,
        dataSource: {
            data: data,
            pageSize: 25
        },
        pageable: {
            pageSizes: [10, 25, 50, 100, 150, 200, "all"],
            ////input: true,
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TenCongTy",
                title: "ĐƠN VỊ",
                width: 150,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                },
                template: '<a target="_blank" href="#=URL#">#=TenCongTy#</a>',
                attributes: { style: "text-align: left;" }
            },
            {
                field: "SoLuotXuatBenKeHoach",
                title: "SỐ XE KẾ HOẠCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "SoLuotKhongXuatBen",
                title: "SỐ XE KHÔNG CHẠY",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TyLeKhongXuatBen",
                title: "TỈ LỆ (%)",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            }
        ]
    })
}; //fix tuyen
function BaoCaoHoatDong_BaoCaoXeKhongThucHien_BaoCaoDonViVanTai(id, data) {
    var ttt = "#" + id;
    $(ttt).kendoGrid({
        sortable: true,
        selectable: "row",
        scrollable: true,
        //height: 380,
        dataSource: {
            data: data,
            pageSize: 25
        },
        pageable: {
            pageSizes: [10, 25, 50, 100, 150, 200, "all"],
            ////input: true,
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TX_BienSoXe",
                title: "BIỂN SỐ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                },
                template: '<a target="_blank" href="#=URL#">#=TX_BienSoXe#</a>',
                attributes: { style: "text-align: left;" }
            },
            {
                field: "TaiTrong",
                title: "TẢI TRỌNG",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TX_BX_TongLuotVanChuyen",
                title: "SỐ CHUYẾN KẾ HOẠCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "SoLuotKhongXuatBen",
                title: "SỐ KHÔNG XUẤT BẾN THỰC CHẠY",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TyLeVanChuyen",
                title: "TỶ LỆ (%)",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            }
        ]
    })
}; //fix dvvt
function BaoCaoHoatDong_BaoCaoXeKhongThucHien_BaoCaoBen(id, data) {
    var ttt = "#" + id;
    $(ttt).kendoGrid({
        sortable: true,
        selectable: "row",
        scrollable: true,
        //height: 380,
        dataSource: {
            data: data,
            pageSize: 25
        },
        pageable: {
            pageSizes: [10, 25, 50, 100, 150, 200, "all"],
            ////input: true,
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TX_BienSoXe",
                title: "BIỂN SỐ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "GioXuatBenKeHoach",
                title: "GIỜ KẾ HOẠCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "GioRaBen",
                title: "GIỜ THỰC TẾ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "SoKhach",
                title: "SỐ KHÁCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "GhiChu",
                title: "GHI CHÚ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            }
        ]
    })
}; //fix ben
//BÁO CÁO XE CHẠY KHÔNG ĐÚNG GIỜ
function BaoCaoHoatDong_BaoCaoXeKhongDungGio_BaoCaoToanQuoc(id, data) {
    var ttt = "#" + id;
    $(ttt).kendoGrid({
        sortable: true,
        selectable: "row",
        scrollable: true,
        //height: 380,
        dataSource: {
            data: data,
            pageSize: 25
        },
        pageable: {
            pageSizes: [10, 25, 50, 100, 150, 200, "all"],
            //input: true,
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TS_TenTinh",
                title: "TỈNH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                },
                template: '<a target="_blank" href="#=URL#">#=TS_TenTinh#</a>',
                attributes: { style: "text-align: left;" }
            },
            {
                field: "SoChuenDangKy",
                title: "SỐ CHUYẾN ĐĂNG KÝ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "SoLuotXuatBen",
                title: "SỐ LƯỢT XUẤT BẾN",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "SoLuotKhach",
                title: "SỐ KHÁCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TyLeThucHien",
                title: "TỶ LỆ THỰC HIỆN (%)",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            }
        ]
    })
}; //fix toanquoc
function BaoCaoHoatDong_BaoCaoXeKhongDungGio_BaoCaoSo(id, data) {
    var ttt = "#" + id;
    $(ttt).kendoGrid({
        sortable: true,
        selectable: "row",
        scrollable: true,
        //height: 380,
        dataSource: {
            data: data,
            pageSize: 25
        },
        pageable: {
            pageSizes: [10, 25, 50, 100, 150, 200, "all"],
            //input: true,
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TenTuyen",
                title: "TUYẾN VẬN TẢI",
                width: 250,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                },
                template: '<a target="_blank" href="#=URL#">#=TenTuyen#</a>',
                attributes: { style: "text-align: left;" }
            },
            {
                field: "SoChuyenKeHoach",
                title: "SỐ CHUYẾN KẾ HOẠCH",
                width: 50,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "SoChuyenThucHien",
                title: "SỐ CHUYẾN THỰC CHẠY",
                width: 50,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "SoLuotKhach",
                title: "SỐ KHÁCH",
                width: 50,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TyLeXuatBen",
                title: "TỶ LỆ (%)",
                width: 50,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            }
        ]
    })
}; //fix so
function BaoCaoHoatDong_BaoCaoXeKhongDungGio_BaoCaoTuyen(id, data) {
    var ttt = "#" + id;
    $(ttt).kendoGrid({
        sortable: true,
        selectable: "row",
        scrollable: true,
        //height: 380,
        dataSource: {
            data: data,
            pageSize: 25
        },
        pageable: {
            pageSizes: [10, 25, 50, 100, 150, 200, "all"],
            //input: true,
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TenCongTy",
                title: "ĐƠN VỊ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                },
                template: '<a target="_blank" href="#=URL#">#=TenCongTy#</a>',
                attributes: { style: "text-align: left;" }
            },
            {
                field: "TongLuotXuatBen",
                title: "SỐ CHUYẾN KẾ HOẠCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "SoLuotXuatBen",
                title: "SỐ CHUYẾN THỰC CHẠY",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "SoLuotKhach",
                title: "SỐ KHÁCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TyLeXuatBen",
                title: "TỈ LỆ (%)",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            }
        ]
    })
}; //fix tuyen
function BaoCaoHoatDong_BaoCaoXeKhongDungGio_BaoCaoDonViVanTai(id, data) {
    var ttt = "#" + id;
    $(ttt).kendoGrid({
        sortable: true,
        selectable: "row",
        scrollable: true,
        //height: 380,
        dataSource: {
            data: data,
            pageSize: 25
        },
        pageable: {
            pageSizes: [10, 25, 50, 100, 150, 200, "all"],
            //input: true,
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TX_BienSoXe",
                title: "BIỂN SỐ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                },
                template: '<a target="_blank" href="#=URL#">#=TX_BienSoXe#</a>',
                attributes: { style: "text-align: left;" }
            },
            {
                field: "TaiTrong",
                title: "TẢI TRỌNG",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TX_BX_TongLuotVanChuyen",
                title: "SỐ CHUYẾN KẾ HOẠCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "SoLuotXuatBen",
                title: "SỐ CHUYẾN THỰC CHẠY",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "SoLuotKhach",
                title: "SỐ KHÁCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TyLeVanChuyen",
                title: "TỶ LỆ (%)",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            }
        ]
    })
}; //fix dvvt
function BaoCaoHoatDong_BaoCaoXeKhongDungGio_BaoCaoBen(id, data) {
    var ttt = "#" + id;
    $(ttt).kendoGrid({
        sortable: true,
        selectable: "row",
        scrollable: true,
        //height: 380,
        dataSource: {
            data: data,
            pageSize: 25
        },
        pageable: {
            pageSizes: [10, 25, 50, 100, 150, 200, "all"],
            //input: true,
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TX_BienSoXe",
                title: "BIỂN SỐ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "GioXuatBenKeHoach",
                title: "GIỜ KẾ HOẠCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "GioRaBen",
                title: "GIỜ THỰC TẾ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "SoKhach",
                title: "SỐ KHÁCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "GhiChu",
                title: "GHI CHÚ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            }
        ]
    })
}; //fix ben
//BÁO CÁO XE THỰC HIỆN 70% SỐ CHUYẾN
function BaoCaoHoatDong_BaoCaoXeThucHien70_BaoCaoToanQuoc(id, data) {
    var ttt = "#" + id;
    $(ttt).kendoGrid({
        sortable: true,
        selectable: "row",
        scrollable: true,
        //height: 380,
        dataSource: {
            data: data,
            pageSize: 25
        },
        pageable: {
            pageSizes: [10, 25, 50, 100, 150, 200, "all"],
            //input: true,
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TS_TenTinh",
                title: "SỞ GIAO THÔNG VẬN TẢI (TỈNH)",
                width: 150,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                },
                template: '<a target="_blank" href="#=URL#">#=TS_TenTinh#</a>',
                attributes: { style: "text-align: left;" }
            },
            {
                field: "SoChuenDangKy",
                title: "SỐ CHUYẾN KẾ HOẠCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "SoChuyenThucHien",
                title: "SỐ XE KHÔNG CHẠY ĐỦ 70%",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "SoLuotKhach",
                title: "SỐ KHÁCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TyLeThucHien",
                title: "TỶ LỆ (%)",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            }
        ]
    })
}; //fix Toan Quoc
function BaoCaoHoatDong_BaoCaoXeThucHien70_BaoCaoSo(id, data) {
    var ttt = "#" + id;
    $(ttt).kendoGrid({
        sortable: true,
        selectable: "row",
        scrollable: true,
        //height: 380,
        dataSource: {
            data: data,
            pageSize: 25
        },
        pageable: {
            pageSizes: [10, 25, 50, 100, 150, 200, "all"],
            //input: true,
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TenTuyen",
                title: "TUYẾN VẬN TẢI",
                width: 250,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                },
                template: '<a target="_blank" href="#=URL#">#=TenTuyen#</a>',
                attributes: { style: "text-align: left;" }
            },
            {
                field: "SoChuyenKeHoach",
                title: "SỐ CHUYẾN KẾ HOẠCH",
                width: 50,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "SoChuyenThucHien",
                title: "SỐ CHUYẾN THỰC HIỆN",
                width: 50,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TyLeXuatBen",
                title: "TỶ LỆ (%)",
                width: 50,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            }
        ]
    })
}; //fix so
function BaoCaoHoatDong_BaoCaoXeThucHien70_BaoCaoTuyen(id, data) {
    var ttt = "#" + id;
    $(ttt).kendoGrid({
        sortable: true,
        selectable: "row",
        scrollable: true,
        //height: 380,
        dataSource: {
            data: data,
            pageSize: 25
        },
        pageable: {
            pageSizes: [10, 25, 50, 100, 150, 200, "all"],
            //input: true,
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TenCongTy",
                title: "ĐƠN VỊ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                },
                template: '<a target="_blank" href="#=URL#">#=TenCongTy#</a>',
                attributes: { style: "text-align: left;" }
            },
            {
                field: "TongLuotVanChuyen",
                title: "SỐ LƯỢT KẾ HOẠCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TongLuot",
                title: "SỐ LƯỢT XUẤT BẾN",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TyLeThucHien",
                title: "TỈ LỆ (%)",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            }
        ]
    })
}; //fix Tuyen
function BaoCaoHoatDong_BaoCaoXeThucHien70_BaoCaoDonViVanTai(id, data) {
    var ttt = "#" + id;
    $(ttt).kendoGrid({
        sortable: true,
        selectable: "row",
        scrollable: true,
        //height: 380,
        dataSource: {
            data: data,
            pageSize: 25
        },
        pageable: {
            pageSizes: [10, 25, 50, 100, 150, 200, "all"],
            //input: true,
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TX_BienSoXe",
                title: "BIỂN SỐ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                },
                template: '<a target="_blank" href="#=URL#">#=TX_BienSoXe#</a>',
                attributes: { style: "text-align: left;" }
            },
            {
                field: "TongSoKhach",
                title: "SỐ KHÁCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TX_BX_TongLuotVanChuyen",
                title: "SỐ LƯỢT KẾ HOẠCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "SoLuotXuatBen",
                title: "SỐ LƯỢT XUẤT BẾN",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TyLeVanChuyen",
                title: "TỶ LỆ (%)",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            }
        ]
    })
}; //fix dvvt
function BaoCaoHoatDong_BaoCaoXeThucHien70_BaoCaoBen(id, data) {
    var ttt = "#" + id;
    $(ttt).kendoGrid({
        sortable: true,
        selectable: "row",
        scrollable: true,
        //height: 380,
        dataSource: {
            data: data,
            pageSize: 25
        },
        pageable: {
            pageSizes: [10, 25, 50, 100, 150, 200, "all"],
            //input: true,
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TX_BienSoXe",
                title: "BIỂN SỐ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "BienSoDi",
                title: "BIỂN SỐ RA",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "GioXuatBenKeHoach",
                title: "GIỜ KẾ HOẠCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "GioRaBen",
                title: "GIỜ THỰC TẾ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "SoKhach",
                title: "SỐ KHÁCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "GhiChu",
                title: "GHI CHÚ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            }
        ]
    })
};
//BÁO CÁO XE KHÔNG VỀ BẾN
function BaoCaoHoatDong_BaoCaoXeKhongVeBen_BaoCaoToanQuoc(id, data) {
    var ttt = "#" + id;
    $(ttt).kendoGrid({
        sortable: true,
        selectable: "row",
        scrollable: true,
        //height: 380,
        dataSource: {
            data: data,
            pageSize: 25
        },
        pageable: {
            pageSizes: [10, 25, 50, 100, 150, 200, "all"],
            //input: true,
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "tuyenvantai",
                title: "TUYẾN VẬN TẢI",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                },
                template: '<a target="_blank" href="/BaoCaoHoatDong/BaoCaoHoatDong_So?name=e">#=tuyenvantai#</a>',
                attributes: { style: "text-align: center;" }
                //?ThuocSo=#=thuocso#&ThuocTuyen=#=thuoctuyen#&Thang=#=thang#
            },
            {
                field: "soxekehoach",
                title: "SỐ XE KẾ HOẠCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "soxekhongchay",
                title: "SỐ XE KHÔNG CHẠY",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "tilekhongthuchien",
                title: "TỶ LỆ (%)",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            }
        ]
    })
};
function BaoCaoHoatDong_BaoCaoXeKhongVeBen_BaoCaoSo(id, data) {
    var ttt = "#" + id;
    $(ttt).kendoGrid({
        sortable: true,
        selectable: "row",
        scrollable: true,
        //height: 380,
        dataSource: {
            data: data,
            pageSize: 25
        },
        pageable: {
            pageSizes: [10, 25, 50, 100, 150, 200, "all"],
            //input: true,
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "tuyenvantai",
                title: "TUYẾN VẬN TẢI",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                },
                template: '<a target="_blank" href="/BaoCaoHoatDong/BaoCaoHoatDong_Tuyen?name=e">#=tuyenvantai#</a>',
                attributes: { style: "text-align: center;" }
                //?ThuocSo=#=thuocso#&ThuocTuyen=#=thuoctuyen#&Thang=#=thang#
            },
            {
                field: "soxekehoach",
                title: "SỐ XE KẾ HOẠCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "soxekhongveben",
                title: "SỐ XE KHÔNG VỀ BẾN",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "tilekhongveben",
                title: "TỶ LỆ (%)",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            }
        ]
    })
};
function BaoCaoHoatDong_BaoCaoXeKhongVeBen_BaoCaoTuyen(id, data) {
    var ttt = "#" + id;
    $(ttt).kendoGrid({
        sortable: true,
        selectable: "row",
        scrollable: true,
        //height: 380,
        dataSource: {
            data: data,
            pageSize: 25
        },
        pageable: {
            pageSizes: [10, 25, 50, 100, 150, 200, "all"],
            //input: true,
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "donvi",
                title: "ĐƠN VỊ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                },
                template: '<a target="_blank" href="/BaoCaoHoatDong/BaoCaoHoatDong_DonViVanTai?name=e">#=donvi#</a>',
                attributes: { style: "text-align: center;" }
                //?ThuocSo=#=thuocso#&ThuocTuyen=#=thuoctuyen#&ThuocDVVT=#=thuocDVVT#&Thang=#=thang#
            },
            {
                field: "soxekehoach",
                title: "SỐ XE KẾ HOẠCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "soxekhongveben",
                title: "SỐ XE KHÔNG VỀ BẾN",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "tilekhongthuchien",
                title: "TỈ LỆ (%)",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            }
        ]
    })
};
function BaoCaoHoatDong_BaoCaoXeKhongVeBen_BaoCaoDonViVanTai(id, data) {
    var ttt = "#" + id;
    $(ttt).kendoGrid({
        sortable: true,
        selectable: "row",
        scrollable: true,
        //height: 380,
        dataSource: {
            data: data,
            pageSize: 25
        },
        pageable: {
            pageSizes: [10, 25, 50, 100, 150, 200, "all"],
            //input: true,
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "plateNumber",
                title: "BIỂN SỐ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                },
                template: '<a target="_blank" href="#=URL#">#=plateNumber#</a>',
                attributes: { style: "text-align: left;" }
            },
            {
                field: "soghe",
                title: "SỐ GHẾ (GIƯỜNG)",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "soxekehoach",
                title: "SỐ XE KẾ HOẠCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "soxekhongveben",
                title: "SỐ XE KHÔNG VỀ BẾN",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "tilekhongveben",
                title: "TỶ LỆ (%)",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            }
        ]
    })
};
function BaoCaoHoatDong_BaoCaoXeKhongVeBen_BaoCaoBen(id, data) {
    var ttt = "#" + id;
    $(ttt).kendoGrid({
        sortable: true,
        selectable: "row",
        scrollable: true,
        //height: 380,
        dataSource: {
            data: data,
            pageSize: 25
        },
        pageable: {
            pageSizes: [10, 25, 50, 100, 150, 200, "all"],
            //input: true,
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TX_BienSoXe",
                title: "BIỂN SỐ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "GioXuatBenKeHoach",
                title: "GIỜ KẾ HOẠCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "GioRaBen",
                title: "GIỜ THỰC TẾ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "SoKhach",
                title: "SỐ KHÁCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "GhiChu",
                title: "GHI CHÚ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            }
        ]
    })
};
/*=================================================================================================================================*/
//BÁO CÁO TỔNG HỢP ==> Sửa lại 3 phần sao
//BÁO CÁO TOÀN QUỐC
function BaoCaoTongHop_BaoCaoToanQuoc(id, data) {
    var ttt = "#" + id;
    $(ttt).kendoGrid({
        //excel: {
        //    fileName: "LichXeChay.xlsx",
        //    allPages: true
        //},
        resizeable: true,
        sortable: true,
        selectable: "row",
        scrollable: true,
        dataSource: {
            data: data,
            group: {
                field: "Ten_So", aggregates: [{ field: "ngay", aggregate: "count" }]
            },
            aggregate: { field: "ngay", aggregate: "count" },
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe);
        },
        columns: [{
            title: "STT",
            template: "#= ++record #",
            width: 30,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            },
            groupFooterTemplate: "TỔNG:",
            footerTemplate: "TỔNG:"
        }, {
            field: "ngay",
            title: "NGÀY",
            width: 100,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            },
            groupFooterTemplate: "#=count#",
            footerTemplate: "#=count#"
        },
        {
            field: "sochuyenkehoach",
            title: "SỐ CHUYẾN KẾ HOẠCH",
            width: 100,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        },
        {
            field: "sochuyenthucte",
            title: "SỐ CHUYẾN THỰC TẾ",
            width: 100,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        },
        {
            field: "chenhlech",
            title: "CHÊNH LỆCH",
            width: 100,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        },
        {
            field: "tile",
            title: "TỈ LỆ (%)",
            width: 100,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
            }
        }
        ]
    })
};
//BÁO CÁO SỞ    
function BaoCaoTongHop_BaoCaoSo(id, data) {
    var ttt = "#" + id;
    $(ttt).kendoGrid({
        //height: 380,
        dataSource: {
            data: data,
            pageSize: 25,
            //group: {
            //    field: "Ten_So", aggregates: [{ field: "plateNumber", aggregate: "count" }]
            //}
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe);
        },
        pageable: {
            pageSizes: [10, 25, 50, 100, 150, 200, "all"],
            //input: true,
            numeric: true,
            info: false
        },
        sortable: true,
        selectable: "row",
        scrollable: true,
        columns: [
            {
                hidden: true,
                field: "Ten_So",
            },
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "plateNumber",
                title: "NGÀY",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                },
                //groupFooterTemplate: "#=count#"
            },
            {
                field: "sochuyenkehoach",
                title: "SỐ CHUYẾN KẾ HOẠCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "sochuyenthucte",
                title: "SỐ CHUYẾN THỰC TẾ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                },
                //template: '<a target="_blank" href="#=URL#">#=TenTuyen#</a>',
            },
            {
                field: "chenhlech",
                title: "CHÊNH LỆCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "tile",
                title: "TỈ LỆ (%)",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            }
        ]
    })
};
//BÁO CÁO TẠI BẾN
function BaoCaoTongHop_BaoCaoTaiBen(id, data) {
    var ttt = "#" + id;
    $(ttt).kendoGrid({
        sortable: true,
        selectable: "row",
        scrollable: true,
        //height: 380,
        dataSource: {
            data: data,
            pageSize: 25
        },
        pageable: {
            pageSizes: [10, 25, 50, 100, 150, 200, "all"],
            //input: true,
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "ngay",
                title: "NGÀY",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "sochuyenkehoach",
                title: "SỐ CHUYẾN KẾ HOẠCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "sochuyenthucte",
                title: "SỐ CHUYẾN THỰC TẾ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "chenhlech",
                title: "CHÊNH LỆCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "tile",
                title: "TỈ LỆ (%)",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            }
        ]
    })
};
/*=================================================================================================================================*/
//BÁO CÁO HIỆN TRẠNG BẾN
function BaoCaoHienTrangBen(id, data) {
    var ttt = "#" + id;
    $(ttt).kendoGrid({
        sortable: true,
        selectable: "row",
        scrollable: true,
        //height: 380,
        dataSource: {
            data: data
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "soso",
                title: "SỞ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                title: "LOẠI BẾN",
                headerAttributes: {
                    style: "text-align: center; vertical-align: middle; font-size:12px; font-weight:bold; white-space:normal"
                },
                columns: [{
                    title: "LOẠI 1",
                    field: "Loai1",
                    headerAttributes: {
                        style: "text-align: center; vertical-align: middle; font-size:12px; font-weight:bold; white-space:normal"
                    },
                }, {
                    title: "LOẠI 2",
                    field: "Loai2",
                    headerAttributes: {
                        style: "text-align: center; vertical-align: middle; font-size:12px; font-weight:bold; white-space:normal"
                    },
                }, {
                    title: "LOẠI 3",
                    field: "Loai3",
                    headerAttributes: {
                        style: "text-align: center; vertical-align: middle; font-size:12px; font-weight:bold; white-space:normal"
                    },
                },
                {
                    title: "LOẠI 4",
                    field: "Loai4",
                    headerAttributes: {
                        style: "text-align: center; vertical-align: middle; font-size:12px; font-weight:bold; white-space:normal"
                    },
                },
                {
                    title: "LOẠI 5",
                    field: "Loai5",
                    headerAttributes: {
                        style: "text-align: center; vertical-align: middle; font-size:12px; font-weight:bold; white-space:normal"
                    },
                },
                {
                    title: "LOẠI 6",
                    field: "Loai6",
                    headerAttributes: {
                        style: "text-align: center; vertical-align: middle; font-size:12px; font-weight:bold; white-space:normal"
                    },
                }
                ]
            },
            {
                field: "tong",
                title: "TỔNG",
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                title: "LUỒNG TUYẾN",
                headerAttributes: {
                    style: "text-align: center; vertical-align: middle; font-size:12px; font-weight:bold; white-space:normal"
                },
                columns: [{
                    title: "QUY HOẠCH",
                    field: "quyhoach_luongtuyen",
                    headerAttributes: {
                        style: "text-align: center; vertical-align: middle; font-size:12px; font-weight:bold; white-space:normal"
                    },
                }, {
                    title: "HOẠT ĐỘNG",
                    field: "hoatdong",
                    headerAttributes: {
                        style: "text-align: center; vertical-align: middle; font-size:12px; font-weight:bold; white-space:normal"
                    },
                }]
            },
            {
                title: "SỐ CHUYẾN",
                headerAttributes: {
                    style: "text-align: center; vertical-align: middle; font-size:12px; font-weight:bold; white-space:normal"
                },
                columns: [{
                    title: "QUY HOẠCH",
                    field: "quyhoach_sochuyen",
                    headerAttributes: {
                        style: "text-align: center; vertical-align: middle; font-size:12px; font-weight:bold; white-space:normal"
                    },
                }, {
                    title: "ĐĂNG KÝ",
                    field: "dangky",
                    headerAttributes: {
                        style: "text-align: center; vertical-align: middle; font-size:12px; font-weight:bold; white-space:normal"
                    },
                }]
            },
            {
                field: "sodonvi",
                title: "SỐ ĐƠN VỊ",
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            }
        ]
    })
};
/*=================================================================================================================================*/
function BaoCao_NhatTrinhXe(id, data) {
    var ttt = "#" + id;
    $(ttt).kendoGrid({
        sortable: true,
        selectable: "row",
        scrollable: true,
        //height: 380,
        dataSource: {
            data: data,
            pageSize: 25
        },
        pageable: {
            pageSizes: [10, 25, 50, 100, 150, 200, "all"],
            //input: true,
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "TX_BienSoXe",
                title: "BIỂN SỐ XE",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "BienSoDi",
                title: "BIỂN SỐ ĐI",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "BenDi",
                title: "BẾN ĐI",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "GioXuatBenKeHoach",
                title: "GIỜ KẾ HOẠCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "GioRaBen",
                title: "GIỜ RA BẾN",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            },
            {
                field: "SoKhach",
                title: "SỐ KHÁCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-size: 12px; font-weight: bold; white-space: normal; vertical-align: middle"
                }
            }
        ]
    })
};
