using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keeper.Repositories;

public class VaultsRepository
{
  private readonly IDbConnection _db;

  public VaultsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Vault CreateVault(Vault vaultData)
  {
    string sql = @"
    INSERT INTO vaults(name, description, img, isPrivate, creatorId)
    VALUES(@Name, @Description, @Img, @IsPrivate, @CreatorId);
    SELECT LAST_INSERT_ID()
    ;";
    int id = _db.ExecuteScalar<int>(sql, vaultData);
    vaultData.Id = id;
    return vaultData;
  }

  internal void DeleteVault(int vaultId)
  {
    string sql = "DELETE FROM vaults WHERE id = @vaultId LIMIT 1;";
    _db.Execute(sql, new { vaultId });
  }

  internal void EditVault(Vault originalVault)
  {
    string sql = @"
    UPDATE vaults
    SET
    name = @Name,
    description = @Description,
    img = @Img,
    isPrivate = @IsPrivate
    WHERE id = @Id
    ;";

    _db.Execute(sql, originalVault);
  }

  internal List<Vault> GetMyVaults(string userId)
  {
    string sql = @"
    SELECT
    v.*,
    creator.*
    FROM vaults v
    JOIN accounts creator ON creator.id = v.creatorId
    WHERE creator.id = @userId
    ;";
    List<Vault> myVaults = _db.Query<Vault, Profile, Vault>(sql, (vaults, creator) =>
    {
      vaults.Creator = creator;
      return vaults;
    }, new { userId }).ToList();
    return myVaults;
  }

  internal Vault GetOneVault(int vaultId)
  {
    string sql = @"
    SELECT
    v.*,
    creator.*
    FROM vaults v
    JOIN accounts creator ON creator.id = v.creatorId
    WHERE v.id = @vaultId
    ;";
    Vault vault = _db.Query<Vault, Profile, Vault>(sql, (vault, creator) =>
    {
      vault.Creator = creator;
      return vault;
    }, new{vaultId}).FirstOrDefault();
    return vault;
  }


}
