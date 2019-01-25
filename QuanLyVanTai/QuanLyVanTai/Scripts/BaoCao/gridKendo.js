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
    $(ttt).html(title1);
    //$(ttt).html(title1 + ' - <span style = "color: red;">' + title2 + '</span>');
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
$('input[id*="chk_"]').each(function () {
    $(this).prop("checked", true);
});
function UpdateIdinHF(obj) {
    var id = $(obj).attr('id');
    var name = $(obj).attr('name');
    var value = parseInt($(obj).attr('value'));
    var IsChecked = $(obj).is(':checked'); //console.log($("#chk_fabric_-1").is(':checked'));
    var hf = $("#hf_" + name).get(0);
    var giatritotal = $("#chk_fabric_-1").is(':checked');
    var totalchk = $('input[id*="chk_' + name + '"]').not("#chk_" + name + "_0").length;
    var checkedchk = $('input[id*="chk_' + name + '"]:checked').not("#chk_" + name + "_0").length;

    if (value != -1) {
        UpdateIdInHiddenField(hf, value, IsChecked);
        if (giatritotal == false && checkedchk == totalchk) {
            $("#chk_fabric_-1").prop("checked", true);
            UpdateIdInHiddenField(hf, $("#chk_fabric_-1").val(), true);
        }
        if (IsChecked == false) {
            $("#chk_" + name + "_0").prop("checked", false);            
        }
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
        ShowSelectedItem("hf_fabric", "spanfabric");
        hiencactinh("chitietchon");
    }
}
function ShowSelectedItem(idhf, idspan) {
    var id = "#" + idhf;
    var ids = "#" + idspan;
    var tt = $(id).val().split(",");
    if (tt != "") {
        if (tt.indexOf("-1") > -1) {
             $(ids).html("Tất Cả");//$(ids).html(tt.length - 3);
        } else {
            $(ids).html(tt.length - 2);
        };
    }
    //var tt = $("#hf_fabric").val().split(",");
    //if (tt != "") {
    //    if (tt.indexOf("-1") > -1) {
    //        $("#spanfabric").html(tt.length - 3);
    //    } else {
    //        $("#spanfabric").html(tt.length - 2);
    //    };
    //}
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
    var name = "fabric";
    var giatritotal = $("#chk_fabric_-1").is(':checked');
    var totalchk = $('input[id*="chk_fabric"]').not("#chk_fabric_-1").length;
    var checkedchk = $('input[id*="chk_fabric"]:checked').not("#chk_fabric_-1").length;
    var hf = $("#hf_fabric").get(0);
    console.log(totalchk + " - " + checkedchk);
    if (giatritotal == true && checkedchk != totalchk) {
        $("#chk_fabric_-1").prop("checked", false); 
        UpdateIdInHiddenField(hf, $("#chk_fabric_-1").val(), false);
    }
    if (giatritotal == false && checkedchk == totalchk) {
            $("#chk_fabric_-1").prop("checked", true);
            UpdateIdInHiddenField(hf, $("#chk_fabric_-1").val(), true);
    }
}
function travetinhchonhidden() {
    var string = "";

    $('input[id*="chk_"]:checked').each(function () {
        var temp = $(this).next("label").text();
        string += "," + $(this).next("label").text();
    });
    if (string.indexOf("Chọn") > -1) {
        return "Chọn";
    } else if (string.indexOf("Tất Cả") > -1 || string.indexOf("Tất cả") > -1) {
        return "Tất Cả";
    }
    else
        return string;

}
function hiencactinh(ID) {
    var id = "#" + ID;
    var chuoitrave = travetinhchonhidden();
    //console.log(chuoitrave);
    if (chuoitrave == "") {
        $(id).html("");
    }
    if (chuoitrave != "Chọn" || chuoitrave != "Tất Cả") {
        var ttt = chuoitrave.split(',');
        var sopt = ttt.length;
        var chuoi = " ";
        if (sopt <= 3 && sopt > 1) {
            for (i = 1; i < sopt; i++) {
                if (ttt[i] != "") {
                    if (i < sopt - 1) {
                        chuoi += ttt[i] + ", ";
                    } else {
                        chuoi += ttt[i];
                    }
                }
            }
        }
        else if (sopt > 3) {
            for (i = 1; i < 4; i++) {
                if (ttt[i] != "") {
                    if (i < 3) {
                        chuoi += ttt[i] + ", ";
                    } else {
                        chuoi += ttt[i];
                    }
                }
            }
            chuoi += ", ...";
        }
        //console.log(ttt); console.log(sopt); console.log(chuoi);
        if (chuoi.length > 8) {
            $(id).html(chuoi);
        } else {
            $(id).html("");
        }
    } else {
        $(id).html(" ");//$(id).html(" " + chuoitrave);
    }    
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
var otherElementsHeightThongTinXe = $("#body_dau").height() + $(".navbar-static-top").height() - 100;
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
            pageSize: 100,
            aggregate: [
                { field: "TS_TenTinh", aggregate: "count" },
                { field: "SoBen", aggregate: "sum" },
                { field: "SoXe", aggregate: "sum" },
                { field: "TongCongSuat", aggregate: "sum" },
                { field: "TongSoTuyen", aggregate: "sum" },
                { field: "SoChuenDangKy", aggregate: "sum" },
                { field: "SoLuotXuatBen", aggregate: "sum" },
                { field: "SoLuotKhach", aggregate: "sum" },
                { field: "TyLeThucHien", aggregate: "average" },
            ]
        },
        pageable: {
            pageSizes: true,
            //input: true,
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe + 100);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                footerTemplate: "TỔNG:"
            },
            {
                field: "TS_TenTinh",
                title: "TỈNH/THÀNH PHỐ",
                width: 80,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                template: '<a target="_blank" href="#=URL#">#=TS_TenTinh#</a>',
                footerTemplate: "<div style='text-align: left;'><strong>#=kendo.toString(count,'n0')#</strong> Tỉnh</div>",
            },
            {
                field: "SoBen",
                title: "SỐ LƯỢNG BẾN XE",
                width: 50,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                attributes: { style: "text-align: right;" },
                footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> </div>",
                format: "{0:n0}",
            },
            {
                field: "TongCongSuat",
                title: "TỔNG CÔNG SUẤT",
                width: 50,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                attributes: { style: "text-align: right;" },
                footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> </div>",
                format: "{0:n0}",
            },
            {
                field: "SoXe",
                title: "TỔNG SỐ XE",
                width: 50,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                attributes: { style: "text-align: right;" },
                footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> </div>",
                format: "{0:n0}",
            },
            {
                field: "TongSoTuyen",
                title: "TỔNG SỐ TUYẾN VẬN CHUYỂN",
                width: 50,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                attributes: { style: "text-align: right;" },
                footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> </div>",
                format: "{0:n0}",
            },
            {
                title: "SỐ CHUYẾN",
                width: 80,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                columns: [
                    {
                        field: "SoChuenDangKy",
                        title: "SỐ CHUYẾN ĐĂNG KÝ",
                        width: 50,
                        headerAttributes: {
                            "class": "table-header-cell",
                            style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                        },
                        attributes: { style: "text-align: right;" },
                        footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> </div>",
                        format: "{0:n0}",
                    },
                    {
                        field: "SoLuotXuatBen",
                        title: "SỐ LƯỢT XUẤT BẾN",
                        width: 50,
                        headerAttributes: {
                            "class": "table-header-cell",
                            style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                        },
                        attributes: { style: "text-align: right;" },
                        footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> </div>",
                        format: "{0:n0}",
                    }
                ]
            },            
            {
                field: "SoLuotKhach",
                title: "SỐ KHÁCH",
                width: 50,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                attributes: { style: "text-align: right;" },
                footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> K</div>",
                format: "{0:n0}",
            },
            {
                field: "TyLeThucHien",
                title: "TỶ LỆ THỰC HIỆN (%)",
                width: 50,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                format: "{0:n2}",
                attributes: { style: "text-align: right;" },
                footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(average, \"n2\")#%</strong> </div>",
            },
            {
                field: "TrangThaiTruyenDan",
                title: "TRẠNG THÁI",
                width: 50,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
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
            pageSize: 100,
            aggregate: [
                { field: "TenBenXe", aggregate: "count" },
                { field: "SoLuotXuatBenQuyHoach", aggregate: "sum" },
                { field: "TongSoXe", aggregate: "sum" },
                { field: "TongTaiTrong", aggregate: "sum" },
                { field: "TongSoTuyen", aggregate: "sum" },
                { field: "SoChuyenDangKy", aggregate: "sum" },
                { field: "SoChuyenThucHien", aggregate: "sum" },
                { field: "TyLeThucHien", aggregate: "average" },
            ]
        },
        pageable: {
            pageSizes: [100, 150, 200, "all"],
            //input: true,
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe + 100);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                footerTemplate: "TỔNG:"
            },
            {
                field: "TenBenXe",
                title: "BẾN XE",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                template: '<a target="_blank" href="" onclick="troBaoCaoHoatDongBen(this)" data-idBen="#=BX_IdBenXe#">#=TenBenXe#</a>',
                footerTemplate: "<div style='text-align: left;'><strong>#=kendo.toString(count,'n0')#</strong> Bến</div>",
            },
            {
                field: "LoaiBenXe",
                title: "CẤP BẾN",
                width: 50,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
            },            
            {
                field: "SoLuotXuatBenQuyHoach",
                title: "CÔNG SUẤT (LƯỢT/NGÀY)",
                width: 70,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                attributes: { style: "text-align: right;" },
                footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> </div>",
                format: "{0:n0}",
            },
            //{
            //    field: "TenBenXe",
            //    title: "SỐ ĐƠN VỊ HOẠT ĐỘNG TẠI BẾN",
            //    width: 150,
            //    headerAttributes: {
            //        "class": "table-header-cell",
            //        style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
            //    },
            //    attributes: { style: "font-size: 12px;" },
            //},
            {
                field: "TongSoXe",
                title: "TỔNG SỐ XE",
                width: 70,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                attributes: { style: "text-align: right;" },
                footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> </div>",
                format: "{0:n0}",
            },
            {
                field: "TongTaiTrong",
                title: "TỔNG TẢI TRỌNG (LƯỢT KHÁCH)",
                width: 70,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                attributes: { style: "text-align: right;" },
                footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> </div>",
                format: "{0:n0}",
            },
            {
                field: "TongSoTuyen",
                title: "TỔNG SỐ TUYẾN VẬN CHUYỂN",
                width: 70,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                attributes: { style: "text-align: right;" },
                footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> </div>",
                format: "{0:n0}",
            },
            {
                title: "SỐ CHUYẾN",
                width: 80,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                columns: [
                    {
                        field: "SoChuyenDangKy",
                        title: "SỐ CHUYẾN ĐĂNG KÝ",
                        width: 50,
                        headerAttributes: {
                            "class": "table-header-cell",
                            style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                        },
                        attributes: { style: "text-align: right;" },
                        footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> </div>",
                        format: "{0:n0}",
                    },
                    {
                        field: "SoChuyenThucHien",
                        title: "SỐ CHUYẾN THỰC TẾ",
                        width: 50,
                        headerAttributes: {
                            "class": "table-header-cell",
                            style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                        },
                        attributes: { style: "text-align: right;" },
                        footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> </div>",
                        format: "{0:n0}",
                    },
                ]
            },            
            //{
            //    field: "SoKhach",
            //    title: "SỐ KHÁCH",
            //    width: 50,
            //    headerAttributes: {
            //        "class": "table-header-cell",
            //        style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
            //    },
            //    attributes: { style: "font-size: 12px;" },
            //    footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> K</div>",
            //    format: "{0:n0}",
            //},
            {
                field: "TyLeThucHien",
                title: "TỶ LỆ %",
                width: 50,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                attributes: { style: "text-align: right;" },
                format: "{0:n2}",
                footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(average, \"n2\")#%</strong> </div>"
            },
            {
                field: "TrangThaiTruyenDan",
                title: "TRẠNG THÁI",
                width: 50,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
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
            pageSize: 100,
            aggregate: [
                { field: "TenCongTy", aggregate: "count" },
                { field: "TongLuotXuatBen", aggregate: "sum" },
                { field: "TongSoXe", aggregate: "sum" },
                { field: "SoLuotXuatBen", aggregate: "sum" },
                { field: "SoLuotKhach", aggregate: "sum" },
                { field: "TyLeXuatBen", aggregate: "average" },
            ]
        },
        pageable: {
            pageSizes: [50, 100, 150, 200, "all"],
            ////input: true,
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe + 100);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                footerTemplate: "TỔNG:"
            },
            {
                field: "TenCongTy",
                title: "ĐƠN VỊ VẬN TẢI",
                width: 250,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                template: '<a target="_blank" href="" onclick="troBaoCaoDonVi(this)" data-idDonVi="#=CT_IdCongTyVT#" >#=TenCongTy#</a>',
                footerTemplate: "<div style='text-align: left;'><strong>#=kendo.toString(count,'n0')#</strong> Công Ty</div>",
            },
            {
                field: "TongLuotXuatBen",
                title: "SỐ CHUYẾN ĐĂNG KÝ",
                width: 60,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> </div>",
                attributes: { style: "text-align: right;" },
                format: "{0:n0}",
            },
            {
                field: "TongSoXe",
                title: "SỐ XE",
                width: 60,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> Xe</div>",
                attributes: { style: "text-align: right;" },
                format: "{0:n0}",
            },
            {
                field: "SoLuotXuatBen",
                title: "SỐ CHUYẾN THỰC CHẠY",
                width: 60,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> </div>",
                attributes: { style: "text-align: right;" },
                format: "{0:n0}",
            },
            {
                field: "SoLuotKhach",
                title: "SỐ KHÁCH",
                width: 60,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> K</div>",
                attributes: { style: "text-align: right;" },
                format: "{0:n0}",
            },
            {
                field: "TyLeXuatBen",
                title: "TỈ LỆ (%)",
                width: 60,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                format: "{0:n2}",
                attributes: { style: "text-align: right;" },
                footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(average, \"n2\")#%</strong> </div>"
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
            pageSize: 100,
            aggregate: [
                { field: "TX_BienSoXe", aggregate: "count" },
                { field: "TaiTrong", aggregate: "sum" },
                { field: "TX_BX_TongLuotVanChuyen", aggregate: "sum" },
                { field: "SoLuotXuatBen", aggregate: "sum" },
                { field: "SoLuotKhach", aggregate: "sum" },
                { field: "TyLeVanChuyen", aggregate: "average" },
            ]
        },
        pageable: {
            pageSizes: [10, 25, 50, 100, 150, 200, "all"],
            ////input: true,
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe + 100);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                footerTemplate: "TỔNG:"
            },
            {
                field: "TX_BienSoXe",
                title: "BIỂN SỐ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                template: '<a target="_blank" href="#=URL#">#=TX_BienSoXe#</a>',
                footerTemplate: "<div style='text-align: left;'><strong>#=kendo.toString(count,'n0')#</strong> Xe</div>",
            },
            {
                field: "TaiTrong",
                title: "TẢI TRỌNG",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                attributes: { style: "text-align: right;" },
                footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> </div>",
                format: "{0:n0}",
            },
            {
                field: "TX_BX_TongLuotVanChuyen",
                title: "SỐ CHUYẾN KẾ HOẠCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                attributes: { style: "text-align: right;" },
                footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> </div>",
                format: "{0:n0}",
            },
            {
                field: "SoLuotXuatBen",
                title: "SỐ CHUYẾN THỰC CHẠY",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                attributes: { style: "text-align: right;" },
                footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> </div>",
                format: "{0:n0}",
            },
            {
                field: "SoLuotKhach",
                title: "SỐ KHÁCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                attributes: { style: "text-align: right;" },
                footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> K</div>",
                format: "{0:n0}",
            },
            {
                field: "TyLeVanChuyen",
                title: "TỶ LỆ (%)",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                attributes: { style: "text-align: right;" },
                format: "{0:n2}",
                footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(average, \"n2\")#%</strong> </div>"
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
            pageSize: 100,
            aggregate: [
                { field: "LT_MaTuyen", aggregate: "count" },
                { field: "TenTuyen", aggregate: "count" },
                { field: "LT_CuLy", aggregate: "sum" },
                { field: "TongSoDonVi", aggregate: "sum" },
                { field: "SoChuyenQuyHoach", aggregate: "sum" },
                { field: "SoChuyenKeHoach", aggregate: "sum" },
                { field: "SoChuyenThucHien", aggregate: "sum" },
                { field: "SoLuotKhach", aggregate: "sum" },
                { field: "TyLeXuatBen", aggregate: "average" },
            ]
        },
        pageable: {
            pageSizes: [10, 25, 50, 100, 150, 200, "all"],
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe + 100);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                footerTemplate: "TỔNG:"
            },
            {
                field: "LT_MaTuyen",
                title: "MÃ TUYẾN",
                width: 60,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                footerTemplate: "<div style='text-align: left;'><strong>#=kendo.toString(count,'n0')#</strong> </div>",
            },
            {
                field: "TenTuyen",
                title: "TÊN TUYẾN",
                template: '<a target="_blank" href="#=URL#">#=TenTuyen#</a>',
                width: 120,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                footerTemplate: "<div style='text-align: left;'><strong>#=kendo.toString(count,'n0')#</strong> Tuyến</div>",
            },
            {
                field: "LT_CuLy",
                title: "CỰ LY",
                width: 60,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                attributes: { style: "text-align: right;" },
                footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> </div>",
                format: "{0:n0}"
            },
            {
                field: "TongSoDonVi",
                title: "SỐ ĐƠN VỊ KHAI THÁC",
                width: 60,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                attributes: { style: "text-align: right;" },
                footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> </div>",
                format: "{0:n0}"
            },
            {
                title: "SỐ CHUYẾN",
                width: 80,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                columns: [
                    {
                        field: "SoChuyenQuyHoach",
                        title: "SỐ CHUYẾN QUY HOẠCH",
                        width: 50,
                        headerAttributes: {
                            "class": "table-header-cell",
                            style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                        },
                        attributes: { style: "text-align: right;" },
                        footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> </div>",
                        format: "{0:n0}",
                    },
                    {
                        field: "SoChuyenKeHoach",
                        title: "SỐ CHUYẾN ĐĂNG KÝ",
                        width: 50,
                        headerAttributes: {
                            "class": "table-header-cell",
                            style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                        },
                        attributes: { style: "text-align: right;" },
                        footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> </div>",
                        format: "{0:n0}",
                    },
                    {
                        field: "SoChuyenThucHien",
                        title: "SỐ CHUYẾN THỰC HIỆN",
                        width: 50,
                        headerAttributes: {
                            "class": "table-header-cell",
                            style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                        },
                        attributes: { style: "text-align: right;" },
                        footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> </div>",
                        format: "{0:n0}",
                    }
                ]
            },            
            {
                field: "SoLuotKhach",
                title: "SỐ KHÁCH",
                width: 50,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                attributes: { style: "text-align: right;" },
                footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> K</div>",
                format: "{0:n0}",
            },
            {
                field: "TyLeXuatBen",
                title: "TỈ LỆ THỰC HIỆN",
                width: 50,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                attributes: { style: "text-align: right;" },
                format: "{0:n2}",
                footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(average, \"n2\")#%</strong> </div>"
            },
            {
                field: "TrangThaiTruyenDan",
                title: "TRẠNG THÁI",
                width: 50,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
            }
        ]
    })
}; //fix ben
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
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                }
            },
            {
                field: "soso",
                title: "SỞ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                }
            },
            {
                title: "LOẠI BẾN",
                headerAttributes: {
                    style: "text-align: center; vertical-align: middle; font-size:14px; font-weight:bold; white-space:normal"
                },
                columns: [{
                    title: "LOẠI 1",
                    field: "Loai1",
                    headerAttributes: {
                        style: "text-align: center; vertical-align: middle; font-size:14px; font-weight:bold; white-space:normal"
                    },
                }, {
                    title: "LOẠI 2",
                    field: "Loai2",
                    headerAttributes: {
                        style: "text-align: center; vertical-align: middle; font-size:14px; font-weight:bold; white-space:normal"
                    },
                }, {
                    title: "LOẠI 3",
                    field: "Loai3",
                    headerAttributes: {
                        style: "text-align: center; vertical-align: middle; font-size:14px; font-weight:bold; white-space:normal"
                    },
                },
                {
                    title: "LOẠI 4",
                    field: "Loai4",
                    headerAttributes: {
                        style: "text-align: center; vertical-align: middle; font-size:14px; font-weight:bold; white-space:normal"
                    },
                },
                {
                    title: "LOẠI 5",
                    field: "Loai5",
                    headerAttributes: {
                        style: "text-align: center; vertical-align: middle; font-size:14px; font-weight:bold; white-space:normal"
                    },
                },
                {
                    title: "LOẠI 6",
                    field: "Loai6",
                    headerAttributes: {
                        style: "text-align: center; vertical-align: middle; font-size:14px; font-weight:bold; white-space:normal"
                    },
                }
                ]
            },
            {
                field: "tong",
                title: "TỔNG",
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                }
            },
            {
                title: "LUỒNG TUYẾN",
                headerAttributes: {
                    style: "text-align: center; vertical-align: middle; font-size:14px; font-weight:bold; white-space:normal"
                },
                columns: [{
                    title: "QUY HOẠCH",
                    field: "quyhoach_luongtuyen",
                    headerAttributes: {
                        style: "text-align: center; vertical-align: middle; font-size:14px; font-weight:bold; white-space:normal"
                    },
                }, {
                    title: "HOẠT ĐỘNG",
                    field: "hoatdong",
                    headerAttributes: {
                        style: "text-align: center; vertical-align: middle; font-size:14px; font-weight:bold; white-space:normal"
                    },
                }]
            },
            {
                title: "SỐ CHUYẾN",
                headerAttributes: {
                    style: "text-align: center; vertical-align: middle; font-size:14px; font-weight:bold; white-space:normal"
                },
                columns: [{
                    title: "QUY HOẠCH",
                    field: "quyhoach_sochuyen",
                    headerAttributes: {
                        style: "text-align: center; vertical-align: middle; font-size:14px; font-weight:bold; white-space:normal"
                    },
                }, {
                    title: "ĐĂNG KÝ",
                    field: "dangky",
                    headerAttributes: {
                        style: "text-align: center; vertical-align: middle; font-size:14px; font-weight:bold; white-space:normal"
                    },
                }]
            },
            {
                field: "sodonvi",
                title: "SỐ ĐƠN VỊ",
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
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
            pageSize: 25,
            aggregate: [
                { field: "TX_BienSoXe", aggregate: "count" },
                { field: "BienSoDi", aggregate: "count" },
                { field: "BenDi", aggregate: "count" },
                { field: "GioXuatBenKeHoach", aggregate: "count" },
                { field: "GioRaBen", aggregate: "count" },
                { field: "SoKhach", aggregate: "sum" },
            ]
        },
        pageable: {
            pageSizes: [10, 25, 50, 100, 150, 200, "all"],
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe + 100);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                footerTemplate: "TỔNG:"
            },
            {
                field: "TX_BienSoXe",
                title: "BIỂN SỐ XE",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                footerTemplate: "<div style='text-align: left;'><strong>#=kendo.toString(count,'n0')#</strong> Xe</div>",
            },
            {
                field: "BienSoDi",
                title: "BIỂN SỐ ĐI",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                footerTemplate: "#=count#"
            },
            {
                field: "BenDi",
                title: "BẾN ĐI",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                footerTemplate: "#=count#"
            },
            {
                field: "GioXuatBenKeHoach",
                title: "GIỜ KẾ HOẠCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                footerTemplate: "#=count#"
            },
            {
                field: "GioRaBen",
                title: "GIỜ RA BẾN",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                footerTemplate: "#=count#"
            },
            {
                field: "SoKhach",
                title: "SỐ KHÁCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                attributes: { style: "text-align: right;" },
                footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> K</div>",
                format: "{0:n0}",
            }
        ]
    })
};
/*=================================================================================================================================*/
function BCHD_BenThuongXuyen(id, data) {
    var ttt = "#" + id;
    $(ttt).kendoGrid({
        sortable: true,
        selectable: "row",
        scrollable: true,
        height: 500,
        dataSource: {
            data: data,
            pageSize: 100,
            aggregate: [
                { field: "TX_BienSoXe", aggregate: "count" },
                { field: "BienSoDi", aggregate: "count" },
                { field: "TenTuyen", aggregate: "count" },
                { field: "LT_MaTuyen", aggregate: "count" },
                { field: "TenCongTy", aggregate: "count" },
                { field: "SucChua", aggregate: "sum" },
                { field: "GioXuatBenKeHoach", aggregate: "count" },
                { field: "GioRaBen", aggregate: "count" },
                { field: "SoKhach", aggregate: "sum" },
            ]            
        },
        pageable: {
            pageSizes: [100, 150, 200, "all"],
            //input: true,
            numeric: true,
            info: false
        },
        dataBinding: function () {
            record = 0;
            $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe + 100);
        },
        columns: [
            {
                title: "STT",
                template: "#= ++record #",
                width: 45,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                footerTemplate: "TỔNG:"
            },
            {
                field: "TX_BienSoXe",
                title: "BIỂN SỐ XE",
                width: 70,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                footerTemplate: "<div style='text-align: left;'><strong>#=kendo.toString(count,'n0')#</strong> Xe</div>",
            },
            {
                field: "BienSoDi",
                title: "BIỂN SỐ ĐI",
                width: 70,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                footerTemplate: "<div style='text-align: left;'><strong>#=kendo.toString(count,'n0')#</strong> Xe</div>",
            },
            {
                field: "TenTuyen",
                title: "TUYẾN",
                width: 160,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                footerTemplate: "<div style='text-align: left;'><strong>#=kendo.toString(count,'n0')#</strong> Tuyến</div>",
            },
            {
                field: "LT_MaTuyen",
                title: "MÃ TUYẾN",
                width: 80,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                footerTemplate: "#=count#"
            },
            {
                field: "TenCongTy",
                title: "ĐƠN VỊ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                footerTemplate: "#=count#"
            },
            {
                field: "SucChua",
                title: "SỨC CHỨA",
                width: 50,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                attributes: { style: "text-align: right;" },
                footerTemplate: "#=sum#"
            },
            {
                field: "GioXuatBenKeHoach",
                title: "GIỜ XUẤT BẾN KẾ HOẠCH",
                width: 60,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                footerTemplate: "#=count#"
            },
            {
                field: "GioRaBen",
                title: "GIỜ THỰC TẾ",
                width: 60,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                footerTemplate: "#=count#"
            },
            {
                field: "SoKhach",
                title: "SỐ KHÁCH",
                width: 50,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                attributes: { style: "text-align: right;" },
                footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> K</div>",
                format: "{0:n0}",
            },
            {
                field: "GhiChu",
                title: "GHI CHÚ",
                width: 50,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                attributes: { style: "font-size: 12px;" }
            }
        ]
    })
};
/*=================================================================================================================================*/
function BaoCaoHoatDongThuongXuyen(id, data) {
    var ttt = "#" + id;
    $(ttt).kendoGrid({
            resizeable: true,
            sortable: false,
            selectable: "row",
            scrollable: true,
            dataSource: {
                data: data,
                pageSize: 100,
                aggregate: [{ field: "TenTuyen", aggregate: "count" },
                            { field: "LT_MaTuyen", aggregate: "count" },
                            { field: "BenDen", aggregate: "count" },
                            { field: "LT_CuLy", aggregate: "sum" },
                            { field: "SoDonVi", aggregate: "sum" },
                            { field: "SoXe", aggregate: "sum" },
                            { field: "SoChuyenDangKy", aggregate: "sum" },
                            { field: "SoLuotXuatBen", aggregate: "sum" },
                ]
            },
            pageable: {
                pageSizes: [25, 50, 100, 150, 200, "all"],
                numeric: true,
                info: false
            },
            dataBinding: function () {
                record = 0;
                $('.k-grid-content').height($(window).height() - otherElementsHeightThongTinXe);
            },
            columns: [
                 {
                     hidden: true,
                     title: "ID TUYẾN",
                     field: "LT_IdLuongTuyen",
                 },
                {
                    title: "STT",
                    template: "#= ++record #",
                    width: 30,
                    headerAttributes: {
                        "class": "table-header-cell",
                        style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                    },
                    footerTemplate: "TỔNG:"
                }, {
                    field: "TenTuyen",
                    template: '<a target="_blank" href="#=URL#">#=TenTuyen#</a>',
                    title: "TÊN TUYẾN",
                    width: 120,
                    headerAttributes: {
                        "class": "table-header-cell",
                        style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                    },
                    footerTemplate: "<div style='text-align: left;'><strong>#=kendo.toString(count,'n0')#</strong> Tuyến</div>",
                },
                {
                    field: "LT_MaTuyen",
                    template: '<a href="#=KiTu#" onclick="#=URL1#">#=LT_MaTuyen#</a>',
                    title: "MÃ TUYẾN",
                    width: 50,
                    headerAttributes: {
                        "class": "table-header-cell",
                        style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                    },
                    footerTemplate: "<div style='text-align: left;'><strong>#=kendo.toString(count,'n0')#</strong> </div>",
                },
                {
                    field: "BenDen",
                    title: "BẾN ĐẾN",
                    width: 70,
                    headerAttributes: {
                        "class": "table-header-cell",
                        style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                    },
                    footerTemplate: "<div style='text-align: left;'><strong>#=kendo.toString(count,'n0')#</strong> </div>",
                },
                {
                    field: "LT_CuLy",
                    title: "CỰ LY",
                    width: 50,
                    headerAttributes: {
                        "class": "table-header-cell",
                        style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                    },
                    attributes: { style: "text-align: right;" },
                    footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> Km</div>",
                    format: "{0:n0}",
                },
                {
                    field: "SoDonVi",
                    template: '<a href="#=KiTu#" onclick="#=URL2#">#=SoDonVi#</a>',
                    title: "SỐ ĐƠN VỊ",
                    width: 30,
                    headerAttributes: {
                        "class": "table-header-cell",
                        style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                    },
                    attributes: { style: "text-align: right;" },
                    footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> </div>",
                    format: "{0:n0}",
                },
                {
                    field: "SoXe",
                    template: '<a href="#=KiTu#" onclick="#=URL3#">#=SoXe#</a>',
                    title: "SỐ XE",
                    width: 30,
                    headerAttributes: {
                        "class": "table-header-cell",
                        style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                    },
                    attributes: { style: "text-align: right;" },
                    footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> </div>",
                    format: "{0:n0}",
                },
                {
                    field: "SoChuyenDangKy",
                    title: "SỐ CHUYẾN ĐĂNG KÝ",
                    width: 30,
                    headerAttributes: {
                        "class": "table-header-cell",
                        style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                    },
                    attributes: { style: "text-align: right;" },
                    footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> </div>",
                    format: "{0:n0}",
                },
                {
                    field: "SoLuotXuatBen",
                    title: "SỐ CHUYẾN THỰC HIỆN",
                    width: 30,
                    headerAttributes: {
                        "class": "table-header-cell",
                        style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                    },
                    attributes: { style: "text-align: right;" },
                    footerTemplate: "<div style='text-align: right;'><strong>#=kendo.toString(sum,'n0')#</strong> </div>",
                    format: "{0:n0}",
                }
            ]
        });
}
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
                style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
            },
            groupFooterTemplate: "TỔNG:",
            footerTemplate: "TỔNG:"
        }, {
            field: "ngay",
            title: "NGÀY",
            width: 100,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
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
                style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
            }
        },
        {
            field: "sochuyenthucte",
            title: "SỐ CHUYẾN THỰC TẾ",
            width: 100,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
            }
        },
        {
            field: "chenhlech",
            title: "CHÊNH LỆCH",
            width: 100,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
            }
        },
        {
            field: "tile",
            title: "TỈ LỆ (%)",
            width: 100,
            headerAttributes: {
                "class": "table-header-cell",
                style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
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
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                }
            },
            {
                field: "plateNumber",
                title: "NGÀY",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                //groupFooterTemplate: "#=count#"
            },
            {
                field: "sochuyenkehoach",
                title: "SỐ CHUYẾN KẾ HOẠCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                }
            },
            {
                field: "sochuyenthucte",
                title: "SỐ CHUYẾN THỰC TẾ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                },
                //template: '<a target="_blank" href="#=URL#">#=TenTuyen#</a>',
            },
            {
                field: "chenhlech",
                title: "CHÊNH LỆCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                }
            },
            {
                field: "tile",
                title: "TỈ LỆ (%)",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
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
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                }
            },
            {
                field: "ngay",
                title: "NGÀY",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                }
            },
            {
                field: "sochuyenkehoach",
                title: "SỐ CHUYẾN KẾ HOẠCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                }
            },
            {
                field: "sochuyenthucte",
                title: "SỐ CHUYẾN THỰC TẾ",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                }
            },
            {
                field: "chenhlech",
                title: "CHÊNH LỆCH",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                }
            },
            {
                field: "tile",
                title: "TỈ LỆ (%)",
                width: 100,
                headerAttributes: {
                    "class": "table-header-cell",
                    style: "text-align: center; font-weight: bold; font-size: 14px; white-space: normal; vertical-align: middle; background: #AEAAAA;"
                }
            }
        ]
    })
};
