import "angular";
import "angular-mocks";
import "../src/index.js";

describe('Person List', function() {
  
  beforeEach(angular.mock.module('angularApp'));

  describe('PersonListController', function() {
    var $httpBackend, ctrl;

    beforeEach(angular.mock.inject(function($componentController, _$httpBackend_) {
      $httpBackend = _$httpBackend_;
      $httpBackend.expectGET('http://localhost/api/Person')
                  .respond([{FirstName: 'Serkan'}, {FirstName: 'postTest2'}]);

      ctrl = $componentController('personList');
    }));

    it('should create a `employees` property with 2 people fetched with `$http`', function() {
    
      $httpBackend.flush();
      expect(ctrl.employees).toEqual([{FirstName: 'Serkan'}, {FirstName: 'postTest2'}]);
    });

    it('should set a default value for the `orderProp` property', function() {
      expect(ctrl.orderProp).toBe('Id');
      
    });

  });

});