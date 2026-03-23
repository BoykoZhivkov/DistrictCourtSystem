using DistrictCourt;

Random rnd = new Random();

// 1. Create a District Court
Court velikoTarnovo = new Court("Veliko Tarnovo", "Vasil Levski St. 16");

// 2. Add Legal Entities

// Judges -> 3
for (int i = 0; i < 3; i++)
{
    velikoTarnovo.AddLegalEntity(new Judge($"Judge {i + 1}", 10, 50));
}

// Jurors -> 10 (We need more than 10 jurors, because Criminal Case need 13 jurors)
for (int i = 0; i < 15; i++)
{
    velikoTarnovo.AddLegalEntity(new Juror($"Juror {i + 1}",  2, 0));
}

// Lawyers -> 5
for (int i = 0; i < 5; i++)
{
    velikoTarnovo.AddLegalEntity(new Lawyer($"Lawyer {i + 1}",  5, 15));
}

// Prosecutors -> 2
for (int i = 0; i < 2; i++)
{
    velikoTarnovo.AddLegalEntity(new Prosecutor($"Prosecutor {i + 1}",  12, 10));
}

// 3. Add Citizen

// Accusers -> 5
List<Accuser> accusers = new List<Accuser>();
for (int i = 0; i < 5; i++)
{
    accusers.Add(new Accuser($"Accuser {i + 1}", $"Address {i + 1}", 30 + i));
}

// Defendants -> 5
List<Defendant> defendants = new List<Defendant>();
for (int i = 0; i < 5; i++)
{
    defendants.Add(new Defendant($"Defendant {i + 1}", $"Address {i + 1}", 20 + i));
}

// Witnesses -> 10
List<Witness> witnesses = new List<Witness>();
for (int i = 0; i < 10; i++)
{
    witnesses.Add(new Witness($"Witness {i + 1}", $"Address {i + 1}", 25 + i));
}

// Lists for easy access
var allJudges = velikoTarnovo.LegalEntities.OfType<Judge>().ToList();
var allJurors = velikoTarnovo.LegalEntities.OfType<Juror>().ToList();
var allLawyers = velikoTarnovo.LegalEntities.OfType<Lawyer>().ToList();
var allProsecutors = velikoTarnovo.LegalEntities.OfType<Prosecutor>().ToList();

// 7. Print statistics before cases
Console.WriteLine("Statistics Before Cases: ");
velikoTarnovo.PrintLegalEntitiesStatistics();

// 4. Create 3 Civilian Cases
for (int i = 0; i < 3; i++)
{
    var judge = allJudges[rnd.Next(allJudges.Count)];
    var def = defendants[rnd.Next(defendants.Count)];
    var acc = accusers[rnd.Next(accusers.Count)];
    
    // Add at least 1 lawyer
    def.AddLawyer(allLawyers[rnd.Next(allLawyers.Count)]);
    acc.AddLawyer(allLawyers[rnd.Next(allLawyers.Count)]);
    
    CivilianCase cCase = new CivilianCase(judge, def, acc);

    // For civilian case, jurors must be 3
    while (cCase.Jurors.Count < 3)
    {
        int index = rnd.Next(allJurors.Count);
        Juror candidate = allJurors[index];
        
        cCase.AddJuror(candidate);
    }
    
    velikoTarnovo.AddCase(cCase);
}

// 5. Create 3 Criminal Cases
for (int i = 0; i < 3; i++)
{
    var judge = allJudges[rnd.Next(allJudges.Count)];
    var def = defendants[rnd.Next(defendants.Count)];
    var pros = allProsecutors[rnd.Next(allProsecutors.Count)];
    
    def.AddLawyer(allLawyers[rnd.Next(allLawyers.Count)]);

    CriminalCase crCase = new CriminalCase(judge, def, pros);
    
    // For criminal case, jurors must be 13
    while (crCase.Jurors.Count < 13)
    {
        int index = rnd.Next(allJurors.Count);
        Juror candidate = allJurors[index];
        
        crCase.AddJuror(candidate);
    }
    
    velikoTarnovo.AddCase(crCase);
}

// 6. Call method Conduct for all Cases
foreach (var c in velikoTarnovo.Cases)
{
    c.Conduct();
}

// 7. Print statistics AFTER cases
Console.WriteLine("\nStatistics After Cases: ");
velikoTarnovo.PrintLegalEntitiesStatistics();

Console.WriteLine("Done!");