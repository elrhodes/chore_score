namespace chore_score.Controllers;

[ApiController] //data annotation - tells .net this is a controller
[Route("api/chores")] // sets the route for this controller - "api/chores"
public class ChoresController : ControllerBase // this is like when we say the Controller extends the BaseController
{
    [HttpGet("test")] // this is a data annotation that tells .net this is a get request, we can add parameters to this by adding in the () and defining them || these cannot be the same as other routes in this controller
    public string Test()
    {
        return "This is a test"; // this is just a test endpoint to make sure everything is working, so we go to api/chores/test and we should see "This is a test"
    }
    [HttpGet]
    public ActionResult<List<Chore>> GetAllChores()
    {
        try
        {
            List<Chore> chores = [];
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
}