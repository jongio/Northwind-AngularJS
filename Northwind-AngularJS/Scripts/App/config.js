app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/employees', {
            templateUrl: '/scripts/app/partials/employees.html',
            controller: 'EmployeesCtrl'
        })
        .when('/customers', {
            templateUrl: '/scripts/app/partials/customers.html',
            controller: 'CustomersCtrl'
        });
}]);