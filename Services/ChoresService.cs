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
}