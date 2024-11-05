namespace ApiUniversity.Models;

public class Enrollment
{
    public int Id { get; set; }
    public Grade Grade { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public Student Student { get; set; } = null!;
    public Course Course { get; set; } = null!;

    public Enrollment() { }

    public Enrollment(DetailEnrollmentDTO detailEnrollmentDTO)
    {
        Id = detailEnrollmentDTO.Id;
        Grade = detailEnrollmentDTO.Grade;
        Student = new Student(detailEnrollmentDTO.Student);
        Course = new Course(detailEnrollmentDTO.Course);
    }

    public Enrollment(EnrollmentDTO enrollmentDTO)
    {
        Id = enrollmentDTO.Id;
        Grade = enrollmentDTO.Grade;
        StudentId = enrollmentDTO.StudentId;
        CourseId = enrollmentDTO.CourseId;
    }
}