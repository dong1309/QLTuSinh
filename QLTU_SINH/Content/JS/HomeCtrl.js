var app = angular.module("myApp", []);
app.controller('HomeCtrl', function ($scope, $http) {
 
    //$scope.loadHangHoa = function () {
    //    $http.post(origin + '/api/Api_HangHoa/GetDanhSachHangHoa', timkiem).then(function (response) {
    //        $scope.DanhSachHangHoa = response.data;
    //    }, function (error) {
    //        ConnectFail();
    //    });

    //    $http.post(origin + '/api/Api_HangHoa/DemDanhSachHangHoa', timkiem).then(function (response) {
    //        $scope.tongsoHH = response.data;
    //        pagination2.make(parseInt($scope.tongsoHH), sobanghi);
    //    });
    //};
    //$scope.loadHangHoa();

    $scope.username = '';
    console.log('ádad');

});
