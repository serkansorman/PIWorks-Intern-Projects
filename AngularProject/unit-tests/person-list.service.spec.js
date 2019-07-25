import "angular";
import "angular-mocks";
import "../src/index.js";

describe('PersonService', function () {

    var $httpBackend;
    var PersonService;
    var Persons = [
        { Id: 11, LastName: "test4", FirstName: "test4", Email:"test4@piworks.net"},
        { Id: 13, LastName: "postTest2", FirstName: "postTest2", Email:"postTest2@piworks.net"}
    ];

    beforeEach(function () {
        jasmine.addCustomEqualityTester(angular.equals);
    });

    beforeEach(angular.mock.module("angularApp"));

    beforeEach(angular.mock.inject(function (_$httpBackend_, PersonService) {
        $httpBackend = _$httpBackend_;
        PersonService = PersonService;
    }));

    afterEach(function () {
        $httpBackend.verifyNoOutstandingExpectation();
        $httpBackend.verifyNoOutstandingRequest();
    });


    it('should fetch the person data from the database', function (done) {


        $httpBackend
            .expectGET("http://localhost/api/Person/")
            .respond(Persons);


            PersonService.getPersons().then(response => {
            var persons = response.data;
            expect(persons.length).toEqual(3);
            done();
        });


        $httpBackend.flush();
    });

});