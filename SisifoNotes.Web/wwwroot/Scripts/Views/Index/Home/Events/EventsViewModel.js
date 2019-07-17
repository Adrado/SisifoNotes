class EventsViewModel
{
    constructor($EventsService)
    {
        this.EventsService = $EventsService;
    }
}

app.component('events',
    {
        templateUrl: './Scripts/Views/Index/Home/Events/EventsView.html',
        controller: EventsViewModel,
        controllerAs: "vm"
    });