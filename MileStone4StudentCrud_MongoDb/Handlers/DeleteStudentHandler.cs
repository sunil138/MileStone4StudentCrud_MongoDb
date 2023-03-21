using MediatR;
using MileStone4StudentCrud_MongoDb.Commands;
using MileStone4StudentCrud_MongoDb.Repository;

namespace MileStone4StudentCrud_MongoDb.Handlers
{
    //creating a  deletestudenthandler with irequesthandler of commands
    public class DeleteStudentHandler:IRequestHandler<DeleteStudentCommand>
    {
        private readonly StudentRepository _studentRepository;
        public DeleteStudentHandler(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            await _studentRepository.DeleteById(request.id);
            return Unit.Value;  
        }
    }
}
