using MediatR;
using MileStone4StudentCrud_MongoDb.Models;
using MileStone4StudentCrud_MongoDb.Queries;
using MileStone4StudentCrud_MongoDb.Repository;

namespace MileStone4StudentCrud_MongoDb.Handlers
{
    //creating a getstudentbyidhandler with help of IRequesthandler 
    public class GetStudentByIdHandler:IRequestHandler<GetStudentByIdQuery,Student>
    {
        private readonly StudentRepository _studentRepository;
        public GetStudentByIdHandler(StudentRepository studentRepository)
        {
                _studentRepository = studentRepository;
        }

        public async Task<Student> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _studentRepository.GetStudents(request.id); 
        }
    }
}
