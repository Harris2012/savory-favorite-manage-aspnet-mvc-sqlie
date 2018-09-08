function CategoryCreateController($scope, $state, $stateParams, SavoryFavoriteService) {

    function category_empty_callback(response) {

        if (response.status != 1) {
            console.log(response.message);
            return;
        }

        $scope.item = response.item;
    }

    function category_create_callback(response) {

        $scope.waiting = false;

        if (response.status != 1) {
            $scope.message = response.message;
            return;
        }

        $state.go('app.category-list');
    }

    $scope.confirmCreate = function () {

        $scope.waiting = true;
        $scope.message = null;

        var request = {};
        request.id = $scope.item.id;
        request.categoryId = $scope.item.categoryId;
        request.categoryName = $scope.item.categoryName;
        request.description = $scope.item.description;

        SavoryFavoriteService.category_create(request).then(category_create_callback)
    }

    {
        SavoryFavoriteService.category_empty({}).then(category_empty_callback);
    }
}
