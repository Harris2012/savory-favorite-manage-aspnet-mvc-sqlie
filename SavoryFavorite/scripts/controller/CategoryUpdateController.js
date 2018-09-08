//新建数据库
function CategoryUpdateController($scope, $state, $stateParams, SavoryFavoriteService) {

    $scope.id = $stateParams.id;

    function category_editable_callback(response) {

        $scope.loaded = true;
        if (response.status != 1) {
            return;
        }

        $scope.item = response.item;
    }

    function category_update_callback(response) {
        if (response.status != 1) {
            return;
        }

        $state.go('app.category-item', { id: $scope.id });
    }

    $scope.confirmUpdate = function () {

        $scope.waiting = true;
        $scope.message = null;

        var request = {};
        request.id = $scope.item.id;
        request.categoryId = $scope.item.categoryId;
        request.categoryName = $scope.item.categoryName;
        request.description = $scope.item.description;

        SavoryFavoriteService.category_update(request).then(category_update_callback)
    }

    {
        var request = {};
        request.id = $scope.id;

        SavoryFavoriteService.category_editable(request).then(category_editable_callback);
    }
}
