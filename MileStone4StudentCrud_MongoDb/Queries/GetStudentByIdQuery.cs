using MediatR;
using MileStone4StudentCrud_MongoDb.Models;

namespace MileStone4StudentCrud_MongoDb.Queries
{
    public record GetStudentByIdQuery(string id):IRequest<Student>;
   
}
