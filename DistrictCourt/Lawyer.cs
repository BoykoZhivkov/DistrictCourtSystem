namespace DistrictCourt;

public class Lawyer : LegalEntity
{
    public Lawyer(string name, int lengthOfService, int casesNum)
        : base(name, Role.Lawyer, lengthOfService, casesNum)
    {
        // Lawyers must have been involved in at least 10 cases
        if (casesNum < 10)
        {
            throw new ArgumentException($"Lawyer {name} must have been involved in at least 10 cases!");
        }
    }
}