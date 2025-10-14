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
}