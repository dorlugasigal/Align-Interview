app.service("httpService", function ($http) {

    this.getPictures = function (Callback) {
        $http.get('api/pictures').then(function (data) {
            Callback(data.data);
        });
    };
});