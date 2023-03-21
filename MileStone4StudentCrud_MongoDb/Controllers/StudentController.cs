using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MileStone4StudentCrud_MongoDb.Commands;
using MileStone4StudentCrud_MongoDb.Models;
using MileStone4StudentCrud_MongoDb.Queries;

namespace MileStone4StudentCrud_MongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("swagger")] 
    public class StudentController : ControllerBase
    {
        //providing mediator
        private readonly IMediator _mediator; 
        public StudentController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        //getting all the detailsstudent
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAllStudents()
        {
            var allstudents = await _mediator.Send(new GetStudentQuery());
            return Ok(allstudents);
        }

        //getting a studentdetail by id
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Student>> Getallstudents(string id)
        {
            var studentbyid = await _mediator.Send(new GetStudentByIdQuery(id));
            return Ok(studentbyid);
        }

        //adding a new student 
        [HttpPost]
        public async Task<ActionResult> AddStudent([FromBody] Student students)
        {
            await _mediator.Send(new AddStudentCommand(students));
            return StatusCode(201);
        }

        //updating a new student
        [HttpPut("{id:length(24)}")]
        public async Task<ActionResult> UpdateStudent(string id, [FromBody] Student students)
        {
            await _mediator.Send(new UpdateStudentCommand(id, students));
            return StatusCode(201);
        }

        //delete a student by id
        [HttpDelete("{id:length(24)}")]
        public async Task<ActionResult> DeleteStudentById(string id)
        {
            await _mediator.Send(new DeleteStudentCommand(id));
            return StatusCode(200);
        }
    }
}
