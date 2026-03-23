namespace DistrictCourt;

public class Accuser : Citizen, IAccuser
{
    // List of Lawyers
    public List<Lawyer> Lawyers { get; set; }

    public Accuser(string name, string address, int age)
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