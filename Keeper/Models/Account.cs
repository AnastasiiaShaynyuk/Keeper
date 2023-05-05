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
  public string CoverImg { get; set; } = "https://images.unsplash.com/photo-1683123851331-0f4922b4946d?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80";
}
