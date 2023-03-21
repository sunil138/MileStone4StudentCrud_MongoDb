using MediatR;
using MileStone4StudentCrud_MongoDb.Models;

namespace MileStone4StudentCrud_MongoDb.Queries
{
    //creating a GetStudentByIdQuery  
    public record GetStudentQuery:IRequest<List<Student>>; 
  
}
