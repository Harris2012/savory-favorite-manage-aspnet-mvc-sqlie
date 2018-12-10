function CategoryListController($scope, $state, $stateParams, SavoryFavoriteManageService) {

    function category_items_callback(response) {

        $scope.items_loaded = true;

        if (response.status !== 1) {
            $scope.items_message = response.message;
            return;
        }

        $scope.items = response.items;
    }

    function category_count_callback(response) {

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

        SavoryFavoriteManageService.category_items(request).then(category_items_callback);
    }

    {
        $scope.maxSize = 10;
        $scope.currentPage = 1;
        $scope.pageSize = 20;

        SavoryFavoriteManageService.category_count({}).then(category_count_callback);
        SavoryFavoriteManageService.category_items({pageIndex: $scope.currentPage}).then(category_items_callback);
    }

}
