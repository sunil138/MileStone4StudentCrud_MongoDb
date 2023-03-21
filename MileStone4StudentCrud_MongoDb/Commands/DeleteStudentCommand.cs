using MediatR;

namespace MileStone4StudentCrud_MongoDb.Commands
{
    //creating a deletestudentcommand with passing id
    public record DeleteStudentCommand(string id):IRequest; 
  
}
