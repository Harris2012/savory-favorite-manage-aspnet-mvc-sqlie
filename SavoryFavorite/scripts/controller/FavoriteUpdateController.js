//新建数据库
function FavoriteUpdateController($scope, $state, $stateParams, SavoryFavoriteService) {

    $scope.id = $stateParams.id;

    function favorite_editable_callback(response) {

        $scope.loaded = true;
        if (response.status != 1) {
            return;
        }

        $scope.item = response.item;
        {
            for (var i = 0; i < $scope.item.categoryId.length; i++) {
                if ($scope.item.categoryId[i].selected) {
                    $scope.item.category_id_value = $scope.item.categoryId[i].categoryId;
                    break;
                }
            }
        }
    }

    function favorite_update_callback(response) {
        if (response.status != 1) {
            return;
        }

        $state.go('app.favorite-item', { id: $scope.id });
    }

    $scope.confirmUpdate = function () {

        $scope.waiting = true;
        $scope.message = null;

        var request = {};
        request.id = $scope.item.id;
        request.host = $scope.item.host;
        request.title = $scope.item.title;
        request.categoryId = $scope.item.category_id_value;

        SavoryFavoriteService.favorite_update(request).then(favorite_update_callback)
    }

    {
        var request = {};
        request.id = $scope.id;

        SavoryFavoriteService.favorite_editable(request).then(favorite_editable_callback);
    }
}
