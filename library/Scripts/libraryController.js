var angular = angular.module("library", ['ngSanitize']);

angular.service("session", function () {

    var userId = "";
    return {

        getUserId: function () {
            return userId;
        },

        setUserId: function (data) {
            userId = data;
        }
    };
});

// Controller to validate form and ajax submit
angular.controller("login", function ($scope, $http, session) {

    var submitUrl = "/user/login";

    $scope.submit = function () {

        // Prepare JSON for ajax submit
        var loginData = ({
            "username": $scope.username,
            "password": $scope.password
        });

        $http.post(submitUrl, loginData).success(function (response) {

            var responseData = response;

            if (responseData === "existing") {

                $scope.loginStatus = "Your session is currently active. Please logout before logging in";
            } else if (responseData === "null") {

                $scope.loginStatus = "Invalid Username/Password. Try again !";
            } else {

                var id = response;
                session.setUserId(id);
                document.getElementById("id").value = id;
                document.forms[0].submit();

                /*  var key = $.param({key: responseData});                
                $http({method: 'POST',url: '../home',data: key,
                headers: {'Content-Type': 'application/x-www-form-urlencoded'}}); */
            }
        }).error(function (response) {
            var data = response;
            alert(data);
        });
    };

});

angular.controller("NewUser", function ($scope, $http) {

    $scope.submit = function () {

        var newUserUrl = "/user/CreateUser";

        var userJson = ({
            "Name": $scope.name,
            "Age": $scope.age,
            "Username": $scope.username,
            "Password": $scope.password
        });

        $http.post(newUserUrl, userJson).success(function (response) {

            if (response === "Success") {
                document.forms[0].submit();
            } else {
                window.location = "../Error";
            }



        });
    }
});

angular.controller("AddBooks", function ($scope, $http, session) {

    $scope.AddBook = function () {

        var submitUrl = "/book/AddBooks";

        var bookJson = ({
            "name": $scope.name,
            "description": $scope.description,
            "author": $scope.author,
            "copies": $scope.copies,
            "price": $scope.price,
            "publisher": $scope.publisher
        });


        $http.post(submitUrl, bookJson)
            .success(function (response) {

                var data = response;
                alert(data);
                window.history.back();

            });
    }
});

angular.controller("RequestBooks", function ($scope, $http, session) {

    var requestUrl = "/request/Add";
    $scope.request = function (bookId, bookName, userId) {
        var status = window.confirm("Do you wanna put a request for " + bookName + " ?");

        if (status) {
            var jsonData = ({
                "bookId": bookId,
                "userId": userId
            });
            $http.post(requestUrl, jsonData).success(function (response) {

                if (response === "Success")
                    alert("Your request for " + bookName + " has been submitted");

                if (response === "Failed")
                    alert("Your request could not be submitted.Please try after sometime");

                window.history.back();
            });
        }
    }
});

angular.controller("ApproveRequest", function ($scope, $http) {
    var approveRequestUrl = "/request/ApproveRequest";
    $scope.approve = function (requestId, bookName, userId) {
        var status = window.confirm("Do you want to approve request for '" + bookName + "' ?");

        if (status) {
            var jsonData = ({
                "requestId": requestId,
                "userId": userId
            });

            $http.post(approveRequestUrl, jsonData).success(function (response) {

                if (response === "Success") {
                    alert("Request for " + bookName + " has been approved");
                    location.reload();
                }

                if (response === "Failed") {
                    alert("Your request could not be submitted.Please try after sometime");
                    window.history.back();
                }


            });
        }
    }

});

angular.controller("ReturnBook", function ($scope, $http) {
    var returnBookUrl = "/request/BookReturn";
    $scope.
    return = function (returnId, userId, bookName) {

        var status = window.confirm("Do you wanna return '" + bookName + "' ?");

        if (status) {
            var jsonData = ({
                "returnId": returnId,
                "userId": userId
            });
            $http.post(returnBookUrl, jsonData).success(function (response) {

                if (response === "Success") {
                    alert(bookName + " has been returned back");
                    location.reload();
                }

                if (response === "Failed") {
                    alert("Your request could not be submitted.Please try after sometime");
                    window.history.back();
                }
            });
        }
    }
});


angular.controller("logout", function ($scope, $http) {

    var logoutUrl = "/user/logout";
    //    var id = session.getUserId();
    //    var userId = ({"id":id});

    $scope.logout = function (data) {

        var id = data;
        var userId = ({
            "id": id
        });

        $http.post(logoutUrl, userId).success(function (data) {

            if (data === "Success")
                window.location = "/user/loginPage";
            else
                window.location = "user/error";
        });

    };

});

angular.controller("bookSearch", function ($scope, $http) {

    var searchUrl = "/book/SearchBook";
    $scope.submitSearch = function (userId) {
        $scope.loadingFlag = true;
        var jsonData = ({
            "searchString": $scope.searchString,
            "userId": userId
        });

        $http.post(searchUrl, jsonData).success(function (data) {

            $scope.loadingFlag = false;
            $scope.resultFlag = true;
            var result = data;
            $scope.result = result;
        });

    };

});

angular.controller("userSearch", function ($scope, $http) {

    var searchUrl = "/user/SearchUser";
    $scope.submitSearch = function (userId) {
        $scope.loadingFlag = true;
        var jsonData = ({
            "searchString": $scope.searchString,
            "userId": userId
        });

        $http.post(searchUrl, jsonData).success(function (data) {

            $scope.loadingFlag = false;
            $scope.resultFlag = true;
            var result = data;
            $scope.result = result;
        });

    };

});