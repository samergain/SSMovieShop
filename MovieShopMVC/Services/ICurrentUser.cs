namespace MovieShopMVC.Services
{
    public interface ICurrentUser
    {
        int? UserId { get; }
        bool IsAdmin { get; }
        bool IsAuthenticated { get; }
        string Email { get; }
        string FullName { get; }
        IEnumerable<string> Roles { get; }

    }
}
