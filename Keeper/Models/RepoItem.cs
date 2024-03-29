using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keeper.Models;

public class RepoItem<T>
{
  public T Id { get; set; }
  public DateTime UpdatedAt { get; set; }
  public DateTime CreatedAt { get; set; }
}
