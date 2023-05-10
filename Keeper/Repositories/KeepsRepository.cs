using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keeper.Repositories;

public class KeepsRepository
{
  private readonly IDbConnection _db;

  public KeepsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Keep CreateKeep(Keep keepData)
  {
    string sql = @"
    INSERT INTO keeps(name, description, img, kept, creatorId)
    VALUES(@Name, @Description, @Img, @Kept, @CreatorId);
    SELECT LAST_INSERT_ID()
    ;";
    int id = _db.ExecuteScalar<int>(sql, keepData);
    keepData.Id = id;

    // List<Keep> allKeeps = GetAllKeeps();
    // allKeeps.Insert(0, keepData);
    return keepData;
  }

  internal void DeleteKeep(int keepId)
  {
    string sql = "DELETE FROM keeps WHERE id = @keepId LIMIT 1;";

    _db.Execute(sql, new { keepId });
  }

  internal void EditKeep(Keep originalKeep)
  {
    string sql = @"
    UPDATE keeps
    SET
    name = @Name,
    description = @Description,
    img = @Img
    WHERE id = @Id
    ;";
    _db.Execute(sql, originalKeep);
  }

  internal List<Keep> GetAllKeeps()
  {
    // TODO add COUNT
    string sql = @"
    SELECT 
    k.*,
    COUNT(vk.id) AS kept,
    creator.*
    FROM keeps k
    LEFT JOIN vaultKeeps vk ON k.id = vk.keepId
    JOIN accounts creator ON creator.id = k.creatorId
    GROUP BY (k.id)
    ORDER BY k.id DESC
    ;";
    List<Keep> keeps = _db.Query<Keep, Profile, Keep>(sql, (keep, creator) =>
    {
      keep.Creator = creator;
      return keep;
    }).ToList();
    return keeps;
  }

  internal Keep GetOneKeep(int keepId)
  {
    // TODO add COUNT
    string sql = @"
    SELECT
    k.*,
    COUNT(vk.id) AS kept,
    creator.*
    FROM keeps k
    LEFT JOIN vaultKeeps vk ON k.id = vk.keepId
    JOIN accounts creator ON creator.id = k.creatorId
    WHERE k.id = @keepId
    GROUP BY (k.id)
    ;";
    Keep keep = _db.Query<Keep, Profile, Keep>(sql, (keep, creator) =>
    {
      keep.Creator = creator;
      return keep;
    }, new{keepId}).FirstOrDefault();
    return keep;
  }
}
