import angular from 'angular'
import ngRoute from 'angular-route'
import './person-list.component.js'
import './person-list.module.js'
import './person.js'




'use strict';

angular.module('angularApp', [
    'ngRoute',
    'personList',
    'person'
]).
config(['$locationProvider', '$routeProvider', function($locationProvider, $routeProvider) {
    $locationProvider.hashPrefix('!');

    $routeProvider.otherwise({ redirectTo: '/' });
}]);