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

  internal Vault GetOneVault(int vaultId, string userId)
  {
    Vault vault = _repo.GetOneVault(vaultId);
    if (vault == null) throw new Exception($"THIS ID WAS INVALID: {vaultId}");
    if (vault.IsPrivate == true && userId != vault.CreatorId) throw new Exception("SOMETHING WENT WRONG");
    return vault;
  }
}
