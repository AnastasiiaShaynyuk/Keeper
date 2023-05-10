using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Keeper.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaultsController : ControllerBase
{
  private readonly VaultsService _vaultsService;
  private readonly Auth0Provider _auth;
  private readonly VaultKeepsService _vaultKeepsService;


  public VaultsController(VaultsService vaultsService, Auth0Provider auth, VaultKeepsService vaultKeepsService)
  {
    _vaultsService = vaultsService;
    _auth = auth;
    _vaultKeepsService = vaultKeepsService;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Vault>> CreateVault([FromBody] Vault vaultData)
  {
    try {
    Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
    vaultData.CreatorId = userInfo.Id;
    Vault vault = _vaultsService.CreateVault(vaultData);
    vault.Creator = userInfo;
    return Ok(vault);
    }
    catch (Exception e)
    {
    return BadRequest(e.Message);
    }
  }

  [HttpGet("{vaultId}")]
  public async Task<ActionResult<Keep>> GetOneVault(int vaultId)
  {
    try {
    Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      Vault vault = _vaultsService.GetOneVault(vaultId, userInfo?.Id);
      return Ok(vault);
    }
    catch (Exception e)
    {
    return BadRequest(e.Message);
    }
  }

  [HttpPut("{vaultId}")]
  [Authorize]
  public async Task<ActionResult<Vault>> EditVault(int vaultId, [FromBody] Vault vaultData)
  {
    try {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      vaultData.Id = vaultId;
    vaultData.CreatorId = userInfo.Id;
      Vault vault = _vaultsService.EditVault(vaultData);
      return Ok(vault);
    }
    catch (Exception e)
    {
    return BadRequest(e.Message);
    }
  }

  [HttpDelete("{vaultId}")]
  [Authorize]
  public async Task<ActionResult<string>> DeleteVault(int vaultId)
  {
    try {
    Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
    string message = _vaultsService.DeleteVault(vaultId, userInfo?.Id);
    return Ok(message);
    }
    catch (Exception e)
    {
    return BadRequest(e.Message);
    }
  }

  [HttpGet("{vaultId}/keeps")]
  public async Task<ActionResult<List<VaultKeepViewModel>>> GetVaultKeeps(int vaultId)
  {
    try {
    Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
    Vault vault = _vaultsService.GetOneVault(vaultId, userInfo?.Id);
    List<VaultKeepViewModel> vKeeps = _vaultKeepsService.GetVaultKeeps(vaultId);
    return Ok(vKeeps);
    }
    catch (Exception e)
    {
    return BadRequest(e.Message);
    }
  }
}
