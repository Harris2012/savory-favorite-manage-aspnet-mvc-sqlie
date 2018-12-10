function CategoryCreateController($scope, $state, $stateParams, SavoryFavoriteManageService) {

    function category_empty_callback(response) {

        if (response.status != 1) {
            swal(response.message);
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

        SavoryFavoriteManageService.category_create(request).then(category_create_callback)
    }

    {
        SavoryFavoriteManageService.category_empty({}).then(category_empty_callback);
    }
}
