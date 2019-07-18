class GenericService
{
    get Config()
    {
        var config =
        {
            headers:
            {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + this.Token
            }
        };
        return config;
    }

    constructor(http, url, $window)
    {
        this.Http = http;
        this.Url = url;
        this.Token = $window.Token;
    }

    Get()
    {
        return this.Http.get(this.Url);
    }

    Post(entity)
    {
        return this.Http.post(this.Url, entity, this.Config);
    }

    Put(entity)
    {
        let urlID = this.Url + entity.Id;
        return this.Http.put(this.Url, entity, this.Config);
    }

    Delete(entity)
    {
        let urlID = this.Url + entity.Id;
        return this.Http.delete(this.Url);
    }
}