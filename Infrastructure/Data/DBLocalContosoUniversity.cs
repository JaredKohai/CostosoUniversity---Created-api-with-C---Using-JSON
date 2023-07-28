using ContosoUniversity.Domain.Entities.Base;
using System.Text.Json;


public class DBLocalContosoUniversity
{
    private const string _fileNamePerson = "dbContosoUniversityPersons.json";
    private const string _fileNameCourses = "dbContosoUniversityCourses.json";
    private const string _fileNameDepartments = "dbContosoUniversityDepartments.json";
    private const string _dataPath = "Infrastructure\\Data";
    private IEnumerable<Person> _persons;
    private IEnumerable<Course> _courses;
    private IEnumerable<Department> _departments;

    public DBLocalContosoUniversity()
    {
        _persons = new List<Person>();
        _courses = new List<Course>();
        _departments = new List<Department>();
    }

    private string GetPathFile(string fileName)
    {
        return Path.Combine(Environment.CurrentDirectory, _dataPath, fileName);
    }


    private T JsonDeserialize<T>(string filePath)
    {
        var jsonString = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<T>(jsonString)!;
    }

    private void LoadDataCourses()
    {
        var filePath = GetPathFile(_fileNameCourses);
        if (File.Exists(filePath))
            _courses = JsonDeserialize<IEnumerable<Course>>(filePath);
    }

    private void LoadDataDepartments()
    {
        var filePath = GetPathFile(_fileNameDepartments);
        if (File.Exists(filePath))
            _departments = JsonDeserialize<IEnumerable<Department>>(filePath);
    }

    private void LoadDataPerson()
    {
        var filePath = GetPathFile(_fileNamePerson);
        if (File.Exists(filePath))
            _persons = JsonDeserialize<IEnumerable<Person>>(filePath);
    }

    public IEnumerable<Course> Courses
    {
        get
        {
            LoadDataCourses();
            return _courses;
        }
    }

    public IEnumerable<Department> Departments
    {
        get
        {
            LoadDataDepartments();
            return _departments;
        }
    }

    public IEnumerable<Person> Persons
    {
        get
        {
            LoadDataPerson();
            return _persons;
        }
    }

}
