using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keeper.Services;

public class VaultKeepsService
{
  private readonly VaultKeepsRepository _repo;
  private readonly VaultsService _vaultsService;

  public VaultKeepsService(VaultKeepsRepository repo, VaultsService vaultsService)
  {
    _repo = repo;
    _vaultsService = vaultsService;
  }

  internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData, string userId)
  {
    Vault vault = _vaultsService.GetOneVault(vaultKeepData.VaultId, userId);
    if (vault.CreatorId != userId) throw new Exception("Something went wrong");
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
}
