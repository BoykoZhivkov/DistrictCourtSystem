namespace DistrictCourt;

public interface IAccuser
{
    string Name { get; }
    // Accuser should have a list of Lawyers
    List<Lawyer> Lawyers { get; }
}