app.service("EmployeeService", function ($http) {

    //get All Employees
    this.getEmployees = function () {
        return $http.get("Test/GetAllEmployees");
    };

    // get Employee by EmployeeId
    this.getEmployee = function (EmployeeId) {
        var response = $http({
            method: "post",
            url: "Test/GetEmployeeById",
            params: {
                id: JSON.stringify(EmployeeId)
            }
        });
        return response;
    }

    // Update Employee 
    this.updateEmployee = function (Employee) {
        var response = $http({
            method: "post",
            url: "Test/UpdateEmployee",
            data: JSON.stringify(Employee),
            dataType: "json"
        });
        return response;
    }

    // Add Employee
    this.AddEmployee = function (Employee) {
        var response = $http({
            method: "post",
            url: "Test/AddEmployee",
            data: JSON.stringify(Employee),
            dataType: "json"
        });
        return response;
    }

    //Delete Employee
    this.DeleteEmployee = function (EmployeeId) {
        var response = $http({
            method: "post",
            url: "Test/DeleteEmployee",
            params: {
                EmployeeId: JSON.stringify(EmployeeId)
            }
        });
        return response;
    }
});