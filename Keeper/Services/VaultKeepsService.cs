using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keeper.Services;

public class VaultKeepsService
{
  private readonly VaultKeepsRepository _repo;
  private readonly VaultsService _vaultsService;
  private readonly KeepsService _keepsService;

  public VaultKeepsService(VaultKeepsRepository repo, VaultsService vaultsService, KeepsService keepsService)
  {
    _repo = repo;
    _vaultsService = vaultsService;
    _keepsService = keepsService;
  }

  internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData, string userId)
  {
    Vault vault = _vaultsService.GetOneVault(vaultKeepData.VaultId, userId);
    if (vault.CreatorId != userId) throw new Exception("Something went wrong");
    _keepsService.IncrementKeeps(vaultKeepData.KeepId);
    VaultKeep vaultKeep = _repo.CreateVaultKeep(vaultKeepData);
    vaultKeep.CreatedAt = DateTime.Now;
    vaultKeep.UpdatedAt = DateTime.Now;
    return vaultKeep;
  }

  internal VaultKeep GetOneVaultKeep(int vaultKeepId) {
    VaultKeep vaultKeep = _repo.GetOneVaultKeep(vaultKeepId);
    return vaultKeep;
  }

  internal string DeleteVaultKeep(int vaultKeepId, string userId)
  {
    VaultKeep vaultKeep = _repo.GetOneVaultKeep(vaultKeepId);
    if (vaultKeep.CreatorId != userId) throw new Exception("It is not yours");
    _repo.DeleteVaultKeep(vaultKeepId);
    return "Successfully deleted!";
  }

  internal List<VaultKeepViewModel> GetVaultKeeps(int vaultId)
  {
    List<VaultKeepViewModel> vKeeps = _repo.GetVaultKeeps(vaultId);
    if(vKeeps == null) throw new Exception("There is no keeps");
    return vKeeps;
  }
}
