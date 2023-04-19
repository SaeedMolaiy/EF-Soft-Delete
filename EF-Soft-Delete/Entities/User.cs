using EF_Soft_Delete.Markers;

namespace EF_Soft_Delete.Entities;

internal class User : ISoftDeletable
{
    public User(string username, string password, bool isDeleted)
    {
        Username = username;
        Password = password;
        IsDeleted = isDeleted;
    }

    public string Username { get; set; }
    public string Password { get; set; }

    /// <inheritdoc />
    public bool IsDeleted { get; set; }
}