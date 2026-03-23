namespace DistrictCourt;

public abstract class Case
{
    // Properties   
    public CaseType Type { get; set; }
    protected Judge CaseJudge { get; }
    public List<Juror> Jurors { get; }
    protected Defendant CaseDefendant { get; }
    protected IAccuser CaseAccuser { get; }
    protected List<Witness> Witnesses { get; }
    
    // Name of file for the precise case
    private readonly string _fileName;
    
    // Constructor
    protected Case(CaseType type, Judge caseJudge, Defendant caseDefendant, IAccuser caseAccuser)
    {
        Type = type;
        CaseJudge = caseJudge;
        Jurors = new List<Juror>();
        CaseDefendant = caseDefendant;
        CaseAccuser = caseAccuser;  
        Witnesses = new List<Witness>();

        _fileName = $"{type}_{CaseDefendant.Name}_{DateTime.Now:yyyyMMdd_HHmm}.txt";
    }
    
    // Jurors cannot repeat
    public void AddJuror(Juror juror)
    {
        if (!Jurors.Contains(juror))
        {
            Jurors.Add(juror);
        }
    }

    // Witnesses cannot repeat
    public void AddWitness(Witness witness)
    {
        if (!Witnesses.Contains(witness))
        {
            Witnesses.Add(witness);
        }
    }

    // First step of Conduct() method
    protected void UpdateStatistics()
    {
        // Judge
        CaseJudge.IncreaseCasesNum();
        
        // Jurors
        foreach (var juror in Jurors)
        {
            juror.IncreaseCasesNum();
        }
        
        // Lawyers of defendant
        foreach (var lawyer in CaseDefendant.Lawyers)
        {
            lawyer.IncreaseCasesNum();
        }
        
        // Accuser (either the Prosecutor or the lawyers of accuser)
        if (CaseAccuser is Prosecutor prosecutor)
        {
            prosecutor.IncreaseCasesNum();
        } else if (CaseAccuser is Accuser accuser)
        {
            foreach (var lawyer in accuser.Lawyers)
            {
                lawyer.IncreaseCasesNum();
            }
        }
    }
    
    // Third step of Conduct() method
    protected void DefenseQuestions()
    {
        // Every lawyer of the defendant
        foreach (var lawyer in CaseDefendant.Lawyers)
        {
            // Asks every one of the witnesses
            foreach (var witness in Witnesses)
            {
                // 5 questions
                for (int i = 0; i < 5; i++)
                {
                    string action = lawyer.AskQuestion(witness);
                    LogToHistory(action);
                }
            }
        }
    }
    
    // Forth step of Conduct() method
    protected bool GetJurorsVerdict()
    {
        var rnd = new Random();
        var guiltyVotes = 0;

        foreach (var juror in Jurors)
        {
            // 0 -> Not Guilty, 1 -> Guilty
            var vote = rnd.Next(0, 2);
            var voteText = (vote == 1) ? "GUILTY" : "NOT GUILTY";
            
            LogToHistory($"Juror: {juror.Name} -> Vote: {voteText}");

            if (vote == 1) guiltyVotes++;
        }
        
        // If more than 50% of the jurors are in unison, the decision is finito
        return guiltyVotes > Jurors.Count / 2;
    }
    
    // Sixth step of Conduct() method
    // Method for writing in chronology:
    protected void LogToHistory(string message)
    {
        using (var writer = new StreamWriter(_fileName, true))
        {
            writer.WriteLine(message);
        }
    }

    protected void LogParticipants()
    {
        LogToHistory("--- Chronology of the case ---");
        LogToHistory($"Judge: {CaseJudge.Name}");
        
        LogToHistory("Jurors:");
        foreach (var juror in Jurors)
        {
            LogToHistory($"- {juror.Name}");
        }
        
        LogToHistory($"Defendant: {CaseDefendant.Name}");
        LogToHistory("Lawyers of defendant:");
        foreach (var lawyer in CaseDefendant.Lawyers)
        {
            LogToHistory($"- {lawyer.Name}");
        }
        
        LogToHistory($"Accuser: {CaseAccuser.Name}");
        if (CaseAccuser.Lawyers.Count > 0)
        {
            LogToHistory($"Lawyers of accuser:");
            foreach (var lawyer in CaseAccuser.Lawyers)
            {
                LogToHistory($"- {lawyer.Name}");
            }
        }
        
        LogToHistory("Witnesses:");
        foreach (var witness in Witnesses)
        {
            LogToHistory($"- {witness.Name}");
        }
        LogToHistory($"--------------------------\n");
    }

    public abstract void Conduct();
}