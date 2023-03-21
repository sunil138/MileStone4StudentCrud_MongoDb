using MediatR;
using MileStone4StudentCrud_MongoDb.Commands;
using MileStone4StudentCrud_MongoDb.Repository;

namespace MileStone4StudentCrud_MongoDb.Handlers
{
    //creating a  addstudenthandler with irequesthandler of commands
    public class AddStudentHandler:IRequestHandler<AddStudentCommand>
    {
        private readonly StudentRepository _studentRepository;
        public AddStudentHandler(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Unit> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            await _studentRepository.AddStudent(request.student);
            return Unit.Value; 
        }
    }
}
