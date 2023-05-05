namespace Keeper.Models;

public class Account : Profile
{
  // public string Id { get; set; }
  public string Email { get; set; }
}

public class Profile : RepoItem<string>
{
  public string Name { get; set; }
  public string Picture { get; set; }

}
