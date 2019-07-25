import angular from 'angular'
import ngRoute from 'angular-route'
import { PersonService } from './person.service';

'use strict';

angular.module('person', ['ngRoute'])

.service('PersonService', PersonService)

.config(['$routeProvider', function($routeProvider) {
    $routeProvider.when('/person', {
        templateUrl: 'person/index.html',
        controller: 'PersonCtrl'
    });
}])

.controller('PersonCtrl', ['PersonService', '$route', function(PersonService, $route) {
    var self = this;
    self.PersonService = PersonService;
    self.employees = PersonService.getPersons().then(function(response) {
        self.employees = response.data;
    });

    self.toBeUpdated = (Id, LastName, FirstName, Email) => {
        console.log("toBeUpdated called!");
        PersonService.toBeUpdated = { "Id": Id, "LastName": LastName, "FirstName": FirstName, "Email": Email};
        console.log(PersonService.toBeUpdated);
    };

    self.toBeDeleted = (Id) => {
        console.log("toBeDeleted called!");
        PersonService.deletePerson(Id).then(function(response) {
            // reload page
            $route.reload();
        });
    };

}]);