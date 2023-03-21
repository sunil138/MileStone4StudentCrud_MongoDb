namespace MileStone4StudentCrud_MongoDb.Models
{
    //in the appsettings.json, we are passing ConnectionString,DatabaseName,StudentCollectionName
    public class StudentStoreSetting
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!; 
        public string StudentCollectionName { get; set; } = null!;
    }
}
