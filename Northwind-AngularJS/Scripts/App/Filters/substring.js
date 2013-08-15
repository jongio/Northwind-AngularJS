app.filter('substring', function () {
    return function (input, from, to) {
        return typeof to !== 'undefined' ? input.substring(from, to) : input.substring(from);
    };
});