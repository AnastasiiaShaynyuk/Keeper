using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keeper.Repositories;

public class ProfilesRepository
{
    private readonly IDbConnection _db;

  public ProfilesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal List<Keep> GetUsersKeeps(string profileId)
  {
    string sql = @"
    SELECT
    k.*,
    creator.*
    FROM keeps k
    JOIN accounts creator ON creator.id = k.creatorId
    WHERE k.creatorId = @profileId
    ;";
    List<Keep> keeps = _db.Query<Keep, Profile, Keep>(sql, (keep, creator) =>
    {
      keep.Creator = creator;
      return keep;
    }, new{profileId}).ToList();
    return keeps;
  }

  internal Profile GetUsersProfile(string profileId)
  {
    string sql = "SELECT * FROM accounts WHERE id = @profileId;";
    Profile profile = _db.Query<Profile>(sql, new { profileId }).FirstOrDefault();
    return profile;
  }
}
