function CategoryItemController($scope, $state, $stateParams, SavoryFavoriteManageService) {

    $scope.id = $stateParams.id;

    function category_item_callback(response) {

        $scope.loaded = true;
        if (response.status != 1) {
            return;
        }

        $scope.item = response.item;
    }

    {
        var request = {};
        request.id = $scope.id;

        SavoryFavoriteManageService.category_item(request).then(category_item_callback);
    }
}
