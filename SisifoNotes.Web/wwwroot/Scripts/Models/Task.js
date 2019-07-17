class Task extends Note
{
    constructor(json)
    {
        super(json)
        if (json)
        {
            this.Priority = json.priority;
            this.Deadline = json.deadline;
        }
        else
        {
            this.Priority = [];
            this.Deadline = new Date();
        }
    }
}