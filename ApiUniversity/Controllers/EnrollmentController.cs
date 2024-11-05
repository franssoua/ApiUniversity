using ApiUniversity.Data;
using ApiUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiUniversity.Controllers;

[ApiController]
[Route("api/enrollment")]
public class EnrollmentController : ControllerBase
{
    private readonly ApiUniversityContext _context;

    public EnrollmentController(ApiUniversityContext context)
    {
        _context = context;
    }

    // GET: api/course
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DetailEnrollmentDTO>>> GetEnrollments()
    {
        // Get courses and related lists
        var enrollments = _context.Enrollments.Include(x => x.Student).Include(x => x.Course).Select(x => new DetailEnrollmentDTO(x));
        return await enrollments.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<DetailEnrollmentDTO>> PostEnrollment(EnrollmentDTO enrollmentDTO)
    {
        Enrollment enrollment = new(enrollmentDTO);

        _context.Enrollments.Add(enrollment);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetEnrollments), new { id = enrollment.Id }, new DetailEnrollmentDTO(enrollment));
    }
}