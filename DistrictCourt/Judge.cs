namespace DistrictCourt;

public class Judge : LegalEntity
{
    public Judge(string name, int lengthOfService, int casesNum)
        : base(name, Role.Judge, lengthOfService, casesNum)
    {
        // Judges must have at least 5 years of service
        if (lengthOfService < 5)
        {
            throw new ArgumentException($"Judge {name} must have at least 5 years of service!");
        }
    }
    
    // Fifth step of Conduct() method
    // If jurors decided guilty -> sentence from 3 to 40 years in jail randomly
    public int GiveSentence()
    {
        var rnd  = new Random();
        return rnd.Next(3, 41);
    }
}