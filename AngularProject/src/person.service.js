export class PersonService {
    constructor($http) {
        this.$http = $http;
        this.toBeUpdated = {};
    }

    getPersons() {
        return this.$http.get("http://localhost/api/Person");
    }

    putPerson(jsonData) {
        console.log(jsonData);
        return this.$http.put("http://localhost/api/Person", jsonData);
    }

    postPerson(toBeUpdated) {
        console.log(toBeUpdated);
        return this.$http.post("http://localhost/api/Person", toBeUpdated);
    }

    deletePerson(Id) {
        return this.$http.delete("http://localhost/api/Person?Id=" + Id);
    }
}