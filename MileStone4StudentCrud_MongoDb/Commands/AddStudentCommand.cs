using MediatR;
using MileStone4StudentCrud_MongoDb.Models;

namespace MileStone4StudentCrud_MongoDb.Commands
{
    //creating a addstudentcommand with passing Student collection 
    public record AddStudentCommand(Student student):IRequest; 
   
}
