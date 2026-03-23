namespace DistrictCourt;

public class CriminalCase : Case
{
    // if case criminal -> accuser is Prosecutor
    public CriminalCase(Judge judge, Defendant defendant, Prosecutor prosecutor)
        : base(CaseType.Criminal,  judge, defendant, prosecutor) { }
    
    public override void Conduct()
    {
        LogParticipants();
        
        // Step 1
        UpdateStatistics();

        // Step 2
        LogToHistory("--- Start of questioning ---");
        if (CaseAccuser is Prosecutor prosecutor)
        {
            LogToHistory($"--- Questions from the Prosecutor ---");
            // Prosecutor asks the defendant 5 questions
            for (var i = 0; i < 5; i++)
            {
                LogToHistory(prosecutor.AskQuestion(CaseDefendant));
            }
            
            // Prosecutor asks every one of the witnesses 5 questions
            foreach (var witness in Witnesses)
            {
                for (var i = 0; i < 5; i++)
                {
                    LogToHistory(prosecutor.AskQuestion(witness));
                }
            }
        }
        
        // Step 3
        DefenseQuestions();
        
        // Step 4
        LogToHistory("--- Final Verdict ---");
        var isGuilty = GetJurorsVerdict();
        
        if (isGuilty)
        {
            var years = CaseJudge.GiveSentence();
            LogToHistory($"Verdict: GUILTY! Sentenced to {years} years in prison.");
        }
        else
        {
            LogToHistory($"Verdict: NOT GUILTY!");
        }
    }
}
