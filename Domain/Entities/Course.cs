namespace ContosoUniversity.Domain.Entities.Base{
public class Course : BaseEntity{
    public int Credits {get; set;}
    public string Name {get; set;} = string.Empty;
}
}