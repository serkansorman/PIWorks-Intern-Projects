'use strict';

import './person-list.module'

// Register `phoneList` component, along with its associated controller and template
angular.
  module('personList').
  component('personList', {
    templateUrl: 'person-list.template.html',
    controller: ['$http', function PersonListController($http) {
      var self = this;
      self.orderProp = 'Id';

      $http.get('http://localhost/api/Person').then(function(response) {
        self.employees = response.data;
        console.log(response.data);
      });

    }]
  });
