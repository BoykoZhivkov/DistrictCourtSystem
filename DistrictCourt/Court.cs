namespace DistrictCourt;

public class Court
{
    // Properties
    public string Name { get; set; }
    public string Address { get; set; }
    public List<LegalEntity> LegalEntities { get; }
    public List<Case> Cases { get; }

    // Constructor
    public Court(string name, string address)
    {
        Name = name;
        Address = address;
        LegalEntities = [];       // Collection Expression
        Cases = new List<Case>(); // Classic Variant
    }

    public void AddLegalEntity(LegalEntity legalEntity)
    {
        if (!LegalEntities.Contains(legalEntity))
        {
            LegalEntities.Add(legalEntity);
        }
    }
    
    public void AddCase(Case newCase)
    {
        Cases.Add(newCase);
    }

    // Method to print Statistics for Legal Entities
    public void PrintLegalEntitiesStatistics()
    {
        var sorted = LegalEntities.OrderBy(e => e.Name).ToList();

        foreach (var e in sorted)
        {
            Console.WriteLine($"{e.Name} - {e.CasesNum}");
        }
    }
}