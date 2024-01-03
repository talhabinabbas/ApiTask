using ClassTaskPI.Model;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class StudentResultsController : ControllerBase
{
    private static List<StudentResult> _studentResults = new List<StudentResult>
    {
        new StudentResult { Id = 1, StudentName = "Huzaifa", Score = 90 },
        new StudentResult { Id = 2, StudentName = "Talha", Score = 85 }
        // Add more sample data
    };

    [HttpGet]
    public ActionResult<IEnumerable<StudentResult>> Get()
    {
        return Ok(_studentResults);
    }

    [HttpGet("{id}")]
    public ActionResult<StudentResult> Get(int id)
    {
        var result = _studentResults.FirstOrDefault(r => r.Id == id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public ActionResult<StudentResult> Post(StudentResult studentResult)
    {
        studentResult.Id = _studentResults.Count + 1;
        _studentResults.Add(studentResult);
        return CreatedAtAction(nameof(Get), new { id = studentResult.Id }, studentResult);
    }

    private class StudentResult
    {
        public string StudentName { get; internal set; }
        public int Score { get; internal set; }
        public int Id { get; internal set; }
    }

    // Add other CRUD operations as needed
}