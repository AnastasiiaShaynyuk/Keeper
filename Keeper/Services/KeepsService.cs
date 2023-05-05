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
}
