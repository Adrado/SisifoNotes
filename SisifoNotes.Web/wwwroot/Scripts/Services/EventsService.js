class EventsService extends CRUDService
{
    constructor($http, $window)
    {
        super($http, "api/events/", $window);
    }
}

app.service("$EventsService", EventsService);