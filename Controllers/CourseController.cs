using academystudentsbackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace academystudentsbackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CourseController:ControllerBase
    {
        public static List<Course>? _courses;
        private readonly CourseContext _courseContext;

        public CourseController(CourseContext courseContext)
        {
            _courseContext = courseContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _courseContext.Courses.ToListAsync();
            if(courses == null)
            {
                return NotFound();
            }

            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var course = await _courseContext.Courses.Where(p => p.CourseId == id).FirstOrDefaultAsync();
            if(course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }
    }
}