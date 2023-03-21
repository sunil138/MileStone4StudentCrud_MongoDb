using MediatR;
using MileStone4StudentCrud_MongoDb.Models;
using MileStone4StudentCrud_MongoDb.Queries;
using MileStone4StudentCrud_MongoDb.Repository;

namespace MileStone4StudentCrud_MongoDb.Handlers
{
    //creating a getstudenthandler with help of IRequesthandler
    public class GetStudentHandler:IRequestHandler<GetStudentQuery,List<Student>>
    {
        private readonly StudentRepository _studentRepository;
        public GetStudentHandler(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<Student>> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            return await _studentRepository.GetStudents(); 
        }
    }
}
