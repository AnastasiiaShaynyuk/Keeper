using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keeper.Services;

public class ProfilesService
{
  public readonly ProfilesRepository _repo;

  public ProfilesService(ProfilesRepository repo)
  {
    _repo = repo;
  }

  internal List<Keep> GetUsersKeeps(string profileId)
  {
    List<Keep> keeps = _repo.GetUsersKeeps(profileId);
    return keeps;
  }

  internal Profile GetUsersProfile(string profileId)
  {
    Profile profile = _repo.GetUsersProfile(profileId);
    return profile;
  }
}
