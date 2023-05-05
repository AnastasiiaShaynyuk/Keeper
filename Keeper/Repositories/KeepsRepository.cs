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
    INSERT INTO keeps(name, description, img, views, kept, creatorId)
    VALUES(@Name, @Description, @Img, @Views, @Kept, @CreatorId);
    SELECT LAST_INSERT_ID()
    ;";
    int id = _db.ExecuteScalar<int>(sql, keepData);
    keepData.Id = id;
    return keepData;
  }

  internal List<Keep> GetAllKeeps()
  {
    string sql = @"
    SELECT 
    k.*,
    creator.*
    FROM keeps k
    JOIN accounts creator ON creator.id = k.creatorId
    ;";
    List<Keep> keeps = _db.Query<Keep, Profile, Keep>(sql, (keep, creator) =>
    {
      keep.Creator = creator;
      return keep;
    }).ToList();
    return keeps;
  }
}
