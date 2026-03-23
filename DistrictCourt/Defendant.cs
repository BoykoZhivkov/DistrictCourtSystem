namespace DistrictCourt;

public class Defendant : Citizen
{
    // List of Lawyers
    public List<Lawyer> Lawyers { get; }

    public Defendant(string name, string address, int age)
        : base(name, address, age)
    {
        Lawyers = new List<Lawyer>();
    }

    public void AddLawyer(Lawyer lawyer)
    {
        // Lawyers cannot repeat
        if (!Lawyers.Contains(lawyer))
        {
            Lawyers.Add(lawyer);
        }
    }
}