import angular from 'angular'
import ngRoute from 'angular-route'

'use strict';

angular.module('app', [
    'ngRoute'
]).
    config(['$locationProvider', '$routeProvider', function ($locationProvider, $routeProvider) {
        $locationProvider.hashPrefix('!');

        $routeProvider.otherwise({ redirectTo: '/' });
    }]);




