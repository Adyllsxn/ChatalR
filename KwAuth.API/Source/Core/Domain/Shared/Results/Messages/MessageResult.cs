namespace KwAuth.API.Source.Core.Domain.Shared.Results.Messages;
public class MessageResult
{
    public static class Common
    {
        public const string Null = null;
        public const string ParamsRequired = "Incomplete data.";
        public const string Unauthorized = "Unauthorized access.";
        public const string InvalidId = "Invalid identifier.";
        public const string InvalidParameters = "Invalid data.";
        public const string InvalidValidatCandidatura = "Invalid validation data.";
        public const string InternalServerError = "Internal error.";
        public const string Success = "Operation completed.";
        public const string NotFound = "Record not found.";
        public const string NotFoundInSearch = "No results found.";
        public const string FluentValidation = "Invalid data.";
        public const string InvalidCredentials = "Invalid credentials.";
        public const string InvalidEmail = "Invalid email.";
        public const string ExistsByEmail = "Email already exists.";
    }
    public static class PasswordsMessages
    {
        public const string InvalidPassword = "Incorrect password.";
        public const string InvalidConfirmNewPassword = "Confirmation does not match.";
        public const string InvalidConfirmPassword = "Passwords do not match.";
    }
    
    public static class PermissionMessages
    {
        public const string ForbiddenGetAll = "No permission to list {0}.";
        public const string ForbiddenGetById = "No permission to view {0}.";
        public const string ForbiddenCreate = "No permission to create {0}.";
        public const string ForbiddenUpdate = "No permission to edit {0}.";
        public const string ForbiddenDelete = "No permission to delete {0}.";
        public const string ForbiddenChangePassword = "No permission to change password.";
        public const string ForbiddenRecoverPassword = "No permission to recover password.";
        public const string ForbiddenValidate = "No permission to validate {0}.";
    }

    public static class OperationMessages
    {
        
        public const string ErrorAuth = "Authentication error.";
        public const string ErrorCreate = "Error creating.";
        public const string ErrorRestore = "Error restore.";
        public const string ErrorUpdate = "Error updating.";
        public const string ErrorDelete = "Error deleting.";
        public const string ErrorSearch = "Search error.";
        public const string ErrorGetAll = "Error listing.";
        public const string ErrorGet = "Error Get.";
        public const string ErrorGetById = "Error retrieving.";
        public const string ErrorUpdateStatus = "Error updating status.";
    }

}