using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MileStone4StudentCrud_MongoDb.Models
{
    //creating a collection student 
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set; }
        public string StudentName { get; set; } 
        public string StudentAddress { get; set; }
        public int StudentAge { get; set; }

        public string StudentCourse { get; set; }  
        public string StudentGender { get; set; } 
    }
}
