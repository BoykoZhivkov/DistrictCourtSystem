namespace DistrictCourt;

public class Juror : LegalEntity
{
    public Juror(string name, int lengthOfService, int casesNum)
        : base(name, Role.Juror, lengthOfService, casesNum) {}
}