app.controller('Main', function ($rootScope, $scope, httpService, $timeout) {
    var vm = this;
    vm.prefix ="https://picsum.photos/id";
    vm.init = function () {
        httpService.getPictures(function (data) {
            vm.pictures = data;
            if (data.length > 0) {
                vm.selected = data[0];
            }
            console.log("data fetched");
            console.table(data);
        });
    };
    vm.Select = function (next) {
        for (var i = 0; i < vm.pictures.length; i++) {
            if (vm.pictures[i].Id === vm.selected.Id) {
                vm.selected = next
                    ? vm.pictures[(i + 1) % vm.pictures.length]
                    : vm.pictures[(i - 1) % vm.pictures.length];
                return;
            }
        }
    };
    vm.generateUrl = function (id) {
        return 'https://picsum.photos/id/' + id + '/170/170';
    }
    vm.init();
});

