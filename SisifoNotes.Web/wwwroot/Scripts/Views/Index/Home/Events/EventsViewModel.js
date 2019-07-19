class EventsViewModel
{
    constructor($EventsService, $window)
    {
        this.EventsService = $EventsService;
        this.Events = [{ text: 'Learn AngularJS', done: false },
            { text: 'Build an app', done: false }];
        this.FormEventText = "";
        this.Window = $window;
        this.GetAllEvents();
    }

    AddEvent()
    {
        var event = new Event;
        event.ClientId = this.Window.ClientId;
        event.Description = this.FormEventText;
        //this.Events.push({ text: this.FormEventText, done: false });
        this.EventsService.AddAsync(event)
            .then((response) =>
            {
                this.OnSuccesAdd(response);
            },
                response => console.log(response)
            );

    }

    OnSuccesAdd(response)
    {
        let event = new Event(response.data);
        this.Events.push({ text: event.Description, done: false });

    }

    GetAllEvents()
    {
       
        this.EventsService.GetAllAsync()
            .then((response) =>
            {
                alert("1");
                this.OnGetData(response);
            },
                response => console.log(response)
            );
    }

    OnGetData(response)
    {
        console.log(response);
        alert("Response?");
        this.Events.length = 0;
        for (let i in response.data)
        {
            let event = new Event(response.data[i]);
            this.Events.push({ text: event.Description, done: false });
        }
    }
}

app.component('events',
    {
        templateUrl: './Scripts/Views/Index/Home/Events/EventsView.html',
        controller: EventsViewModel,
        controllerAs: "vm"
    });