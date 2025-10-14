
namespace chore_score.Repositories;

public class ChoresRepository
{

    public ChoresRepository(IDbConnection db)
    {
        _db = db;
    }
    private readonly IDbConnection _db; //this is like dbContext // we don't have to go to startup for this because it is already implemented in
    public List<Chore> GetAllChores()
    {
        string sql = "SELECT * FROM chores;";
        // mongoose was the ORM for mongoDB
        // Dapper is the ORM for SQL DBs
        // Query is a Dapper method that takes a SQL string and maps the results to a C# class
        List<Chore> chores = _db.Query<Chore>(sql).ToList();
        return chores;
    }
}