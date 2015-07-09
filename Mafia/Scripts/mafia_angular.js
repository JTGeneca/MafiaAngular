var myApp = angular.module("MyApp", []);

myApp.factory("MafiaRole", function () {
    return function (name, imgSrc, id) {
        this.Id = id;
        this.Name = name;
        this.Url = imgSrc;
        this.IsSelected = true;
        this.Count = 0;
        this.PlayerName = "";
    };
});
myApp.factory("Game", function() {
    return function(id, roles, alive, dead)
    {
        this.Id = id;
        this.Roles = roles;
        this.Alive = alive;
        this.Dead = dead;
    };
})
myApp.controller("MafiaCtrl", function ($scope, MafiaRole, Game, $http) {
    var g = new Game(0, $scope.roles, $scope.roles, $scope.roles);
    $http.post("http://mafiaangular.apphb.com/API/Mafia", g);
    $scope.roles = [];
    $scope.curId = 0;
    $scope.suggest = [];
    var currentRoleIndex = null;
    role = new MafiaRole("Barman", "/Pictures/Barman.jpg", 0);
    $scope.suggest.push(role);
    var role = new MafiaRole("Civilian", "/Pictures/Civilian.jpg", 0);
    $scope.suggest.push(role);
    role = new MafiaRole("Cupid", "/Pictures/Cupid.jpg", 0);
    $scope.suggest.push(role);
    role = new MafiaRole("Detective", "/Pictures/Detective.jpg", 0);
    $scope.suggest.push(role);
    role = new MafiaRole("Doctor", "/Pictures/Doctor.jpg", 0);
    $scope.suggest.push(role);
    role = new MafiaRole("Godfather", "/Pictures/Godfather.jpg", 0);
    $scope.suggest.push(role);
    role = new MafiaRole("Grandma With A Gun", "/Pictures/GrandmaWithAGun.jpg", 0);
    $scope.suggest.push(role);
    role = new MafiaRole("Lawyer", "/Pictures/Lawyer.jpg", 0);
    $scope.suggest.push(role);
    role = new MafiaRole("Mafia", "/Pictures/Mafia.jpg", 0);
    $scope.suggest.push(role);
    role = new MafiaRole("Magician", "/Pictures/Magician.jpg", 0);
    $scope.suggest.push(role);
    role = new MafiaRole("Miller", "/Pictures/Miller.jpg", 0);
    $scope.suggest.push(role);
    role = new MafiaRole("Moderator", "/Pictures/Moderator.jpg", 0);
    $scope.suggest.push(role);
    role = new MafiaRole("Postman", "/Pictures/Postman.jpg", 0);
    $scope.suggest.push(role);
    role = new MafiaRole("RivalMafia", "/Pictures/RivalMafia.jpg", 0);
    $scope.suggest.push(role);
    role = new MafiaRole("SerialKiller", "/Pictures/SerialKiller.jpg", 0);
    $scope.suggest.push(role);
    role = new MafiaRole("UndercoverCop", "/Pictures/UndercoverCop.jpg", 0);
    $scope.suggest.push(role);
    role = new MafiaRole("Vigilante", "/Pictures/Vigilante.jpg", 0);
    $scope.suggest.push(role);


    $scope.roleClick = function (role, idx) {
        if (currentRoleIndex != null) {
            $scope.roles[currentRoleIndex].IsSelected = false;
        }
        currentRoleIndex = idx;
        role.IsSelected = true;
        $scope.activeRole = role;
    }
    $scope.saveClick = function () {
        if (currentRoleIndex != null) {
            var role = new MafiaRole($scope.activeRole.Name, $scope.activeRole.Url, $scope.roles[currentRoleIndex].Id);
            console.log(role);
            $http.post("/API/Mafia", role);
            $scope.roles[currentRoleIndex] = role;
        }
    }
    $scope.addClick = function () {
        if (currentRoleIndex != null) {
            $scope.roles[currentRoleIndex].IsSelected = false;
        }
        var role = new MafiaRole("New Entry Name", "https://lh4.ggpht.com/C_y-hm52-BG_Dmd2mp1ZzBSHkziGPYZg1EnGwO5NCkkVVRfdg52KEna2MjgSHW4R5-U=w300", $scope.curId);
        currentRoleIndex = $scope.roles.length;
        $scope.curId++;
        $scope.roles.push(role);
        $scope.activeRole = role;
        $http.post("/API/Mafia", role);
    }
    $scope.deleteClick = function () {
        if (currentRoleIndex != null) {
            $http.delete("/API/Mafia/" + $scope.roles[currentRoleIndex]);
            $scope.suggest.push($scope.activeRole);
            $scope.roles.splice(currentRoleIndex, 1);
            currentRoleIndex = null;
            $scope.curId--; 
        }
    }
    $scope.suggestClick = function (role, idx) {
        if (currentRoleIndex != null) {
            $scope.roles[currentRoleIndex].IsSelected = false;
        }
        $scope.activeRole = role;
        role.Id = $scope.curId;
        $scope.curId++;
        currentRoleIndex = $scope.roles.length;
        $scope.roles.push(role);
        $http.post("/API/Mafia", role);
        $scope.suggest.splice(idx, 1);
    }
});