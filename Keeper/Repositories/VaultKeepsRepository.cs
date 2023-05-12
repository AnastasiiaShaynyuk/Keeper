using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keeper.Repositories;

public class VaultKeepsRepository
{
  private readonly IDbConnection _db;

  public VaultKeepsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal VaultKeep CreateVaultKeep(VaultKeep vaultKeepData)
  {
    string sql = @"
    INSERT INTO
    vaultKeeps(creatorId, keepId, vaultId)
    VALUES (@CreatorId, @KeepId, @VaultId);
    SELECT LAST_INSERT_ID()
    ;";
    int id = _db.ExecuteScalar<int>(sql, vaultKeepData);
    vaultKeepData.Id = id;
    return vaultKeepData;
  }

  internal void DeleteVaultKeep(int vaultKeepId)
  {
    string sql = "DELETE FROM vaultKeeps WHERE id = @vaultKeepId;";
    _db.Execute(sql, new { vaultKeepId });
  }

  internal VaultKeep GetOneVaultKeep(int vaultKeepId)
  {
    string sql = "SELECT * FROM vaultKeeps WHERE id = @vaultKeepId;";
    VaultKeep vaultKeep = _db.Query<VaultKeep>(sql, new { vaultKeepId }).FirstOrDefault();
      return vaultKeep;
  }

  internal List<VaultKeepViewModel> GetVaultKeeps(int vaultId)
  {
    string sql = @"
    SELECT 
    k.*,
    vaultKeeps.id AS vaultKeepId, 
    creator.*
    FROM vaultKeeps 
    JOIN keeps k ON k.id = vaultKeeps.keepId
    JOIN accounts creator ON creator.id = k.creatorId
    WHERE vaultId = @vaultId
    ;";
    List<VaultKeepViewModel> vKeeps = _db.Query<VaultKeepViewModel, Profile, VaultKeepViewModel>(sql, (keepsInVault, creator) =>
    {
      keepsInVault.Creator = creator;
      return keepsInVault;
    }, new { vaultId }).ToList();
    return vKeeps;
  }

}