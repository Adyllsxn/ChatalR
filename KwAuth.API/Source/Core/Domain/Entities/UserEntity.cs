namespace KwAuth.API.Source.Core.Domain.Entities;
public sealed class UserEntity : EntityBase, IAggregateRoot
{
    #region Properties
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string PasswordHash { get; private set; } = string.Empty;
    public UserRole Role { get; private set; }
    public bool IsDeleted { get; private set; } = false;
    public DateTime? DeletedAt { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; private set; }
    #endregion

    #region Constructors
    [JsonConstructor]
    private UserEntity() { }

    public UserEntity(
        string firstName,
        string lastName, 
        string email,
        string passwordHash,
        UserRole role = UserRole.Client)
    {
        ValidateUser(firstName, lastName, email, passwordHash);

        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
        CreatedAt = DateTime.UtcNow;
    }
    #endregion

    #region Domain Methods
    public void UpdatePassword(string passwordHash)
    {
        DomainValidator.NotEmpty(passwordHash, "Password hash");
        PasswordHash = passwordHash;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Archive()
    {
        IsDeleted = true;
        DeletedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Restore()
    {
        IsDeleted = false;
        DeletedAt = null;
        UpdatedAt = DateTime.UtcNow;
    }
    
    public bool CanCreateApplication()
    {
        return !IsDeleted && Role == UserRole.Client;
    }
    #endregion

    #region Private Methods
    private void ValidateUser(string firstName, string lastName, string email, string passwordHash)
    {
        DomainValidator.NotEmpty(firstName, "First name");
        DomainValidator.NotEmpty(lastName, "Last name");
        DomainValidator.NotEmpty(email, "Email");
        DomainValidator.NotEmpty(passwordHash, "Password hash");
    }
    #endregion
}
