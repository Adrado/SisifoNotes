class Text extends Note
{
    constructor(json)
    {
        super(json)
        if (json)
        {
            this.Body = json.body;
        }
        else
        {
            this.Body = "";
        }
    }
}