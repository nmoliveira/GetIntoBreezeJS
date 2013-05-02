/// <reference path="..\breeze.debug.js" />
(function (root) {
    var ko = root.ko,
        breeze = root.breeze;

    // service name is route to the Web API controller
    var serviceName = 'breeze/GetIntoBreeze';

    // manager is the service gateway and cache holder
    var manager = new breeze.EntityManager(serviceName);

    // define the viewmodel
    var vm = {
        cities: ko.observableArray(),
        show: ko.observable(false),
        searchCountry: ko.observable(''),
        searchCity: ko.observable(''),
        selOrderBy: ko.observable(''),
        selOrderType: ko.observable(''),
        filterCities: filterCities
    };

    // start fetching Cities
    getCities();

    // bind view to the viewmodel
    ko.applyBindings(vm);

    // get Cities asynchronously
    // returning a promise to wait for     
    function getCities() {
        var query = breeze.EntityQuery.from('Cities');
        // filter by country
        if (vm.searchCountry() !== '') {
            var pCountry = new breeze.Predicate('CountryName', '==', vm.searchCountry());
        }
        // filter by city
        if (vm.searchCity() !== '') {
            var pCity = new breeze.Predicate('CityName', '==', vm.searchCity());
        }
        // append filters to query
        var predicates = [];
        if (pCountry) {
            predicates.push(pCountry);
        }
        if (pCity) {
            predicates.push(pCity);
        }
        var filter = breeze.Predicate.and(predicates);
        query = query.where(filter);
        // Order by
        if (vm.selOrderBy() !== '') {
            query = query.orderBy(vm.selOrderBy() + ' ' + vm.selOrderType());
        }
        // execute query
        return manager
            .executeQuery(query)
            .then(querySucceeded)
            .fail(queryFailed);
        // reload vm.countries with the results 
        function querySucceeded(data) {
            vm.cities(data.results);
            vm.show(true); // show the view
        }
        // error getting data
        function queryFailed(error) {
            alert("Query failed: " + error.message);
        }
    };
    
    // filter cities 
    function filterCities() {
        getCities();
    }
}(window));