class RegisterViewModel
{
    constructor($window, $RegisterService)
    {
        this.Window = $window;
        this.RegisterService = $RegisterService;
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

    Register()
    {
        let client = new Client();
        client.Name = this.Name;
        client.FirstSurname = this.FirstSurname;
        client.SecondSurname = this.SecondSurname;
        client.Email = this.Email;
        client.Password = this.Password;
        this.SetData(client);
        this.Clean();
    }

    SetData(client)
    {
        this.RegisterService.Register(client)
            .then((response) =>
            {
                console.log(response);
                this.Window.Token = response.data.client.token;
                this.Window.LogonUser = true;
                this.Window.IsLoading = false;
            },
                response => console.log(response)
            );
    }

    Clean()
    {
        this.Name = "";
        this.FirstSurname = "";
        this.SecondSurname = "";
        this.Email = "";
        this.Password = "";
        this.Address = "";
    }
}

app.component('register',
    {
        templateUrl: './Scripts/Views/Index/Start/Register/RegisterView.html',
        controller: RegisterViewModel,
        controllerAs: "vm"
    });

