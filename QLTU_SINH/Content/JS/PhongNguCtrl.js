var app = angular.module("myApp", []);
app.controller('PhongNguCtrl', function ($scope, $http) {
    $scope.maphong = '';
    $scope.LoadDanhSachDanhMucKho = function () {
        var data = {
            maphong: $scope.maphong
         
        }
        $http.post(origin + '/api/Api_PhongNgu/DanhSachPhongNgu', data).then(function (response) {
            $scope.ListPhongNgu = response.data;
        })
    }
    $scope.LoadDanhSachDanhMucKho();

    
    $scope.tenphong = '';
    $scope.kichthuoc = '';
    $scope.loaiphong = '';


    $scope.AddPhongNgu = () => {


        var data = {
            MA_PHONG: $scope.maphong,
            TEN_PHONG: $scope.tenphong,
            LOAI_PHONG: $scope.loaiphong,
            KICH_THUOC: $scope.kichthuoc,
           
        }
       
          $http.post(origin + '/api/Api_PhongNgu/ThemPhongNgu', data).then(function (response)
          {

              if (response.status == 200) {
                  console.log('thành công')
                  $scope.LoadDanhSachDanhMucKho();
                    $("#form").submit();
                }
                else {
                    ErrorSystem(response.data)
                }
            })
    }
    //
    $scope.dm = {};
    $scope.GetDM = function (item) {
        $scope.dm = item;
    };
    //
    $scope.SavePhongNgu = function (dm) {
        console.log(dm);
        var data_edit = {
            MA_PHONG: dm.MA_PHONG,
            TEN_PHONG: dm.TEN_PHONG,
            LOAI_PHONG: dm.LOAI_PHONG,
            KICH_THUOC: dm.KICH_THUOC
      

        }
        console.log(data_edit);
        $http.post(origin + '/api/Api_PhongNgu/SuaPhongNgu', data_edit).then(function (response) {
            console.log(response)
            if (response.status == 200) {
                SuccessSystem('Cập nhật nhân viên thành công!')
            
                dm.MA_PHONG = '';
                dm.TEN_PHONG = '';
                dm.LOAI_PHONG = '';
                dm.KICH_THUOC = '';
                $scope.LoadDanhSachDanhMucKho();
            }
            else {
                ErrorSystem(response.data);
            }
        }, function (error) {
            ConnectFail();
        });

    };
    //
    $scope.XoaPhong = function (maphong) {
        var x = confirm("Bạn có chắc muốn xóa mã hàng này không?")
        if (x) {

       
        var data = {
            maphong: maphong
        }
        $http.post(origin + '/api/Api_PhongNgu/XoaPhongNgu', data).then(function (response) {
            $scope.LoadDanhSachDanhMucKho();
            console.log('Thành công')

        })
        }

    }
    
    $scope.GetDSTuSinh = function (maphong) {
      
        $('#CTTuSinh').modal('show')
        var data = {
            maphong: maphong
        }
        $http.post(origin + '/api/Api_PhongNgu/GetDSTuSinhPhongNgu', data).then(function (response) {
            $scope.ListTuSinhPhongNgu = response.data;
            console.log('Thành công')

        })

    }


});
