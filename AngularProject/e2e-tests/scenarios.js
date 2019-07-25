describe('Angular Application', function() {
  
    it('should filter the person list as a user types into the search box', async function() {
  
      await browser.get('/');

      var query = element(by.model('$ctrl.query'));
      var personList = element.all(by.repeater('person in $ctrl.employees'));

      expect(personList.count()).toBe(4); // DB contains 4 people

      query.sendKeys('test');
      expect(personList.count()).toBe(2); // postTest2 and test4

      query.clear();
      query.sendKeys('serkan');
      expect(personList.count()).toBe(1); // Serkan
    });

});
