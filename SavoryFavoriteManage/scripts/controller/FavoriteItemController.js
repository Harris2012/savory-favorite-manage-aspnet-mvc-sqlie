function FavoriteItemController($scope, $state, $stateParams, SavoryFavoriteManageService) {

    $scope.id = $stateParams.id;

    function favorite_item_callback(response) {

        $scope.loaded = true;
        if (response.status != 1) {
            return;
        }

        $scope.item = response.item;
    }

    {
        var request = {};
        request.id = $scope.id;

        SavoryFavoriteManageService.favorite_item(request).then(favorite_item_callback);
    }
}
