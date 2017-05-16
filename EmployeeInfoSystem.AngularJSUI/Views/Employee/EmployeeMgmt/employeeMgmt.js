appEIS.factory('employeeMgmtService', function ($http) {
    empMgmtObj = {};
    empMgmtObj.getAll = function () {
        var Emps;
        // calls the Web API
        Emps = $http({ method: 'Get', url: 'http://localhost:61743/api/Employee' }).
        then(function (response) {
            return response.data;
        });
        return Emps
    };

    empMgmtObj.createEmployee = function (emp) {
        var Emp;

        Emp = $http({ method: 'Post', url: 'http://localhost:61743/api/Employee', data: emp }).
        then(function (response) {
            return response.data;

        }, function (error) {
            return error.data;
        });
        return Emp;
    };

    empMgmtObj.deleteEmployeeById = function (eid) {
        var Emps;
        Emps = $http({ method: 'Delete', url: 'http://localhost:61743/api/Employee', params: { id: eid } }).
        then(function (response){
            return response.data;
        });
        return Emps;
    };
    return empMgmtObj;
});

//$http accesses to Web API and returns data in JSON format
// .../api/Employee accesses the data pulled from the Employee class in the Web API project

appEIS.controller('employeeMgmtController', function ($scope, employeeMgmtService, utilityService, $window) {
    $scope.msg = "Welcome To Employee Management";

    employeeMgmtService.getAll().then(function (result) {
        $scope.Emps = result; //store the data in a $scope variable from the Emps object and into the result variable
    });

    $scope.Sort = function (col) {
        $scope.key = col;
        $scope.AscOrDesc = !$scope.AscOrDesc;
    };

    $scope.CreateEmployee = function (Emp, IsValid) {
        if (IsValid) {
            //Emp.Password = Math.random().toString(36).subtr(2, 5);
            //Emp.Password = utilityService.randomPassword();
            employeeMgmtService.createEmployee(Emp).then(function (result) {
                if (result.ModelState == null) {
                    $scope.Msg = " You have successfully created " + result.EmployeeId;
                    $scope.Flg = true;
                    employeeMgmtService.getAll().then(function (result) {
                        $scope.Emps = result; //store the data in a $scope variable from the Emps object and into the result variable
                    });
                    utilityService.myAlert();
                }
                else {
                    $scope.serverErrorsMsgs = result.ModelState;
                }
            });
        };
    };

    $scope.DeleteEmployeeById = function (Emp) {
        if ($window.confirm("Do you want to delete Employee with Id:" + Emp.EmployeeId + "?")) {
            employeeMgmtService.deleteEmployeeById(Emp.EmployeeId).then(function (result) {
                if (result.ModelState == null) {
                    $scope.Msg = " You have successfully deleted " + result.EmployeeId;
                    $scope.Flg = true;
                    utilityService.myAlert();
                    employeeMgmtService.getAll().then (function (result) {
                        $scope.Emps = result;
                    });
                }
                else {
                    $scope.serverErrorsMsgs = result.ModelState;
                }
            });
        }
    };
});