namespace Kairos.Presentation.Source.Setup.Extensions;
public static class ClaimsPrincipalExtensions
{
    public static int GetId(this ClaimsPrincipal user)
    {
        var claim = user.FindFirst("id");
        if (claim == null)
            throw new UnauthorizedAccessException("Claim 'id' não encontrada.");
        
        return int.Parse(claim.Value);
    }

    public static string GetEmail(this ClaimsPrincipal user)
    {
        var claim = user.FindFirst("email");
        if (claim == null)
            throw new UnauthorizedAccessException("Claim 'email' não encontrada.");

        return claim.Value;
    }
}