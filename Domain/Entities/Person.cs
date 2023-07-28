namespace ContosoUniversity.Domain.Entities.Base{
public class Person : BaseEntity {
    public string FirstName {get; set;} = string.Empty;
    public string LastName {get; set;} = string.Empty;
    public DateTime? HireDate {get; set;}
    public DateTime? EnrollmentDate {get; set;}
    public string Address {get; set;} = string.Empty;
    public bool? HasParkingLot {get; set;}
}
}