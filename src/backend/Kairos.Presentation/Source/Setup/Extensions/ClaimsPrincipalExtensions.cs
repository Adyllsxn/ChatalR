namespace Kairos.Presentation.Source.Setup.Extensions;
public static class ClaimsPrincipalExtensions
{
    #region GetId
        public static int GetId(this ClaimsPrincipal user)
        {
            var claim = user.FindFirst("id");
            if (claim == null)
                throw new UnauthorizedAccessException("Claim 'id' não encontrada.");
            
            return int.Parse(claim.Value);
        }
    #endregion

    #region GetEmail
        public static string GetEmail(this ClaimsPrincipal user)
        {
            var claim = user.FindFirst("email");
            if (claim == null)
                throw new UnauthorizedAccessException("Claim 'email' não encontrada.");

            return claim.Value;
        }

    #endregion
}