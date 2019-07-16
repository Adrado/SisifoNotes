 class  User extends Entity
{
    constructor(json)
    {
        super(json);
        if (json)
        {
            this.Name = json.name;
            this.FirstSurname = json.firstSurname;
            this.SecondSurname = json.secondSurname;
            this.Email = json.email;
            this.Password = json.password;
        }
        else
        {
            this.Name = "";
            this.FirstSurname = "";
            this.SecondSurname = "";
            this.Email = "";
            this.Password = "";
        }
    }
}
