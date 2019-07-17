class List extends Note
{
    constructor(json)
    {
        super(json)
        if (json)
        {
            this.Items = json.items;
        }
        else
        {
            this.Items = [];
        }
    }
}