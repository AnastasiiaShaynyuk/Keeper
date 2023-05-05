using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keeper.Services;

public class KeepsService
{
  public readonly KeepsRepository _repo;

  public KeepsService(KeepsRepository repo)
  {
    _repo = repo;
  }

  internal Keep CreateKeep(Keep keepData)
  {
    Keep keep = _repo.CreateKeep(keepData);
    keep.CreatedAt = DateTime.Now;
    keep.UpdatedAt = DateTime.Now;
    return keep;
  }

  internal List<Keep> GetAllKeeps(string userId)
  {
    List<Keep> keeps = _repo.GetAllKeeps();
    // TODO add private
    return keeps;
  }

  internal Keep GetOneKeep(int keepId, string userId)
  {
    Keep keep = _repo.GetOneKeep(keepId);
    if (keep == null) throw new Exception($"THIS ID WAS INVALID: {keepId}");
    // TODO add private
    return keep;
  }
}
