namespace Keeper.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KeepsController : ControllerBase
{
  private readonly KeepsService _keepsService;
  private readonly Auth0Provider _auth;

  public KeepsController(KeepsService keepsService, Auth0Provider auth)
  {
    _keepsService = keepsService;
    _auth = auth;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Keep>> CreateKeep([FromBody] Keep keepData) {
    try {
    Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
    keepData.CreatorId = userInfo.Id;
    Keep keep = _keepsService.CreateKeep(keepData);
    keep.Creator = userInfo;
    return Ok(keep);
    }
    catch (Exception e)
    {
    return BadRequest(e.Message);
    }
  }

  [HttpGet]
  public async Task<ActionResult<List<Keep>>> GetAllKeeps() {
    try {
    Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
    List<Keep> keeps = _keepsService.GetAllKeeps(userInfo?.Id);
    return Ok(keeps);
    }
    catch (Exception e)
    {
    return BadRequest(e.Message);
    }
  }

  [HttpGet("{keepId}")]
  public async Task<ActionResult<Keep>> GetOneKeep(int keepId)
  {
    try {
    Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      Keep keep = _keepsService.GetOneKeep(keepId, userInfo?.Id);
      return Ok(keep);
    }
    catch (Exception e)
    {
    return BadRequest(e.Message);
    }
  }

  [HttpPut("{keepId}")]
  [Authorize]
  public async Task<ActionResult<Keep>> EditKeep(int keepId, [FromBody] Keep keepData)
  {
    try {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      keepData.Id = keepId;
    keepData.CreatorId = userInfo.Id;
      Keep keep = _keepsService.EditKeep(keepData);
      return Ok(keep);
    }
    catch (Exception e)
    {
    return BadRequest(e.Message);
    }
  }

  [HttpDelete("{keepId}")]
  [Authorize]
  public async Task<ActionResult<string>> DeleteKeep(int keepId)
  {
    try {
    Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
    string message = _keepsService.DeleteKeep(keepId, userInfo.Id);
    return Ok(message);
    }
    catch (Exception e)
    {
    return BadRequest(e.Message);
    }
    
  }
}
