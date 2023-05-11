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

  internal string DeleteKeep(int keepId, string userId)
  {
    Keep keep = GetOneKeep(keepId, userId);
    if (keep.CreatorId != userId) throw new Exception("Something went wrong");
    _repo.DeleteKeep(keepId);
    return "Keep was deleted successfully.";
  }

  internal Keep EditKeep(Keep keepData)
  {
    Keep originalKeep = GetOneKeep(keepData.Id, keepData.CreatorId);
    if (originalKeep.CreatorId != keepData.CreatorId) throw new Exception("This is not your keep");
    originalKeep.Name = keepData.Name ?? originalKeep.Name;
    originalKeep.Description = keepData.Description ?? originalKeep.Description;
    originalKeep.Img = keepData.Img ?? originalKeep.Img;
    _repo.EditKeep(originalKeep);
    originalKeep.UpdatedAt = DateTime.Now;
    return originalKeep;
  }

  internal List<Keep> GetAllKeeps(string userId)
  {
    List<Keep> keeps = _repo.GetAllKeeps();
    return keeps;
  }

  internal Keep GetOneKeep(int keepId, string userId)
  {
    Keep keep = _repo.GetOneKeep(keepId);
    if (keep == null) throw new Exception($"THIS ID WAS INVALID: {keepId}");
    {if(keep.CreatorId != userId)
        keep.Views++;
        _repo.EditKeep(keep);
      }
    return keep;
  }
}
