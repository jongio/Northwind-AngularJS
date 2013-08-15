app.directive('jsonOver', function () {
    return {
        restrict: 'A',
        replace: false,
        scope: {jsondata: '@'},
        transclude: true,
        templateUrl: '/scripts/app/directives/templates/jsonover-directive-template.html'
    }
});