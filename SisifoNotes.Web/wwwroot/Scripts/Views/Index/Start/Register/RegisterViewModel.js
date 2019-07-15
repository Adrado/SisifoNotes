class RegisterViewModel
{
    constructor($window)
    {
        this.Window = $window;
    }

    ChangeToLogin()
    {
        this.Window.AccountUser = true;
    }

    CheckForm(complete) {
        if (complete) {
            this.Register()
        }
    }

    Register() {
        let client = new Client();
        client.Name = this.Name;
        client.Surname = this.Surname;
        client.Email = this.Email;
        client.Password = this.Password;
        this.SetData(client);
    }

    SetData(client) {
        this.ClientsService.AddAsync(client)
            .then((response) => {
                this.OnSuccesAdd(response);
            },
                response => console.log(response)
            );
    }

    OnSuccesAdd(response) {
        let client = new Client(response.data)
        this.Clients.push(client);
        this.Clean();
    }
}

app.component('register',
    {
        templateUrl: './Scripts/Views/Index/Start/Register/RegisterView.html',
        controller: RegisterViewModel,
        controllerAs: "vm"
    });

