class Event extends Note
{
    constructor(json)
    {
        super(json)
        if (json)
        {
            this.DateInit = json.dateInit;
            this.DateFinish = json.dateFinish;
            this.Place = json.place;
            this.Description = json.description;
        }
        else
        {
            this.DateInit = Date();
            this.DateFinish = Date();
            this.Place = "";
            this.Description = "";
        }
    }
}