app.controller("Employee", function ($scope, EmployeeService) {
    $scope.divEmployee = true;
    GetAllEmployees();
    ClearFields();
    $scope.Action = "Add";
    //To Get all Employee records  
    function GetAllEmployees() {
        
        var getEmployeeData = EmployeeService.getEmployees();
        getEmployeeData.then(function (Employee) {
            $scope.Employees = Employee.data;
        }, function () {
            alert('Error in getting Employee records');
        });
    }

    $scope.editEmployee = function (Employee) {
        var getEmployeeData = EmployeeService.getEmployee(Employee.Id);
        getEmployeeData.then(function (_Employee) {
            $scope.Employee = _Employee.data;
            $scope.EmployeeId = Employee.Id;
            $scope.EmployeeFirstname = Employee.Firstname;
            $scope.EmployeeLastname = Employee.Lastname;
            $scope.EmployeeEmailID = Employee.EmailID;
            $scope.EmployeeAddress = Employee.Address;
            $scope.EmployeePhone = Employee.Phone;
            $scope.Action = "Update";
            //$scope.divEmployee = true;
        }, function () {
            alert('Error in getting Employee records');
        });
    }

    $scope.AddUpdateEmployee = function () {
        var Employee = {
            Firstname: $scope.EmployeeFirstname,
            Lastname: $scope.EmployeeLastname,
            EmailID: $scope.EmployeeEmailID,
            Address: $scope.EmployeeAddress,
            Phone: $scope.EmployeePhone
        };
        var getEmployeeAction = $scope.Action;

        if (getEmployeeAction == "Update") {
            Employee.Id = $scope.EmployeeId;
            var getEmployeeData = EmployeeService.updateEmployee(Employee);
            getEmployeeData.then(function (msg) {
                GetAllEmployees();
                $scope.Action = "Add";
                //alert(msg.data);
                ClearFields();
                //$scope.divEmployee = false;
            }, function () {
                alert('Error in updating Employee record');
            });
        } else {
            var getEmployeeData = EmployeeService.AddEmployee(Employee);
            getEmployeeData.then(function (msg) {
                GetAllEmployees();
                ClearFields();
                //alert(msg.data);
               // $scope.divEmployee = false;
            }, function () {
                alert('Error in adding Employee record');
            });
        }
    }

    //$scope.AddEmployeeDiv = function () {
    //    ClearFields();
    //    $scope.Action = "Add";
    //   // $scope.divEmployee = true;
    //}

    $scope.deleteEmployee = function (Employee) {
        var getEmployeeData = EmployeeService.DeleteEmployee(Employee.Id);
        getEmployeeData.then(function (msg) {
            alert(msg.data);
            GetAllEmployees();
        }, function () {
            alert('Error in deleting Employee record');
        });
    }

    function ClearFields() {        
        $scope.EmployeeId = "";
        $scope.EmployeeFirstname = "";
        $scope.EmployeeLastname ="";
        $scope.EmployeeEmailID ="";
        $scope.EmployeeAddress = "";
        $scope.EmployeePhone = "";
    }
    $scope.Cancel = function () {
        ClearFields();
        $scope.Action = "Add";
       // $scope.divEmployee = false;
    };
});