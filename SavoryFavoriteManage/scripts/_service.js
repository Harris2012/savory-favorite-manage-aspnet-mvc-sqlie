function SavoryFavoriteManageService($resource, $q) {

    var resource = $resource('api/search-support', {}, {

        favorite_items: { method: 'POST', url: 'api/favorite/items' },
        favorite_item: { method: 'POST', url: 'api/favorite/item' },
        favorite_count: { method: 'POST', url: 'api/favorite/count' },
        favorite_update: { method: 'POST', url: 'api/favorite/update' },
        favorite_enable: { method: 'POST', url: 'api/favorite/enable' },
        favorite_disable: { method: 'POST', url: 'api/favorite/disable' },
        favorite_create: { method: 'POST', url: 'api/favorite/create' },
        favorite_editable: { method: 'POST', url: 'api/favorite/editable' },
        favorite_empty: { method: 'POST', url: 'api/favorite/empty' },

        category_items: { method: 'POST', url: 'api/category/items' },
        category_item: { method: 'POST', url: 'api/category/item' },
        category_count: { method: 'POST', url: 'api/category/count' },
        category_update: { method: 'POST', url: 'api/category/update' },
        category_enable: { method: 'POST', url: 'api/category/enable' },
        category_disable: { method: 'POST', url: 'api/category/disable' },
        category_create: { method: 'POST', url: 'api/category/create' },
        category_editable: { method: 'POST', url: 'api/category/editable' },
        category_empty: { method: 'POST', url: 'api/category/empty' },

        user_profile: { method: 'POST', url: 'api/user/profile' }
    });

    return {

        favorite_items: function (request) { var d = $q.defer(); resource.favorite_items({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        favorite_item: function (request) { var d = $q.defer(); resource.favorite_item({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        favorite_update: function (request) { var d = $q.defer(); resource.favorite_update({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        favorite_count: function (request) { var d = $q.defer(); resource.favorite_count({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        favorite_enable: function (request) { var d = $q.defer(); resource.favorite_enable({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        favorite_disable: function (request) { var d = $q.defer(); resource.favorite_disable({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        favorite_create: function (request) { var d = $q.defer(); resource.favorite_create({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        favorite_editable: function (request) { var d = $q.defer(); resource.favorite_editable({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        favorite_empty: function (request) { var d = $q.defer(); resource.favorite_empty({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },

        category_items: function (request) { var d = $q.defer(); resource.category_items({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        category_item: function (request) { var d = $q.defer(); resource.category_item({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        category_update: function (request) { var d = $q.defer(); resource.category_update({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        category_count: function (request) { var d = $q.defer(); resource.category_count({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        category_enable: function (request) { var d = $q.defer(); resource.category_enable({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        category_disable: function (request) { var d = $q.defer(); resource.category_disable({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        category_create: function (request) { var d = $q.defer(); resource.category_create({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        category_editable: function (request) { var d = $q.defer(); resource.category_editable({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },
        category_empty: function (request) { var d = $q.defer(); resource.category_empty({}, request, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; },

        user_profile: function () { var d = $q.defer(); resource.user_profile({}, function (result) { d.resolve(result); }, function (result) { d.reject(result); }); return d.promise; }
    }
}
