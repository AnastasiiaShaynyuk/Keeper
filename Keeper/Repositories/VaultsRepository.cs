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
