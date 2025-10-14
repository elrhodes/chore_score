namespace chore_score.Services;

public class ChoresService
{
    public ChoresService(ChoresRepository choresRepository)
    {
        _choresRepository = choresRepository;
    }

    private readonly ChoresRepository _choresRepository;

    public List<Chore> GetAllChores()
    {
        List<Chore> chores = _choresRepository.GetAllChores();
        return chores;
    }

    public Chore CreateChore(Chore choreData)
    {
        Chore newChore = _choresRepository.CreateChore(choreData);
        return newChore;
    }
    // if you use snake case in the sql, it will give you a 400 and not know what said snake case is IF you do the same in the model. Model and sql must match.

    public void DeleteChore(int choreId)
    {
        _choresRepository.DeleteChore(choreId);
    }

    public Chore UpdateChore(int choreId, Chore choreData)
    {
        // we need to get the original chore from the database
        List<Chore> chores = _choresRepository.GetAllChores();
        Chore original = chores.Find(c => c.Id == choreId);
        if (original == null)
        {
            throw new Exception("Invalid Chore Id");
        }
        // we need to update the original chore with the new data
        original.Name = choreData.Name ?? original.Name;
        original.Description = choreData.Description ?? original.Description;
        original.Difficulty = choreData.Difficulty != 0 ? choreData.Difficulty : original.Difficulty;
        original.IsComplete = choreData.IsComplete;

        // we need to save the updated chore to the database
        // but we don't have a method for that yet, so we'll just return the updated chore for now
        return original;
    }
}