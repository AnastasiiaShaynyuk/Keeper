using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Keeper.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase
{
  public readonly ProfilesService _profilesService;


  public ProfilesController(ProfilesService profilesService)
  {
    _profilesService = profilesService;
  }

  [HttpGet("{profileId}")]
  public ActionResult<Profile> GetUsersProfile(string profileId) {
    try {
      Profile profile = _profilesService.GetUsersProfile(profileId);
      return Ok(profile);
    }
    catch (Exception e)
    {
    return BadRequest(e.Message);
    }
  }

  [HttpGet("{profileId}/keeps")]
  public ActionResult<List<Keep>> GetUsersKeeps(string profileId) 
  {
    try {
      List<Keep> keeps = _profilesService.GetUsersKeeps(profileId);
      return Ok(keeps);
    }
    catch (Exception e)
    {
    return BadRequest(e.Message);
    }
  }

  [HttpGet("{profileId}/vaults")]
  public ActionResult<List<Vault>> GetUsersVaults(string profileId) 
  {
    try {
      List<Vault> vaults = _profilesService.GetUsersVaults(profileId);
      return Ok(vaults);
    }
    catch (Exception e)
    {
    return BadRequest(e.Message);
    }
  }
}
