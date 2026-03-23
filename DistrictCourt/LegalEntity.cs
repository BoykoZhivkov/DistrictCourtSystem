namespace DistrictCourt;

public class LegalEntity
{
    // Properties
    public string Name { get; set; }
    public List<Role> Positions { get; set; } // Every LegalEntity can have more than 1 role
    public int LengthOfService { get; set; }
    public int CasesNum { get; private set; }
    
    // Constructor
    protected LegalEntity(string name, Role initialRole, int lengthOfService, int casesNum)
    {
        Name = name;
        Positions = new List<Role> { initialRole };
        LengthOfService = lengthOfService;
        CasesNum = casesNum;
    }

    // LegalEntity can ask a question to a citizen
    public string AskQuestion(Citizen citizen)
    {
        var logEntry = $"{this.Name} (Legal Entity) asked {citizen.Name} (Citizen).";
        
        return logEntry;
    }

    // All LegalEntities increase their cases num by 1
    public void IncreaseCasesNum()
    {
        CasesNum++;
    }
}