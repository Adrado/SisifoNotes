class RegisterService extends GenericService
{
    constructor($http, $window)
    {
        super($http, "api/register",$window)
    }

    Register(model)
    {
        return this.Post(model);
    }
}

app.service("$RegisterService", RegisterService);