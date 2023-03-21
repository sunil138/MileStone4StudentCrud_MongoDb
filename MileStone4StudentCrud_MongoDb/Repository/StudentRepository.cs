using Microsoft.Extensions.Options;
using MileStone4StudentCrud_MongoDb.Models;
using MongoDB.Driver;

namespace MileStone4StudentCrud_MongoDb.Repository
{
    public class StudentRepository
    {
        private readonly IMongoCollection<Student> _students; 
        public StudentRepository(IOptions<StudentStoreSetting> settings)
        {
            //geeting the connection string
            var mongoClient = new MongoClient(settings.Value.ConnectionString);
            //getting the database
            var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);
            //getting the collection name
            _students = mongoDatabase.GetCollection<Student>(settings.Value.StudentCollectionName);
        }

        //operation for getstudents
        public async Task<List<Student>> GetStudents() =>
            await _students.Find(_ => true).ToListAsync();

        //operation for getstudentbyid
        public async Task<Student> GetStudents(string id) =>
            await _students.Find(x => x.id == id).FirstOrDefaultAsync();

        //operation for addstudent
        public async Task AddStudent(Student student) =>
            await _students.InsertOneAsync(student);

        //operation for updatestudent
        public async Task UpdateStudent(string id, Student student) =>
            await _students.ReplaceOneAsync(x => x.id == id, student);

        //operation for deletestudentbyid 
        public async Task DeleteById(string id)=>
            await _students.DeleteOneAsync(x => x.id == id); 
        
    }
}
