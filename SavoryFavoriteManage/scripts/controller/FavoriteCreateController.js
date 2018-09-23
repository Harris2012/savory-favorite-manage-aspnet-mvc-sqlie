function FavoriteCreateController($scope, $state, $stateParams, SavoryFavoriteManageService) {

    function favorite_empty_callback(response) {

        if (response.status != 1) {
            swal(response.message);
            return;
        }

        $scope.item = response.item;
        {
            if($scope.item.categoryId.length > 0)
            {
                $scope.item.category_id_value = $scope.item.categoryId[0].categoryId;
            }
        }
    }

    function favorite_create_callback(response) {

        $scope.waiting = false;

        if (response.status != 1) {
            $scope.message = response.message;
            return;
        }

        $state.go('app.favorite-list');
    }

    $scope.confirmCreate = function () {

        $scope.waiting = true;
        $scope.message = null;

        var request = {};
        request.id = $scope.item.id;
        request.host = $scope.item.host;
        request.title = $scope.item.title;
        request.categoryId = $scope.item.category_id_value;

        SavoryFavoriteManageService.favorite_create(request).then(favorite_create_callback)
    }

    {
        SavoryFavoriteManageService.favorite_empty({}).then(favorite_empty_callback);
    }
}
