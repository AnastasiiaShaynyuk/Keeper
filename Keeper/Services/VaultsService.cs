using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keeper.Services;

public class VaultsService
{
  private readonly VaultsRepository _repo;

  public VaultsService(VaultsRepository repo)
  {
    _repo = repo;
  }

  internal Vault CreateVault(Vault vaultData)
  {
    Vault vault = _repo.CreateVault(vaultData);
    vault.CreatedAt = DateTime.Now;
    vault.UpdatedAt = DateTime.Now;
    return vault;
  }

  internal string DeleteVault(int vaultId, string userId)
  {
    Vault vault = GetOneVault(vaultId, userId);
    if (vault.CreatorId != userId) throw new Exception("Something went wrong");
    _repo.DeleteVault(vaultId);
    return "Vault was deleted successfully.";
  }

  internal Vault EditVault(Vault vaultData)
  {
    Vault originalVault = GetOneVault(vaultData.Id, vaultData.CreatorId);
    if (originalVault.CreatorId != vaultData.CreatorId) throw new Exception("This is not your vault");
    originalVault.Name = vaultData.Name ?? originalVault.Name;
    originalVault.Description = vaultData.Description ?? originalVault.Description;
    originalVault.Img = vaultData.Img ?? originalVault.Img;
    originalVault.IsPrivate = vaultData != null ? vaultData.IsPrivate : originalVault.IsPrivate;
    _repo.EditVault(originalVault);
    originalVault.UpdatedAt = DateTime.Now;
    return originalVault;
  }

  internal Vault GetOneVault(int vaultId, string userId)
  {
    Vault vault = _repo.GetOneVault(vaultId);
    if (vault == null) throw new Exception($"THIS ID WAS INVALID: {vaultId}");
    if (vault.IsPrivate == true && userId != vault.CreatorId) throw new Exception("SOMETHING WENT WRONG");
    return vault;
  }

  internal List<KeepsInVault> GetVaultKeeps(int vaultId, string userId)
  {
    Vault vault = GetOneVault(vaultId, userId);
    if (vault.IsPrivate == true && userId != vault.CreatorId) throw new Exception("SOMETHING WENT WRONG");
    List<KeepsInVault> vKeeps = _repo.GetVaultKeeps(vaultId);
    return vKeeps;
  }
}
