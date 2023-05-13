var app = angular.module("myApp", []);
app.controller('TuSinhCtrl', function ($scope, $http) {

    $scope.LoadDanhSachTuSinh = function () {
        var data = {
            sothe: $scope.sothe,
            hoten: $scope.hoten

        }
        $http.post(origin + '/api/Api_TuSinh/DanhSachTuSinh', data).then(function (response) {
            $scope.ListTuSinh = response.data;
        })
    }
    $scope.LoadDanhSachTuSinh();

    $scope.maphong = '';
    $scope.tenphong = '';
    $scope.kichthuoc = '';
    $scope.loaiphong = '';
    $scope.idphong = '';

    $scope.AddTuSinhMoi = () => {


        var data = {
            SO_THE: $scope.sothe,
            HO_TEN: $scope.hovaten,
            NAM_SINH: $scope.namsinh,
            GIOI_TINH: $scope.gioitinh,
            QUE_QUAN: $scope.quequan,
            TEN_PHU_HUYNH: $scope.tenphuhuynh,
            SDT: $scope.sdt,
            ID_PHONG: $scope.idphong,
            ID_KHOA_TU: $scope.ID_KHOA_TU_SELLECTED,
        }
        console.log(data);
        $http.post(origin + '/api/Api_TuSinh/ThemTuSinhMoi', data).then(function (response) {

            if (response.status == 200) {
                console.log('thành công')
                $scope.LoadDanhSachTuSinh();
                $("#form").submit();
            }
            else {
                ErrorSystem(response.data)
            }
        })
    }
    ////
    $scope.ts = {};
    $scope.GetTS = function (item) {
        $scope.ts = item;
    };

    ////
    $scope.SaveTS = function (ts) {
        console.log(ts);
        var data_edit = {
            SO_THE: ts.SO_THE,
            HO_TEN: ts.HO_TEN,
            NAM_SINH: ts.NAM_SINH,
            GIOI_TINH: ts.GIOI_TINH,
            TEN_PHU_HUYNH: ts.TEN_PHU_HUYNH,
            SDT: ts.SDT,
            QUE_QUAN: ts.QUE_QUAN,
            ID_PHONG: $scope.idphong


        }
        console.log(data_edit);
        $http.post(origin + '/api/Api_TuSinh/SuaTuSinh', data_edit).then(function (response) {
            console.log(response)
            if (response.status == 200) {
                SuccessSystem('Cập nhật tu sinh!')
                $scope.LoadDanhSachDanhMucKho();
                ts.SO_THE = '';
                ts.HO_TEN = '';
                ts.NAM_SINH = '';
                ts.GIOI_TINH = '';
                ts.TEN_PHU_HUYNH = '';
                ts.SDT = '';
                ts.QUE_QUAN = '';
                ts.TEN_PHONG = '';

            }
            else {
                ErrorSystem(response.data);
            }
        }, function (error) {
            ConnectFail();
        });

    };
    ////
    $scope.SearchPhongNgu = (maphong) => {
        var data_pn = {
            maphong: $scope.maphong
            
        }
        $http.post(origin + '/api/Api_PhongNgu/DanhSachPhongNgu', data_pn).then(function (response) {
            $scope.PhongNgus = response.data
        }, function (err) {
            ErrorSystem(err.data)
        });
    }
    $scope.SelectPhongNgu = (item) => {
        $scope.tenphong = item.TEN_PHONG,
         $scope.idphong = item.ID
    }
    $scope.SelectPhongNgu1 = (item) => {
        $scope.ts.TEN_PHONG = item.TEN_PHONG,
            $scope.idphong = item.ID
    }
    $scope.XoaTuSinh = function (sothe) {
        var data = {
            sothe : sothe
            
        }
        $http.post(origin + '/api/Api_TuSinh/XoaTuSinh', data).then(function (response) {
            $scope.LoadDanhSachTuSinh();
            console.log('Thành công')

        })

    }
    $scope.LoadDanhSachKhoaTu = function () {
        var data = {
            makhoatu: $scope.makhoatu

        }
        $http.post(origin + '/api/Api_KhoaTu/DanhSachKhoaTu', data).then(function (response) {
            $scope.ListKhoaTu = response.data;
        })
    }
    $scope.LoadDanhSachKhoaTu();

    $scope.GetPhongNguByGT = () => {
        var data_pn = {
            gioitinh: $scope.gioitinh,
            tukhoa: $scope.tenphong

        }
        $http.post(origin + '/api/Api_PhongNgu/DanhSachPhongNguTheoGioiTinh', data_pn).then(function (response) {
            $scope.PhongNgusTheoGioiTinh = response.data
        }, function (err) {
            ErrorSystem(err.data)
        });
    }
    $scope.GetPhongNguByGT1 = () => {
        var data_pn = {
            gioitinh: $scope.ts.GIOI_TINH,
            tukhoa: $scope.ts.TEN_PHONG

        }
        $http.post(origin + '/api/Api_PhongNgu/DanhSachPhongNguTheoGioiTinh', data_pn).then(function (response) {
            $scope.PhongNgusTheoGioiTinh = response.data
        }, function (err) {
            ErrorSystem(err.data)
        });
    }

});
