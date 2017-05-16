$("#menu-toggle").click(function (e) {
    e.preventDefault();
    $("#wrapper").toggleClass("active");
});

var appEIS = angular.module('appEIS', ['ngRoute', 'angularUtils.directives.dirPagination']);

//appEIS.run(function ($rootScope, $cookies, $http) {
//    if ($cookies.get("Auth") == null) {
//        $cookies.put("Auth", "false");
//    }
//    $rootScope.Auth = $cookies.get("Auth");
//});

appEIS.config(function ($routeProvider) {
    $routeProvider.when('/Home', { templateUrl: 'Views/Common/Home/Home.html', controller:'homeController'});
    $routeProvider.when('/Login', { templateUrl: 'Views/Common/Login/Login.html', controller: 'loginController' });
    $routeProvider.when('/RecoverPassword', { templateUrl: 'Views/Common/RecoverPassword/RecoverPassword.html', controller: 'recoverPasswordController'});
    $routeProvider.when('/EmployeeManagement', { templateUrl: 'Views/Employee/EmployeeMgmt/EmployeeMgmt.html', controller: 'employeeMgmtController' });
    $routeProvider.when('/EmployeeProfile/:EmployeeId?', { templateUrl: 'Views/Employee/EmployeeUpdate/EmployeeUpdate.html', controller: 'employeeUpdateController' });


    $routeProvider.when('/Logout', {
        //resolve: {
        //    auth: function ($rootScope, $location, $cookies) {
        //        $cookies.put("Auth", "false");
        //        $rootScope.Auth = $cookies.get("Auth");

        //        $cookies.put("EmpSignIn", null);
        //        $rootScope.EmpSignIn = $cookies.get("EmpSignIn");

        //        $location.path('/Login');
        //    }
        //}
    });

    $routeProvider.otherwise({ redirectTo: '/Home' });

    //$locationProvider.html5Mode(true);
});

appEIS.directive('fileModel', function ($parse) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            var model = $parse(attrs.fileModel);
            var modelSetter = model.assign;
            element.bind('change', function () {
                scope.$apply(function () {
                    modelSetter(scope, element[0].files[0]);
                });
            });
        }
    };
});

appEIS.factory("utilityService", function ($http) {
    utilityObj = {};

    utilityObj.randomPassword = function () {
        return Math.random().toString(36).substr(2, 5);
    };

    utilityObj.myAlert = function () {
        $("#alert").fadeTo(2000, 500).slideUp(1000, function () {
            $("#alert").slideUp(1000);
        });
    };

    utilityObj.uploadFile = function (file, uploadUrl, eid) {
        var fd = new FormData();
        fd.append('file', file);
        var Img;
        Img = $http({
            method: 'Post', url: uploadUrl + eid, data: fd, transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        }).
            then(function (response) {
                return response.data;
            }, function (error) {
                return error.data;
            });
        return Img;
    }

    utilityObj.getFile = function (getFileUrl, eid) {
        var Emps;
        Emps = $http({ method: 'Get', url: getFileUrl, params: { Id: eid } }).
        then(function (response) {
            return response.data;
        });
        return Emps;
    };
    return utilityObj;
});