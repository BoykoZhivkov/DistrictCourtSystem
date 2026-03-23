namespace DistrictCourt;

public class CivilianCase : Case
{
    // if case civilian -> accuser is Civilian
    public CivilianCase(Judge judge, Defendant defendant, Accuser accuser)
        : base(CaseType.Civil, judge, defendant, accuser) { }
    
    public override void Conduct()
    {
        LogParticipants();
        
        // Step 1
        UpdateStatistics();
        
        // Step 2
        LogToHistory("--- Questions from the lawyers of the accuser ---");
        foreach (var lawyer in CaseAccuser.Lawyers)
        {
            // Ask the defendant 3 questions
            for (var i = 0; i < 3; i++)
            {
                LogToHistory(lawyer.AskQuestion(CaseDefendant));
            }

            // Ask every one of the witnesses 2 questions
            foreach (var witness in Witnesses)
            {
                for (var i = 0; i < 2; i++)
                {
                    LogToHistory(lawyer.AskQuestion(witness));
                }
            }
        }
        
        // Step 3
        LogToHistory("--- Questions from the lawyers of the defendant ---");
        DefenseQuestions();
        
        // Step 4 & 5
        var isGuilty = GetJurorsVerdict();
        LogToHistory($"Verdict of the Jurors: {(isGuilty ? "GUILTY" : "NOT GUILTY")}");
        
        if (isGuilty)
        {
            var years = CaseJudge.GiveSentence();
            
            LogToHistory($"Verdict: {years} years in prison.");
        }
        else
        {
            LogToHistory("Verdict: NOT GUILTY!");
        }

    }
}