namespace DistrictCourt;

public class Prosecutor : LegalEntity, IAccuser
{
    // Prosecutor does not have Lawyers
    public List<Lawyer> Lawyers { get; set; } = new List<Lawyer>();
    
    public Prosecutor(string name, int lengthOfService, int casesNum)
        : base(name, Role.Prosecutor, lengthOfService, casesNum)
    {
        // Prosecutors must have at least 10 years of service
        if (lengthOfService < 10)
        {
            throw new ArgumentException($"Prosecutor {name} must have at least 10 years of service!");
        }
    }
}