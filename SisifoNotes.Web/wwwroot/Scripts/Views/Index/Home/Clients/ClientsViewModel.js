    class ClientsViewModel
{
    constructor($ClientsService)
    {
        this.Clients = [];
        this.GridOptions = null;
        this.InitializeTable();
        this.SelectedClient = null;
        
        this.IsEditing = false;
        this.ClientsService = $ClientsService;

        this.GetAllClients();
    }

    InitializeTable()
    {
        this.GridOptions =
            {
                enableFiltering: false,
                data: 'vm.Clients',
                appScopeProvider: this,
                columnDefs: [
                    { name: 'Name', field: 'Name' },
                    { name: 'FirstSurname', field: 'FirstSurname' },
                    { name: 'SecondSurname', field: 'SecondSurname' },
                    { name: 'Email', field: 'Email' },
                    { name: '', field: 'Id', cellTemplate: '<input type="button" value="Edit" ng-click="grid.appScope.Select(row.entity)">' },
                    { name: ' ', field: 'Id', cellTemplate: '<input type="button" value="Remove" ng-click="grid.appScope.RemoveClient(row.entity)">' }
                ]
            };
    }

    GetAllClients()
    {
        this.ClientsService.GetAllAsync()
            .then((response) =>
            {
                this.OnGetData(response);
            });
    }

    OnGetData(response)
    {
        this.Clients.length = 0;
        for (let i in response.data)
        {
            let client = new Client(response.data[i]);
            this.Clients.push(client);
        }
    }

    CheckFormAdd(complete)
    {
        if (complete)
        {
            this.AddNewClient()
        }
    }

    AddNewClient()
    {
        let client = new Client();
        client.Name = this.Name;
        client.FirstSurname = this.FirstSurname;
        client.SecondSurname = this.SecondSurname;
        client.Email = this.Email;
        client.Password = this.Password;
        
        this.SetData(client);
    }

    SetData(client)
    {
        this.ClientsService.AddAsync(client)
        .then((response) =>
        {
            this.OnSuccesAdd(response);
        },
            response => console.log(response)
        );
    }

    OnSuccesAdd(response)
    {
        let client = new Client(response.data);
        this.Clients.push(client);
        this.Clean();
    }

    Clean()
    {
        this.Name = "";
        this.FirstSurname = "";
        this.Email = "";
        this.Password = "";
        this.SecondSurname = "";
    }

    Select(client)
    {
        this.SelectedClient = client;
        this.Name = client.Name;
        this.FirstSurname = client.FirstSurname;
        this.Email = client.Email;
        this.Password = client.Password;
        this.SecondSurname = client.SecondSurname;
        this.IsEditing = true;
    }

    CheckFormSave(complete)
    {
        if (complete)
        {
            this.SaveSelectedClient()
        }
    }

    SaveSelectedClient()
    {
        this.SelectedClient.Name = this.Name;
        this.SelectedClient.FirstSurname = this.FirstSurname;
        this.SelectedClient.Email = this.Email;
        this.SelectedClient.Password = this.Password;
        this.SelectedClient.SecondSurname = this.SecondSurname;

        this.SaveEditClient();

        this.IsEditing = false;
    }

    SaveEditClient()
    {
        this.ClientsService.UpdateAsync(this.SelectedClient)
            .then((response) =>
            {
                this.OnSuccesUpdate(response);
            },
                response => console.log(response)
            );
    }

    OnSuccesUpdate(response)
    {
        let client = new Client(response.data)
        let index = this.Clients.findIndex(x => x.Id == this.SelectedClient.Id);
        this.Clients[index] = client;
        this.SelectedClient = null;
        this.Clean();
        this.GetAllClients();
    }

    RemoveClient(client)
    {   
        this.ClientsService.DeleteAsync(client)
            .then((response) =>
            {
                this.OnSuccesRemove(client);
            },
                response => console.log(response)
            );
    }

    OnSuccesRemove(client)
    {
        let index = this.Clients.findIndex(x => x.Id == client.Id);
        this.Clients.splice(index, 1);
        this.Clean();
    }
}

app.component('clients',
{
    templateUrl: './Scripts/Views/Index/Home/Clients/ClientsView.html',
    controller: ClientsViewModel,
    controllerAs: "vm"
    });




