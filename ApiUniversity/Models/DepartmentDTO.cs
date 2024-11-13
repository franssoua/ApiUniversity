namespace ApiUniversity.Models;

public class DepartmentDTO
{
    public string Name { get; set; } = null!;
    public InstructorDTO Administrator { get; set; } = null!;

    public DepartmentDTO() { }

    public DepartmentDTO(Department department)
    {
        Name = department.Name;
        Administrator = new InstructorDTO(department.Administrator);
    }
}