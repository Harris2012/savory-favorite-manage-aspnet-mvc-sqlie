var route = function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.when('', '/welcome').when('/', '/welcome');

    $stateProvider.state('app', {
        url: '/',
        views: {
            'header': { templateUrl: 'scripts/view/view_header.html?v=' + window.releaseNo, controller: HeaderController },
            'main-menu': { templateUrl: 'scripts/view/view_menu.html?v=' + window.releaseNo},
            'main-body': { template: '<div ui-view></div>' }
        }
    });

    $stateProvider.state('app.welcome', { url: 'welcome', templateUrl: 'scripts/view/view_welcome.html?v=' + window.releaseNo });

    $stateProvider.state('app.favorite-list', { url: 'favorite-list', templateUrl: 'scripts/view/view_favorite_list.html?v=' + window.releaseNo, controller: FavoriteListController });
    $stateProvider.state('app.favorite-item', { url: 'favorite-item/:id', templateUrl: 'scripts/view/view_favorite_item.html?v=' + window.releaseNo, controller: FavoriteItemController });
    $stateProvider.state('app.favorite-create', { url: 'favorite-create', templateUrl: 'scripts/view/view_favorite_create.html?v=' + window.releaseNo, controller: FavoriteCreateController });
    $stateProvider.state('app.favorite-update', { url: 'favorite-update/:id', templateUrl: 'scripts/view/view_favorite_update.html?v=' + window.releaseNo, controller: FavoriteUpdateController });

    $stateProvider.state('app.category-list', { url: 'category-list', templateUrl: 'scripts/view/view_category_list.html?v=' + window.releaseNo, controller: CategoryListController });
    $stateProvider.state('app.category-item', { url: 'category-item/:id', templateUrl: 'scripts/view/view_category_item.html?v=' + window.releaseNo, controller: CategoryItemController });
    $stateProvider.state('app.category-create', { url: 'category-create', templateUrl: 'scripts/view/view_category_create.html?v=' + window.releaseNo, controller: CategoryCreateController });
    $stateProvider.state('app.category-update', { url: 'category-update/:id', templateUrl: 'scripts/view/view_category_update.html?v=' + window.releaseNo, controller: CategoryUpdateController });

    $stateProvider.state('app.otherwise', {
        url: '*path',
        templateUrl: 'views/view_404.html?v=' + window.releaseNo
    });
}