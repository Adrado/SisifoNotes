class Note extends Entity
{
    constructor(json)
    {
        super(json)
        if (json)
        {
            this.Title = json.title;
            this.ClientId = json.clientId;
        }
        else
        {
            this.Title = "";
            this.ClientId = "00000000-0000-0000-0000-000000000000"
        }
    }
}