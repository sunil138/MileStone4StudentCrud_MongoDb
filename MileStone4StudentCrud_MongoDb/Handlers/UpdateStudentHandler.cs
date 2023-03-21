using MediatR;
using MileStone4StudentCrud_MongoDb.Commands;
using MileStone4StudentCrud_MongoDb.Repository;

namespace MileStone4StudentCrud_MongoDb.Handlers
{
    //creating a  updatestudenthandler with irequesthandler of commands
    public class UpdateStudentHandler:IRequestHandler<UpdateStudentCommand>
    {
        private readonly StudentRepository _studentRepository;
        public UpdateStudentHandler(StudentRepository studentRepository)
        {
                _studentRepository = studentRepository;
        }

        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            await _studentRepository.UpdateStudent(request.id, request.student);
            return Unit.Value; 
        }
    }
}
