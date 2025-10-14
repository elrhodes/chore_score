namespace chore_score.Controllers;

[ApiController] //data annotation - tells .net this is a controller
[Route("api/chores")] // sets the route for this controller - "api/chores"
public class ChoresController : ControllerBase
// this is like when we say the Controller extends the BaseController
{
    // NOTE this is where we are going to inject our service and repository
    // we do this by creating a constructor that takes in the service and repository as parameters
    // we then set them to private readonly fields in the controller
    public ChoresController(ChoresService choresService)
    // this is us taking in a whole Chores Service object and we can use it in our controller
    {
        _choresService = choresService;
    }

    private readonly ChoresService _choresService;
    // this is us creating a private readonly field that is of type ChoresService
    // we use the underscore to denote that it is a private field
    // private means only members of this class can access it
    // readonly means it can only be set in the constructor and cannot be changed after that


    [HttpGet("test")]
    // this is a data annotation that tells .net this is a get request, we can add parameters to this by adding in the () and defining them || these cannot be the same as other routes in this controller
    public string Test()
    {
        return "This is a test"; // this is just a test endpoint to make sure everything is working, so we go to api/chores/test and we should see "This is a test"
    }
    [HttpGet]
    public ActionResult<List<Chore>> GetAllChores()
    {
        try
        {
            List<Chore> chores = _choresService.GetAllChores();
            return Ok(chores);
            // return Ok() is a 200 status code, which means everything is good
            // return BadRequest() is a 400 status code, which means something is wrong with
            // we are able to use these because we wrapped the method in the ActionResult<>
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
            // if you are getting an error saying `BadRequest` isn't available, that means your controller doesn't inherit from ControllerBase!
        }
    }

    [HttpPost]
    public ActionResult<Chore> CreateChore([FromBody] Chore choreData)
    {
        try
        {
            Chore newChore = _choresService.CreateChore(choreData);
            return Ok(newChore);
            // return Ok() is a 200 status code, which means everything is good
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpDelete("{choreId}")]
    public ActionResult<string> DeleteChore(int choreId)
    {
        try
        {
            _choresService.DeleteChore(choreId);
            return Ok("Chore Deleted");
            // return Ok() is a 200 status code, which means everything is good
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}