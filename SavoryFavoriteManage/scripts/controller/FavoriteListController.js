function FavoriteListController($scope, $state, $stateParams, SavoryFavoriteManageService) {

    function favorite_items_callback(response) {

        $scope.items_loaded = true;

        if (response.status !== 1) {
            $scope.items_message = response.message;
            return;
        }

        $scope.items = response.items;
    }

    function favorite_count_callback(response) {

        $scope.count_loaded = true;
        if (response.status !== 1) {
            $scope.count_message = response.message;
            return;
        }

        $scope.totalCount = response.totalCount;
    }

    $scope.pageChanged = function () {

        $scope.items_loaded = false;
        $scope.items_message = null;

        var request = {};

        request.pageIndex = $scope.currentPage;

        SavoryFavoriteManageService.favorite_items(request).then(favorite_items_callback);
    }

    {
        $scope.maxSize = 10;
        $scope.currentPage = 1;
        $scope.pageSize = 20;

        SavoryFavoriteManageService.favorite_count({}).then(favorite_count_callback);
        SavoryFavoriteManageService.favorite_items({pageIndex: $scope.currentPage}).then(favorite_items_callback);
    }

}
