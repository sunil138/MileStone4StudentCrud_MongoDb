using MediatR;
using MileStone4StudentCrud_MongoDb.Models;

namespace MileStone4StudentCrud_MongoDb.Commands
{
    //creating a updatestudentcommand with passing Student collection
    public record UpdateStudentCommand(string id,Student student):IRequest;  
   
}
