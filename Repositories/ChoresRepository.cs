
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

    public Chore CreateChore(Chore choreData)
    {
        string sql = @"
        INSERT INTO chores
        (name, description, difficulty, isComplete)
        VALUES
        (@Name, @Description, @Difficulty, @IsComplete);
        SELECT * FROM chores WHERE id = LAST_INSERT_ID();";
        Chore chore = _db.Query<Chore>(sql, choreData).SingleOrDefault();
        return chore;
    }
    public void DeleteChore(int choreId)
    {
        string sql = "DELETE FROM chores WHERE id = @choreId LIMIT 1;";
        object paramObject = new { ChoreId = choreId };
        int rowsAffected = _db.Execute(sql, paramObject);
        if (rowsAffected != 1)
        {
            throw new Exception("Could not delete chore");
        }
    }
}